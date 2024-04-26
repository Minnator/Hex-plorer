using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hex_plorer.GuiHelper;

public static class ImageListHelper
{
   public static void SetImageList(HexPlorerWindow window)
   {
      window.HexState.ItemImageList = new ImageList();
      window.HexState.ItemImageList.ImageSize = new Size(16, 16);
      window.HexState.ItemImageList.ColorDepth = ColorDepth.Depth32Bit;
      window.HexState.ItemListView.LargeImageList = window.HexState.ItemImageList;
   }

   public static void AddImage(string path, HexPlorerWindow window)
   {
      if (!File.Exists(path))
         return;
      var icon = Icon.ExtractAssociatedIcon(path);
      if (icon == null)
         return;
      window.HexState.ItemImageList.Images.Add(icon);
   }
}