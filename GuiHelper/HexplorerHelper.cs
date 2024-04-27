namespace Hex_plorer;

public static class HexplorerHelper
{
   public static ItemType? GetTypeBelowCursor(Point pos, HexPlorerWindow window)
   {
      switch (window.HexState.ItemDisplayMode)
      {
         case ItemDisplayMode.Hex:
            break;
         case ItemDisplayMode.List:
            var item = window.HexState.ItemListView.GetItemAt(pos.X, pos.Y);
            var current = FolderHistory.GetCurrentPath();
            if (item == null || current == null)
               return null;
            var itemPath = Path.Combine(current, item.SubItems[0].Text);
            if (Directory.Exists(itemPath))
               return ItemType.Directory;
            if (File.Exists(itemPath))
               return ItemType.File;
            if (DriveInfo.GetDrives().Any(d => d.Name == itemPath))
               return ItemType.Drive;
            return null;
         default:
            throw new ArgumentOutOfRangeException();
      }

      return ItemType.File;
   }

   public static void ShowContextMenu(MouseEventArgs e, HexPlorerWindow window)
   {
      switch (e.Button)
      {
         case MouseButtons.Right:
            var type = HexplorerHelper.GetTypeBelowCursor(e.Location, window);
            if (type == ItemType.File)
               window.FileContextMenu.Show(Cursor.Position);
            if (type == ItemType.Directory)
               window.DirectoryContextMenu.Show(Cursor.Position);
            break;
      }
   }


}