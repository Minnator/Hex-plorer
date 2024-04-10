namespace Hex_plorer;

internal static class State
{
   // State variables
   public static bool IsDarkMode { get; set; }
   public static bool IsLoadingPath { get; set; }
   public static ItemDisplayMode ItemDisplayMode { get; set; } = ItemDisplayMode.List;

   // Application state
   public static HexPlorerWindow HPWindow { get; set; } = null!;
   public static ListView ItemListView { get; set; } = null!;
   public static TableLayoutPanel ItemHexView { get; set; } = null!;

}

public enum ItemDisplayMode
{
   Hex,
   List,
}