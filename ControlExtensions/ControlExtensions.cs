namespace Hex_plorer.ControlExtensions;

public static class ControlExtensions
{
   // Extension method to enable double buffering for a control
   public static void DoubleBuffered(this Control control, bool enable)
   {
      var prop = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
      prop?.SetValue(control, enable, null);
   }
}