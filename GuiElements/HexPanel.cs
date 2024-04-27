using Hex_plorer.GuiHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hex_plorer.GuiElements;

public sealed class HexPanel : Panel
{
    public string Path { get; set; } = string.Empty;
    public string EntryName { get; set; } = string.Empty;
    public ItemType ItemType { get; set; } = ItemType.None;
    private HexPlorerWindow Window { get; set; }

    public HexPanel(HexPlorerWindow window)
    {
        Window = window;
        DoubleBuffered = true;
        Paint += OnPaint;
        MouseEnter += OnMouseEnter;
        MouseLeave += OnMouseLeave;
        MouseClick += OnClick;
        MouseDoubleClick += OnDoubleClick;
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        DrawHelper.DrawHex(e.Graphics, Width, Width, Color.Black);

        //var font = new Font("VeraMono", 8);
        //var brush = new SolidBrush(Color.Black);

        //DrawHelper.DrawStringCenteredInRect(e.Graphics, EntryName, new Rectangle(0, Width, Width, Height - Width), font, brush);
    }

    public void OnMouseEnter(object? sender, EventArgs e)
    {
        Parent!.BackColor = Color.Aqua;
    }

    public void OnMouseLeave(object? sender, EventArgs e)
    {
        Parent!.BackColor = Color.DimGray;
    }

    public void OnClick(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
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