using Hex_plorer.GuiHelper;

namespace Hex_plorer;

public class Navigation(int maxSize, HexPlorerWindow window)
{
   private readonly List<string> _history = new();
   public int Current = -1;

   public void NavigateTo(string path)
   {
      // Opening a file path: Open the file with the default program associated with it
      if (File.Exists(path))
      {
         OpenFileHelper.OpenFileWithDefault(path);
         return;
      }
      // Opening a directory path:
      AddToHistory(path);
      ItemViewHelper.LoadItemView(path, window);
      FileTreeViewHelper.NavigateTo(path, window);
      AddressBarHelper.SetAddressBar(path, window);
   }

   public void AddToHistory(string path)
   {
      if (_history.Count > 0 && _history[^1].Equals(path))
         return;
      // Remove all forward history as new one is added
      if (Current < _history.Count - 1)
         _history.RemoveRange(Current + 1, _history.Count - Current - 1); 
      _history.Add(path);
      if (_history.Count > maxSize)
         _history.RemoveAt(0);
      Current = _history.Count - 1;
   }

   public string? NavigateBack()
   {
      if (Current <= 0)
         return null;
      Current--;
      return _history[Current];
   }

   public string? NavigateForward()
   {
      if (Current >= _history.Count - 1)
         return null;
      Current++;
      return _history[Current];
   }

   public void ClearHistory()
   {
      _history.Clear();
      Current = -1;
   }
}