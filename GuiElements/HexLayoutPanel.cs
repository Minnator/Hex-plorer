namespace Hex_plorer.GuiElements;

public sealed class HexLayoutPanel : TableLayoutPanel
{
   public HexPanel Panel { get; set; }
   public TextBox TextBox { get; set; }

   public HexLayoutPanel(string path, ItemType type, HexPlorerWindow window)
   {
      Panel = HexViewHelper.GetHexPanel(path, type, window);
      TextBox = HexViewHelper.GetTextBox(path, window);
      
      ColumnCount = 1;
      RowCount = 2;
      Dock = DockStyle.Fill;
      Padding = new Padding(2);
      BackColor = Color.DimGray;

      Controls.Add(Panel, 0, 0);
      Controls.Add(TextBox, 0, 1);
   }

   public void OnMouseEnter(object? sender, EventArgs e)
   {
      Panel.BackColor = Color.LightGray;
   }


}