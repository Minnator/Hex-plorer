using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hex_plorer.GuiHelper;

public struct SearchOptions
{
   public bool MatchCase { get; set; }
   public bool MatchWholeWord { get; set; }
   public bool UseRegex { get; set; }
   public bool DeepSearch { get; set; }
}

public class SearchOptionsHelper
{
   public void OnItemClicked(object? sender, EventArgs e, HexPlorerWindow window)
   {
      if (sender == null)
         return;
      var item = (ToolStripMenuItem)sender;
      item.Checked = !item.Checked;
      GetSearchOptions(window);
   }

   private static void GetSearchOptions(HexPlorerWindow window)
   {
      window.HexState.SearchOptions = new SearchOptions
      {
         MatchCase = window.MatchCase.Checked,
         MatchWholeWord = window.MatchFullWord.Checked,
         UseRegex = window.UseRegex.Checked,
         DeepSearch = window.UseDeepSearch.Checked
      };
   }
}

public static class SearchEngine
{
   public static List<string> Search(string searchString, string path, HexPlorerWindow window)
   {
      if (string.IsNullOrEmpty(searchString))
         return new List<string>();
      var result = new List<string>();
      // Search the file system
      if (window.HexState.SearchOptions.DeepSearch)
      {
         result = DeepSearch(searchString, path, window);
      }
      else
      {
         // Normal search
      }

      return result;
   }

   private static List<string> DeepSearch(string searchString, string path, HexPlorerWindow window)
   {
      var result = new List<string>();
      // Deep search every file in the directory and subdirectories recursively

      if (window.HexState.SearchOptions.DeepSearch)
      {
         result = Search(searchString, path, window);
      }

      return result;
   }
}
