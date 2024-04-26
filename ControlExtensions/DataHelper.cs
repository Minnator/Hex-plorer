using System.Globalization;

namespace Hex_plorer.ControlExtensions;

public static class DataHelper
{
   public static List<FileInfo> GetAllFiles(string path)
   {
      var files = new List<FileInfo>();
      foreach (var item in Directory.EnumerateFileSystemEntries(path))
      {
         var info = new FileInfo(item);
         if (File.Exists(item) && CanReadFileInfo(info)) 
            files.Add(info);

      }
      return files;
   }

   public static List<DirectoryInfo> GetAllDirectories(string path)
   {
      var dirs = new List<DirectoryInfo>();
      foreach (var item in Directory.EnumerateFileSystemEntries(path))
      {
         var info = new DirectoryInfo(item);
         if (Directory.Exists(item) && CanReadDirectoryInfo(info)) 
            dirs.Add(info);

      }
      return dirs;
   }

   // Method to check if you have access to a DirectoryInfo
   private static bool CanReadDirectoryInfo(DirectoryInfo directoryInfo)
   {
      try
      {
         foreach (var _ in directoryInfo.EnumerateFiles()) { }
         foreach (var _ in directoryInfo.EnumerateDirectories()) { }
         return true;
      }
      catch (UnauthorizedAccessException)
      {
         return false;
      }
      catch (IOException)
      {
         return false;
      }
   }

   // Method to check if you have access to a FileInfo
   private static bool CanReadFileInfo(FileInfo fileInfo)
   {
      try
      {
         using (fileInfo.OpenRead()) { }
         return true;
      }
      catch (UnauthorizedAccessException)
      {
         return false;
      }
      catch (IOException)
      {
         return false;
      }
   }

}