using System.Globalization;
using Hex_plorer.ControlExtensions;
using Hex_plorer.GuiElements;

namespace Hex_plorer.GuiHelper;

public static class ItemViewHelper
{
   public static void DisplayList(TreeNode node)
   {
      State.ItemListView = new SortedListView
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
            new ColumnHeader { Text = "Size", Width = 100, TextAlign = HorizontalAlignment.Right},
         },
      };
      State.ItemListView.DoubleBuffered(true);
      State.ItemListView.SuspendLayout();
      State.HPWindow.ViewSplitContainer.Panel1.Controls.Clear();
      State.HPWindow.ViewSplitContainer.Panel1.Controls.Add(State.ItemListView);
      var path = node.FullPath + Path.DirectorySeparatorChar;
      var items = new List<ListViewItem>();

      foreach (var item in Directory.EnumerateFileSystemEntries(path))
      {
         if (File.Exists(item))
         {
            var info = new FileInfo(item);
            //if (!CanReadFileInfo(info))
               //continue;
            var itemRow = new ListViewItem(new[]
            {
               info.Name,
               info.LastWriteTime.ToString(CultureInfo.InvariantCulture),
               info.Extension,
               info.Length / 1024 + " KB"
            });
            itemRow.Tag = info.Length;
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
            items.Add(itemRow);
         }
      }
      State.ItemListView.Items.AddRange(items.ToArray());
      State.ItemListView.BeginUpdate();
      State.ItemListView.SuspendLayout();
      State.ItemListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      State.ItemListView.ResumeLayout(false);
      State.ItemListView.PerformLayout();
      State.ItemListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      State.ItemListView.EndUpdate();
      State.ItemListView.ResumeLayout(true);

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
