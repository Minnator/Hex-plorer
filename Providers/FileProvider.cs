namespace Hex_plorer.Providers;

public static class FileProvider
{
   public static string[] GetFiles(string path)
   {
      return Directory.GetFiles(path);
   }

   public static string[] GetAccessibleFiles(string path)
   {
      var files = Directory.GetFiles(path);
      List<string> accessibleFiles = [];

      foreach (var file in files)
      {
         try
         {
            File.OpenRead(file);
            accessibleFiles.Add(file);
         }
         catch (UnauthorizedAccessException)
         { }
         catch (IOException)
         { }
      }
      return [.. accessibleFiles];
   }

   public static string[] GetFiles(string path, string searchPattern)
   {
      return Directory.GetFiles(path, searchPattern);
   }
}