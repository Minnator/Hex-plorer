﻿using System.Collections;

namespace Hex_plorer.GuiElements;


public class SortedListView : ListView
{
   private int _sortedColumn;
   private SortOrder _sortOrder = SortOrder.None;

   public SortedListView()
   {
      ColumnClick += new(OnColumnClick);
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
