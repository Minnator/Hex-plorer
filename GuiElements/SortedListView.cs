using Hex_plorer.GuiHelper;
using System.Collections;

namespace Hex_plorer.GuiElements;


public class SortedListView : ListView
{
   private int _sortedColumn;
   private SortOrder _sortOrder = SortOrder.None;
   private HexPlorerWindow _window;

   public SortedListView(HexPlorerWindow window)
   {
      _window = window;
      ColumnClick += OnColumnClick;
      MouseClick += OnClick;
      MouseDoubleClick += OnDoubleClick;
      MouseDown += _window.NavigationButton_MouseDown;
      _sortedColumn = -1;
   }

   private void OnColumnClick(object? sender, ColumnClickEventArgs e)
   {
      if (e.Column == _sortedColumn)
         _sortOrder = (_sortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
      else
      {
         _sortedColumn = e.Column;
         _sortOrder = SortOrder.Ascending;
      }

      ListViewItemSorter = new ListViewItemComparer(_sortedColumn, _sortOrder);
      Sort();
   }

   private void OnClick(object? sender, MouseEventArgs e)
   {
      if (e.Button == MouseButtons.Right)
      {
         HexplorerHelper.ShowContextMenu(e, _window);
         return;
      }
      var clientPoint = PointToClient(MousePosition);
      var item = this.GetItemAt(clientPoint.X, clientPoint.Y);
      if (item == null)
         return;

      var current = FolderHistory.GetCurrentPath();
      if (current == null)
         return;
      _window.SetPreview(Path.Combine(current, item.SubItems[0].Text));
   }

   private void OnDoubleClick(object? sender, MouseEventArgs e)
   {
      if (e.Button == MouseButtons.Right)
         return;
      var item = GetItemAt(e.X, e.Y);
      if (item == null)
         return;
      var current = FolderHistory.GetCurrentPath();
      if (current == null)
         return;
      var itemPath = Path.Combine(current, item.SubItems[0].Text);
      if (File.Exists(itemPath))
         OpenFileHelper.OpenFileWithDefault(itemPath);
      else
      {
         var node = FileTreeViewHelper.NavigateTo(itemPath, _window);
         if (node != null)
         {
            ItemViewHelper.LoadItemView(node, _window);
            FolderHistory.Add(node.FullPath);
         }
      }
   }
   
}

public class ListViewItemComparer : IComparer
{
   private readonly int _column;
   private readonly SortOrder _sortOrder;

   public ListViewItemComparer()
   {
      _column = 0;
      _sortOrder = SortOrder.Ascending;
   }

   public ListViewItemComparer(int column, SortOrder sortOrder)
   {
      _column = column;
      _sortOrder = sortOrder;
   }

   public int Compare(object? x, object? y)
   {
      var listViewItemX = x as ListViewItem;
      var listViewItemY = y as ListViewItem;
      int compareResult;

      if (listViewItemX?.Tag is long xSize && listViewItemY?.Tag is long ySize)
         compareResult = xSize.CompareTo(ySize);
      else
         compareResult = string.CompareOrdinal(listViewItemX?.SubItems[_column].Text, listViewItemY?.SubItems[_column].Text);
      if (_sortOrder == SortOrder.Descending)
         compareResult *= -1;
      return compareResult;
   }
}
