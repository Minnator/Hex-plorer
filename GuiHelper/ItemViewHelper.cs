﻿using System.Globalization;
using Hex_plorer.ControlExtensions;
using Hex_plorer.GuiElements;

namespace Hex_plorer;

public static class ItemViewHelper
{
    public static void LoadItemView(string fullPath, HexPlorerWindow window)
    {
        ClearItemView(window);

        switch (window.HexState.ItemDisplayMode)
        {
            case ItemDisplayMode.Hex:
                HexViewHelper.DisplayHex(fullPath, window);
            return;
                break;
            case ItemDisplayMode.List:
                DisplayList(fullPath, window);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        FolderHistory.Add(fullPath);
    }

    private static void ClearItemView(HexPlorerWindow window)
    {
        window.HexState.ItemListView?.Dispose();
        window.HexState.FlowPanelHexView?.Dispose();
    }

    public static void DisplayList(string fullPath, HexPlorerWindow window)
    {
        window.HexState.ItemListView = new SortedListView(window)
        {
            Dock = DockStyle.Fill,
            View = View.Details,
            FullRowSelect = true,
            HideSelection = false,
            MultiSelect = true,
            BackColor = Color.DimGray,
            Sorting = SortOrder.Ascending,
            Columns =
         {
            new ColumnHeader { Text = "EntryName", Width = 200 },
            new ColumnHeader { Text = "Date modified", Width = 200 },
            new ColumnHeader { Text = "Type", Width = 100 },
            new ColumnHeader { Text = "Size", Width = 100, TextAlign = HorizontalAlignment.Right },
         },

        };

        // image$i,4$bla.png
        //ImageListHelper.SetImageList();
        //State.ItemListView.LargeImageList = State.ItemImageList; // Assign ImageList to ListView

        window.HexState.ItemListView.DoubleBuffered(true);
        window.HexState.ItemListView.SuspendLayout();
        window.ViewSplitContainer.Panel1.Controls.Clear();
        window.ViewSplitContainer.Panel1.Controls.Add(window.HexState.ItemListView);

        var path = fullPath + Path.DirectorySeparatorChar;
        var items = new List<ListViewItem>();

        foreach (var file in DataHelper.GetAllFiles(path))
        {
            var itemRow = new ListViewItem([
               file.Name,
            file.LastWriteTime.ToString(CultureInfo.InvariantCulture),
            file.Extension,
            file.Length / 1024 + " KB"
            ]);
            itemRow.Tag = file.Length;
            items.Add(itemRow);
        }

        foreach (var dir in DataHelper.GetAllDirectories(path))
        {
            var itemRow = new ListViewItem([
               dir.Name,
            dir.LastWriteTime.ToString(CultureInfo.InvariantCulture),
            "File folder",
            ""
            ]);
            items.Add(itemRow);
        }

        window.HexState.ItemListView.BeginUpdate();
        window.HexState.ItemListView.Items.AddRange(items.ToArray());
        if (window.HexState.ItemListView.Items.Count <= 0)
            window.HexState.ItemListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        window.HexState.ItemListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        window.HexState.ItemListView.ResumeLayout(false);
        window.HexState.ItemListView.PerformLayout();
        window.HexState.ItemListView.EndUpdate();
    }





}
