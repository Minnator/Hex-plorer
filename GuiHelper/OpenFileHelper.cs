using Microsoft.Win32;
using System.Diagnostics;

namespace Hex_plorer.GuiHelper;

public static class OpenFileHelper
{
   public static void OpenFileWithDefault(string path)
   {
      if (!File.Exists(path))
         return;

      try
      {
         Process.Start(new ProcessStartInfo
         {
            FileName = path,
            UseShellExecute = true
         });
      }
      catch (Exception ex)
      {
         MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
   }

   public static void OpenFileWith(string path, string program)
   {
      if (!File.Exists(path))
         return;

      try
      {
         Process.Start(new ProcessStartInfo
         {
            FileName = program,
            Arguments = path,
            UseShellExecute = true
         });
      }
      catch (Exception ex)
      {
         MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
   }

}