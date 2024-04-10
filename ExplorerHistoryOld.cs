using System.Diagnostics;

namespace Hex_plorer;

[Obsolete("Use FolderHistory instead")]
public static class ExplorerHistoryOld
{
   private class Node
   {
      public string Location { get; }
      public Node? Previous { get; set; }
      public Node? Next { get; set; }

      public Node(string location)
      {
         Location = location;
      }
      
      public override bool Equals(object? obj) 
         => HashCode.Combine(Location) == HashCode.Combine((obj as Node)?.Location);
      protected bool Equals(Node other) => Location == other.Location;
      public override int GetHashCode() => HashCode.Combine(Location);
   }

   private static Node? _current = null;

   public static void NavigateTo(string location)
   {
      // Add the current location to the history)
      var newNode = new Node(location);
      if (Equals(_current, newNode))
         return; // Already at this location
      newNode.Previous = _current;
      if (_current != null) 
         _current.Next = newNode;
      _current = newNode;
      PrintHistory();
   }

   public static string? NavigateBack()
   {
      // Navigate back in history
      if (_current is not { Previous: not null })
         return null; // No more history to navigate back
      _current = _current.Previous;
      return _current.Location;
   }

   public static string? NavigateForward()
   {
      // Navigate forward in history
      if (_current is not { Next: not null })
         return null; // No more history to navigate forward
      _current = _current.Next;
      return _current.Location;
   }

   private static void PrintHistory()
   {
      Debug.WriteLine("=====================\nHistory:");
      var node = _current;
      while (node != null)
      {
         Debug.WriteLine(node.Location);
         node = node.Previous;
      }
   }

   public static void RemoveLast()
   {
      if (_current is { Previous: not null })
      {
         _current = _current.Previous;
         PrintHistory();
      }
      
   }
}