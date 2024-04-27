using Hex_plorer.GuiHelper;

namespace Hex_plorer;

public class HexState
{
   public string LastPreviewPath { get; set; } = string.Empty;

   // State variables
   public bool IsDarkMode { get; set; }
   public bool IsLoadingPath { get; set; }
   public ItemDisplayMode ItemDisplayMode { get; set; } = ItemDisplayMode.List;
   public SearchOptions SearchOptions { get; set; }
   // Item View
   public ListView ItemListView { get; set; } = null!;
   public ImageList ItemImageList { get; set; } = null!;
   public FlowLayoutPanel FlowPanelHexView { get; set; } = null!;

   // Texts
   public Font DFont { get; set; } = new Font("VeraMono", 8);

   // Preview
   public int MaxFullPreviewFileSize { get; set; } = 1024 * 20; // 50 KB to save performance
   public int MaxCharPreview { get; set; } = 2048;
   public int MaxLinesPreview { get; set; } = 30;
}
