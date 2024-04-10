namespace Hex_plorer.GuiHelper;

public enum FileType
{
   Image,
   Text,

}

public static class FilePreviewHelper
{
   public static void ShowPreview(string fullPath)
   {
      var fileType = GetFileType(fullPath);
      switch (fileType)
      {
         case FileType.Text:
            ShowTextPreview(fullPath);
            break;
         case FileType.Image:
            ShowImagePreview(fullPath);
            break;
      }
   }

   public static void ShowTextPreview(string fullPath)
   {
      State.HPWindow.ViewSplitContainer.Panel2.Controls.Clear();
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
      State.HPWindow.ViewSplitContainer.Panel2.Controls.Add(textBox);

      try
      {
         textBox.Text = File.ReadAllText(fullPath);
      }
      catch (UnauthorizedAccessException) { }
      catch (IOException) { }
   }

   public static void ShowImagePreview(string fullPath)
   {
      State.HPWindow.ViewSplitContainer.Panel2.Controls.Clear();
      var pictureBox = new PictureBox
      {
         Dock = DockStyle.Fill,
         SizeMode = PictureBoxSizeMode.Zoom,
         Image = Image.FromFile(fullPath),
      };
      State.HPWindow.ViewSplitContainer.Panel2.Controls.Add(pictureBox);

      try
      {
         pictureBox.Image = Image.FromFile(fullPath);
      }
      catch (UnauthorizedAccessException) { }
      catch (IOException) { }
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
         case ".ps1":
         case ".psm1":
         case ".psd1":
         case ".ps1xml":
         case ".clixml":
         case ".pssc":
         case ".cdxml":
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
            return FileType.Text;
      }
   }
}