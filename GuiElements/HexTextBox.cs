using Hex_plorer.GuiHelper;

namespace Hex_plorer.GuiElements;

public class HexTextBox : TextBox
{
   public string Path { get; set; } = string.Empty;
   public HexPlorerWindow Window { get; set; }
   public override ContextMenuStrip? ContextMenuStrip { get; set; } = null;

   public HexTextBox(HexPlorerWindow window)
   {
      Window = window;
      MouseEnter += OnMouseEnter;
      MouseLeave += OnMouseLeave;
      MouseClick += OnClick;
      MouseDoubleClick += OnDoubleClick;
   }

   private void OnMouseEnter(object? sender, EventArgs e) => Parent!.BackColor = Color.Aqua;
   private void OnMouseLeave(object? sender, EventArgs e) => Parent!.BackColor = Color.DimGray;

   private void OnClick(object? sender, MouseEventArgs e)
   {
      if (e.Button == MouseButtons.Right)
      {
         ContextMenuStrip = null;
         HexplorerHelper.ShowContextMenu(e, Window);
         return;
      }
      Window.SetPreview(Path);
   }

   private void OnDoubleClick(object? sender, MouseEventArgs e)
   {
      if (e.Button == MouseButtons.Right)
         return;

      if (File.Exists(Path))
         OpenFileHelper.OpenFileWithDefault(Path);
      else
      {
         var node = FileTreeViewHelper.NavigateTo(Path, Window);
         if (node != null)
         {
            ItemViewHelper.LoadItemView(node, Window);
            FolderHistory.Add(node.FullPath);
         }
      }
   }
}