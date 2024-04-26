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
      }
   }

   public static void ShowTextPreview(string fullPath, HexPlorerWindow window)
   {
      window.ViewSplitContainer.Panel2.Controls.Clear();
      var textBox = new TextBox
      {
         Dock = DockStyle.Fill,
         Multiline = true,
         ScrollBars = ScrollBars.Both,
         ReadOnly = true,
         Font = new Font("Consolas", 10),
         Text = File.ReadAllText(fullPath),
         HideSelection = false,
      };
      window.ViewSplitContainer.Panel2.Controls.Add(textBox);

      try
      {
         textBox.Text = File.ReadAllText(fullPath);
      }
      catch (UnauthorizedAccessException) { }
      catch (IOException) { }
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
      foreach (Control control in window.ViewSplitContainer.Panel2.Controls) control.Dispose();
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