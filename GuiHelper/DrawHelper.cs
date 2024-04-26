namespace Hex_plorer;

public static class DrawHelper
{
   public static void DrawHex(Graphics g, int height, int width, int penWidth = 2)
   {
      var w = penWidth / 2;
      var points = new[]
      {
         new Point(width / 2 + w, 0 + w),
         new Point(width - w, height / 4 + w),
         new Point(width - w, height * 3 / 4 + w),
         new Point(width / 2 + w, height - penWidth),
         new Point(0 + w, height * 3 / 4 + w),
         new Point(0 + w, height / 4 + w),
      };

      var pen = new Pen(Color.Black, penWidth);
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