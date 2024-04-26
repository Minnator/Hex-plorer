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
         var panel = GetHexPanel(dir.FullName, ItemType.Directory, window);
         flowPanel.Controls.Add(panel);
      }

      foreach (var file in DataHelper.GetAllFiles(path))
      {
         var type = File.GetAttributes(file.FullName) == FileAttributes.Directory ? ItemType.Directory : ItemType.File;
         var panel = GetHexPanel(file.FullName, type, window);
         flowPanel.Controls.Add(panel);
      }

      window.HexState.FlowPanelHexView = flowPanel;
      window.ViewSplitContainer.Panel1.Controls.Add(flowPanel);
   }

   public static HexPanel GetHexPanel(string path, ItemType type, HexPlorerWindow window)
   {
      var panel = new HexPanel(window)
      {
         Path = path,
         ItemType = type,
         Name = Path.GetFileName(path),
         Width = 100,
         Height = 130,
         BackColor = Color.DimGray
      };
      return panel;
   }

   public static TextBox GetTextBox(string path, HexPlorerWindow window)
   {
      var textBox = new TextBox
      {
         Text = path,
         Dock = DockStyle.Fill,
         Multiline = true,
         ReadOnly = true,
         BackColor = Color.DimGray,
         ForeColor = Color.CadetBlue,
         Font = new Font("VeraMono", 8),
         BorderStyle = BorderStyle.None,
         ScrollBars = ScrollBars.None,
      };
      return textBox;
   }
}