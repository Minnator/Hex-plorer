using System.Globalization;

namespace Hex_plorer.ControlExtensions;

public static class DataHelper
{
   public static List<FileInfo> GetAllFiles(string path)
   {
      var files = new List<FileInfo>();
      foreach (var item in Directory.EnumerateFileSystemEntries(path))
         if (File.Exists(item)) 
            files.Add(new FileInfo(item));
      return files;
   }

   public static List<DirectoryInfo> GetAllDirectories(string path)
   {
      var dirs = new List<DirectoryInfo>();
      foreach (var item in Directory.EnumerateFileSystemEntries(path))
         if (Directory.Exists(item)) 
            dirs.Add(new DirectoryInfo(item));
      return dirs;
   }

}