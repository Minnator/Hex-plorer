using System.Text;
using System.Windows.Forms;
using Hex_plorer.GuiElements;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Hex_plorer.GuiHelper;

public enum FileType
{
   Image,
   Text,
   Table,
   NONE
}

public static class FilePreviewHelper
{
   public static void ShowPreview(string fullPath, HexPlorerWindow window)
   {
      switch (GetFileType(fullPath))
      {
         case FileType.Text:
            ShowTextPreview(fullPath, window);
            break;
         case FileType.Image:
            ShowImagePreview(fullPath, window);
            break;
         case FileType.NONE:
            return;
         case FileType.Table:
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }
   }

   public static void ShowTextPreview(string fullPath, HexPlorerWindow window)
   {
      window.ViewSplitContainer.Panel2.Controls.Clear();
      var textBox = new HexTextBox(window)
      {
         Dock = DockStyle.Fill,
         Multiline = true,
         ScrollBars = ScrollBars.Both,
         ReadOnly = true,
         Font = new Font("Consolas", 10),
         HideSelection = false,
      };
      window.ViewSplitContainer.Panel2.Controls.Add(textBox);

      // I only want to render a small preview of the file.
      // If the size of the file is small enough the entire content will be shown
      // For big files only the first 50 lines will be shown and once the preview is clicked 
      // the entire content will be shown
      textBox.Text = GetPreviewText(fullPath, window);
   }

   private static string GetPreviewText(string path, HexPlorerWindow window)
   {
      var fileInfo = new FileInfo(path);
      if (fileInfo.Length < window.HexState.MaxFullPreviewFileSize)
         return File.ReadAllText(path);

      if (CountLines(path) > window.HexState.MaxLinesPreview)
         return GetQuickPreviewString(path);
      return GetQuickPreviewFileStart(path, window);
   }

   private static string GetQuickPreviewFileStart(string path, HexPlorerWindow window)
   {
      var buffer = new char[window.HexState.MaxCharPreview];
      var result = new StringBuilder();

      using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
         using (var reader = new StreamReader(fileStream))
         {
            // Read characters directly into the buffer
            var charsRead = reader.ReadBlock(buffer, 0, window.HexState.MaxCharPreview);
            // Append the read characters to the result
            result.Append(buffer, 0, charsRead);
         }
      }
      return result.ToString();
   }

   private static int CountLines(string path)
   {
      var lineCount = 0;
      using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
      {
         using (var reader = new StreamReader(fileStream))
         {
            while (reader.ReadLine() != null)
            {
               lineCount++;
            }
         }
      }
      return lineCount;
   }

   private static string GetQuickPreviewString(string fullPath)
   {
      var sb = new StringBuilder();
      using (var reader = new StreamReader(fullPath))
      {
         var lineCount = 0;
         while (reader.ReadLine() is { } line && lineCount < 50 && sb.Length < 2000)
         {
            sb.AppendLine(line);
            lineCount++;
         }
      }
      return sb.ToString();
   }

   public static void ShowImagePreview(string fullPath, HexPlorerWindow window)
   {
      window.ViewSplitContainer.Panel2.Controls.Clear();
      var pictureBox = new PictureBox
      {
         Dock = DockStyle.Fill,
         SizeMode = PictureBoxSizeMode.Zoom,
         Image = Image.FromFile(fullPath),
      };
      window.ViewSplitContainer.Panel2.Controls.Add(pictureBox);

      try
      {
         pictureBox.Image = Image.FromFile(fullPath);
      }
      catch (UnauthorizedAccessException) { }
      catch (IOException) { }
   }

   public static void DisposeComponents(HexPlorerWindow window)
   {
      foreach (Control control in window.ViewSplitContainer.Panel2.Controls) 
         control.Dispose();
      window.ViewSplitContainer.Panel2.Controls.Clear();
      GC.Collect();
   }


   public static FileType GetFileType(string fullPath)
   {
      switch (Path.GetExtension(fullPath))
      {
         case ".txt":
         case ".log":
         case ".ini":
         case ".json":
         case ".xml":
         case ".html":
         case ".css":
         case ".js":
         case ".cs":
         case ".cpp":
         case ".h":
         case ".hpp":
         case ".java":
         case ".py":
         case ".php":
         case ".rb":
         case ".pl":
         case ".sh":
         case ".bat":
         case ".cmd":
         case ".xaml":
         case ".xamlx":
            return FileType.Text;
         case ".png":
         case ".jpg":
         case ".jpeg":
         case ".gif":
         case ".bmp":
         case ".tiff":
         case ".ico":
         case ".svg":
         case ".webp":
         case ".heic":
         case ".heif":
            return FileType.Image;
         default:
            return FileType.NONE;
      }
   }

   

}

