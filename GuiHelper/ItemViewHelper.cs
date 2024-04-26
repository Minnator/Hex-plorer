using System.Diagnostics;
using System.Globalization;
using Hex_plorer.ControlExtensions;
using Hex_plorer.GuiElements;

namespace Hex_plorer.GuiHelper;

public static class ItemViewHelper
{
   public static void LoadItemView(TreeNode node, HexPlorerWindow window)
   {
      ClearItemView(window);

      switch (window.HexState.ItemDisplayMode)
      {
         case ItemDisplayMode.Hex:
            Debug.WriteLine("Rendering Hex");
            HexViewHelper.DisplayEmptyHex(node.FullPath, window);
            break;
         case ItemDisplayMode.List:
            Debug.WriteLine("Rendering List");
            ItemViewHelper.DisplayList(node, window);
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }
      FolderHistory.Add(node.FullPath);
   }

   private static void ClearItemView(HexPlorerWindow window)
   {
      window.HexState.ItemListView?.Dispose();
      window.HexState.FlowPanelHexView?.Dispose();
   }

   public static void DisplayList(TreeNode node, HexPlorerWindow window)
   {
      window.HexState.ItemListView = new SortedListView(window)
      {
         Dock = DockStyle.Fill,
         View = View.Details,
         FullRowSelect = true,
         HideSelection = false,
         MultiSelect = true,
         Sorting = SortOrder.Ascending,
         Columns =
        {
            new ColumnHeader { Text = "Name", Width = 200 },
            new ColumnHeader { Text = "Date modified", Width = 200 },
            new ColumnHeader { Text = "Type", Width = 100 },
            new ColumnHeader { Text = "Size", Width = 100, TextAlign = HorizontalAlignment.Right },
        },
      };

      //ImageListHelper.SetImageList();
      //State.ItemListView.LargeImageList = State.ItemImageList; // Assign ImageList to ListView

      window.HexState.ItemListView.DoubleBuffered(true);
      window.HexState.ItemListView.SuspendLayout();
      window.ViewSplitContainer.Panel1.Controls.Clear();
      window.ViewSplitContainer.Panel1.Controls.Add(window.HexState.ItemListView);

      var path = node.FullPath + Path.DirectorySeparatorChar;
      var items = new List<ListViewItem>();

      foreach (var item in Directory.EnumerateFileSystemEntries(path))
      {
         if (File.Exists(item))
         {
            var info = new FileInfo(item);
            var itemRow = new ListViewItem([
               info.Name,
               info.LastWriteTime.ToString(CultureInfo.InvariantCulture),
               info.Extension,
               (info.Length / 1024).ToString() + " KB"
            ]);
            itemRow.Tag = info.Length;

            //var imageIndex = State.ItemImageList.Images.Count;
            //ImageListHelper.AddImage(item);
            //itemRow.ImageIndex = imageIndex;

            items.Add(itemRow);
         }
         else if (Directory.Exists(item))
         {
            var info = new DirectoryInfo(item);
            if (!CanReadDirectoryInfo(info))
               continue;
            var itemRow = new ListViewItem(new[]
            {
                info.Name,
                info.LastWriteTime.ToString(CultureInfo.InvariantCulture),
                "File folder",
                ""
            });
            //var imageIndex = State.ItemImageList.Images.Count;
            //ImageListHelper.AddImage(Environment.GetFolderPath/(Environment.SpecialFolder.Desktop));
            //itemRow.ImageIndex = imageIndex;
            items.Add(itemRow);
         }
      }
      window.HexState.ItemListView.BeginUpdate();
      window.HexState.ItemListView.Items.AddRange(items.ToArray());
      window.HexState.ItemListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      window.HexState.ItemListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      window.HexState.ItemListView.ResumeLayout(false);
      window.HexState.ItemListView.PerformLayout();
      window.HexState.ItemListView.EndUpdate();
   }


   // Method to check if you have access to a DirectoryInfo
   private static bool CanReadDirectoryInfo(DirectoryInfo directoryInfo)
   {
      try
      {
         foreach (var _ in directoryInfo.EnumerateFiles()) { }
         foreach (var _ in directoryInfo.EnumerateDirectories()) { }
         return true;
      }
      catch (UnauthorizedAccessException)
      {
         return false;
      }
      catch (IOException)
      {
         return false;
      }
   }

   // Method to check if you have access to a FileInfo
   private static bool CanReadFileInfo(FileInfo fileInfo)
   {
      try
      {
         using (fileInfo.OpenRead()) { }
         return true;
      }
      catch (UnauthorizedAccessException)
      {
         return false;
      }
      catch (IOException)
      {
         return false;
      }
   }
}
