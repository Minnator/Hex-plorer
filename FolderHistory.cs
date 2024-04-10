using System.Diagnostics;

namespace Hex_plorer;

public static class FolderHistory
{
   private static readonly List<string> History = new();
   private static int _current = -1;
   private static int _maxSize = 10;

   public static void Add(string path)
   {
      if (History.Count > 0 && History[^1].Equals(path))
         return;
      if (_current < History.Count - 1)
         History.RemoveRange(_current + 1, History.Count - _current - 1); // Remove all forward history as new one is added
      History.Add(path);
      if (History.Count > _maxSize)
         History.RemoveAt(0);
      _current = History.Count - 1;
   }

   public static string? NavigateBack()
   {
      if (_current <= 0)
         return null;
      _current--;
      return History[_current];
   }

   public static string? NavigateForward()
   {
      if (_current >= History.Count - 1)
         return null;
      _current++;
      return History[_current];
   }

   public static void Clear()
   {
      History.Clear();
      _current = -1;
   }

   public static void SetMaxSize(int maxSize)
   {
      _maxSize = maxSize;
      if (History.Count > _maxSize)
         History.RemoveRange(0, History.Count - _maxSize);
      _current = History.Count - 1;
   }

   public static int GetMaxSize() => _maxSize;
   public static int GetCurrent() => _current;
}