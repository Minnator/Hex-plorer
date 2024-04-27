using System.Diagnostics;
using Hex_plorer.ControlExtensions;
using Hex_plorer.GuiElements;

namespace Hex_plorer;

public static class HexViewHelper
{
   public static void DisplayHex(string path, HexPlorerWindow window)
   {
      path += Path.DirectorySeparatorChar;
      window.HexState.FlowPanelHexView?.Dispose();
      var flowPanel = new FlowLayoutPanel
      {
         Dock = DockStyle.Fill,
         AutoScroll = true,
         WrapContents = true,
         FlowDirection = FlowDirection.LeftToRight,
         Padding = new Padding(5),
      };
      window.HexState.FlowPanelHexView = flowPanel;
      window.HexState.FlowPanelHexView!.DoubleBuffered(true);
      window.HexState.FlowPanelHexView!.SuspendLayout();

      foreach (var dir in DataHelper.GetAllDirectories(path)) 
         flowPanel.Controls.Add(GetHexLayoutPanel(dir.FullName, ItemType.Directory, window));

      foreach (var file in DataHelper.GetAllFiles(path)) 
         flowPanel.Controls.Add(GetHexLayoutPanel(file.FullName, ItemType.File, window));

      window.SuspendLayout();
      window.ViewSplitContainer.Panel1.Controls.Add(flowPanel);
      window.HexState.FlowPanelHexView.ResumeLayout(false);
      window.HexState.FlowPanelHexView.PerformLayout();
      window.ResumeLayout();
   }

   private static HexLayoutPanel GetHexLayoutPanel(string path, ItemType type, HexPlorerWindow window)
   {
      var panel = new HexLayoutPanel
      {
         BackColor = Color.DimGray,
         Padding = new Padding(1),
         Margin = new Padding(4),
         ColumnCount = 1,
         RowCount = 2,
         BorderStyle = BorderStyle.None,
         Width = 100,
         Height = 140,
         AutoSize = true
      };

      panel.SetContent(path, type, window);
      return panel;
   }

   public static HexPanel GetHexPanel(string path, ItemType type, HexPlorerWindow window, int width, int height)
   {
      var panel = new HexPanel(window)
      {
         Path = path,
         ItemType = type,
         EntryName = Path.GetFileName(path),
         Margin = new Padding(0),
         Width = width,
         Height = height,
         BackColor = Color.DimGray,
      };
      return panel;
   }

   public static HexTextBox GetTextBox(string path, string name, HexPlorerWindow window, int width, int height)
   {
      var textBox = new HexTextBox(window)
      {
         Path = path,
         Text = name,
         Multiline = true,
         ReadOnly = true,
         BackColor = Color.DimGray,
         ForeColor = Color.Black,
         Font = new Font("VeraMono", 8),
         BorderStyle = BorderStyle.None,
         ScrollBars = ScrollBars.None,
         Padding = new Padding(0),
         Margin = new Padding(0),
         TextAlign = HorizontalAlignment.Center,
         Width = width,
         Height = height
      };
      return textBox;
   }


}