namespace Hex_plorer.GuiElements;

public class HexLayoutPanel : TableLayoutPanel
{
   public HexPanel Panel { get; set; } = null!;
   public HexTextBox TextBox { get; set; } = null!;

   public HexLayoutPanel()
   {
      MouseEnter += OnMouseEnter;
      MouseLeave += OnMouseLeave;
   }

   public void SetContent(string path, ItemType type, HexPlorerWindow window)
   {
      
      Panel = HexViewHelper.GetHexPanel(path, type, window, Width - Padding.All * 2, Width - Padding.All * 2);
      TextBox = HexViewHelper.GetTextBox(path, Panel.EntryName, window, Width - Padding.All * 2, Height - Width);

      Controls.Add(Panel, 0, 0);
      Controls.Add(TextBox, 0, 1);

   }

   public void OnMouseEnter(object? sender, EventArgs e)
   {
      Highlight();
   }

   public void OnMouseLeave(object? sender, EventArgs e)
   {
      UnHighlight();
   }

   public void Highlight()
   {
      BackColor = Color.Aqua;
   }

   public void UnHighlight()
   {
      BackColor = Color.DimGray;
   }
}