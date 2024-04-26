namespace Hex_plorer.GuiElements;

public class HexTextBox : TextBox
{
   public string Path { get; set; } = string.Empty;
   public HexPlorerWindow Window { get; set; }

   public HexTextBox(HexPlorerWindow window)
   {
      Window = window;
      MouseEnter += OnMouseEnter;
      MouseLeave += OnMouseLeave;
   }

   public void OnMouseEnter(object? sender, EventArgs e)
   {
      Parent!.BackColor = Color.Aqua;
   }

   public void OnMouseLeave(object? sender, EventArgs e)
   {
      Parent!.BackColor = Color.DimGray;
   }

}