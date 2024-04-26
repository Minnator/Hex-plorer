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

      foreach (var dir in DataHelper.GetAllDirectories(path))
      {
         var panel= GetHexLayoutPanel(dir.FullName, ItemType.Directory, window);
         flowPanel.Controls.Add(panel);
      }

      foreach (var file in DataHelper.GetAllFiles(path))
      {
         var type = File.GetAttributes(file.FullName) == FileAttributes.Directory ? ItemType.Directory : ItemType.File;
         var panel = GetHexLayoutPanel(file.FullName, type, window);
         flowPanel.Controls.Add(panel);
      }

      window.HexState.FlowPanelHexView = flowPanel;
      window.ViewSplitContainer.Panel1.Controls.Add(flowPanel);
   }

   private static HexLayoutPanel GetHexLayoutPanel(string path, ItemType type, HexPlorerWindow window)
   {
      var panel = new HexLayoutPanel();
      panel.BackColor = Color.DimGray;
      panel.Padding = new Padding(1);
      panel.Margin = new Padding(4);
      panel.ColumnCount = 1;
      panel.RowCount = 2;
      panel.BorderStyle = BorderStyle.FixedSingle;
      panel.Width = 100;
      panel.Height = 140;
      
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
         BackColor = Color.DimGray
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
         ForeColor = Color.CadetBlue,
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