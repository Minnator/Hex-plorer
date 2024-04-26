namespace Hex_plorer.ControlExtensions;

public sealed class HexPanel : Panel
{
   public string Path { get; set; } = string.Empty;
   public string Name { get; set; } = string.Empty;
   public ItemType ItemType { get; set; } = ItemType.None;

   public HexPanel()
   {
      DoubleBuffered = true;
      Paint += OnPaint;
   }

   private void OnPaint(object? sender, PaintEventArgs e)
   {
      DrawHelper.DrawHex(e.Graphics, Width, Width);

      var font = new Font("VeraMono", 8);
      var brush = new SolidBrush(Color.Black);

      DrawHelper.DrawStringCenteredInRect(e.Graphics, Name, new Rectangle(0, Width, Width, Height - Width), font, brush);
   }
}