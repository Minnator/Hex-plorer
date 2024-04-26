using Hex_plorer.GuiHelper;

namespace Hex_plorer;

public class HexState
{
   public string LastPreviewPath { get; set; } = string.Empty;

   // State variables
   public bool IsDarkMode { get; set; }
   public bool IsLoadingPath { get; set; }
   public ItemDisplayMode ItemDisplayMode { get; set; } = ItemDisplayMode.Hex;
   public SearchOptions SearchOptions { get; set; }

   // Item View
   public ListView ItemListView { get; set; } = null!;
   public ImageList ItemImageList { get; set; } = null!;
   public FlowLayoutPanel FlowPanelHexView { get; set; } = null!;
}
