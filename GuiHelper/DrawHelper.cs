namespace Hex_plorer;

public static class DrawHelper
{
   public static void DrawHex(Graphics g, int height, int width, Color color, int penWidth = 2, int padding = 1)
   {
      width -= padding;
      height -= padding;
      var w = penWidth / 2;
      var points = new[]
      {
         new Point(width / 2 - w + padding * 2, 0 + w + padding * 2),
         new Point(width - penWidth, height / 4 + penWidth),
         new Point(width - penWidth, height * 3 / 4),
         new Point(width / 2 - w + padding * 2, height - penWidth),
         new Point(0 + w + padding * 2, height * 3 / 4 + w),
         new Point(0 + w + padding * 2, height / 4 + w),
      };

      var pen = new Pen(color, penWidth);
      g.DrawPolygon(pen, points);
   }

   public static void DrawStringCenteredInRect(Graphics g, string text, Rectangle rect, Font font, Brush brush)
   {
      var size = g.MeasureString(text, font);
      var x = rect.X + (rect.Width - size.Width) / 2;
      var y = rect.Y + (rect.Height - size.Height) / 2;
      g.DrawString(text, font, brush, x, y);
   }


}