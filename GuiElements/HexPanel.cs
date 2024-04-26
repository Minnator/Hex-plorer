namespace Hex_plorer.GuiElements;

public sealed class HexPanel : Panel
{
    public string Path { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public ItemType ItemType { get; set; } = ItemType.None;
    private HexPlorerWindow Window { get; set; }

    public HexPanel(HexPlorerWindow window)
    {
        Window = window;
        DoubleBuffered = true;
        Paint += OnPaint;
        MouseEnter += OnMouseEnter;
        MouseLeave += OnMouseLeave;
    }

    private void OnPaint(object? sender, PaintEventArgs e)
    {
        DrawHelper.DrawHex(e.Graphics, Width, Width, Color.Black);

        var font = new Font("VeraMono", 8);
        var brush = new SolidBrush(Color.Black);

        DrawHelper.DrawStringCenteredInRect(e.Graphics, Name, new Rectangle(0, Width, Width, Height - Width), font, brush);
    }

    public void OnMouseEnter(object? sender, EventArgs e)
    {
        BackColor = Color.LightGray;
    }

    public void OnMouseLeave(object? sender, EventArgs e)
    {
        BackColor = Color.DimGray;
    }
}