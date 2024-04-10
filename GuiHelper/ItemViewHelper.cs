using System.Diagnostics;
using System.Globalization;
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
         GridLines = false,
         HideSelection = false,
         MultiSelect = true,
         Sorting = SortOrder.Ascending,
         Columns =
         {
            new ColumnHeader { Text = "Name", Width = 200 },
            new ColumnHeader { Text = "Date modified", Width = 200 },
            new ColumnHeader { Text = "Type", Width = 100 },
            new ColumnHeader { Text = "Size", Width = 100, TextAlign = HorizontalAlignment.Right},
         }
      };
      State.HPWindow.ViewSplitContainer.Panel1.Controls.Clear();
      State.HPWindow.ViewSplitContainer.Panel1.Controls.Add(State.ItemListView);
      var path = node.FullPath + Path.DirectorySeparatorChar;
      var items = new List<ListViewItem>();

      foreach (var item in Directory.EnumerateFileSystemEntries(path))
      {
         if (File.Exists(item))
         {
            var info = new FileInfo(item);
            var itemRow = new ListViewItem(new[]
            {
               info.Name,
               info.LastWriteTime.ToString(CultureInfo.InvariantCulture),
               info.Extension,
               (info.Length / 1024) + " KB"
            });
            itemRow.Tag = info.Length;
            items.Add(itemRow);
         }
         else if (Directory.Exists(item))
         {
            var info = new DirectoryInfo(item);
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
   }
}
