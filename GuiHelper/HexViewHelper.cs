using System.Diagnostics;
using Hex_plorer.ControlExtensions;

namespace Hex_plorer;

public static class HexViewHelper
{
   public static void DisplayEmptyHex(string path, HexPlorerWindow window)
   {
      window.HexState.FlowPanelHexView?.Dispose();
      var flowPanel = new FlowLayoutPanel
      {
         Dock = DockStyle.Fill,
         AutoScroll = true,
         WrapContents = true,
         FlowDirection = FlowDirection.LeftToRight,
         Padding = new Padding(5),
      };

      foreach (var file in Directory.GetFiles(path))
      {
         if (File.Exists(file))
         {
            var type = File.GetAttributes(file) == FileAttributes.Directory ? ItemType.Directory : ItemType.File;
            var panel = GetHexPanel(file, type);
            flowPanel.Controls.Add(panel);
         }
         else
         {
            Debug.WriteLine($"File not found: {file}");
         }
      }

      foreach (var dir in Directory.GetDirectories(path))
      {
         var panel = GetHexPanel(dir, ItemType.Directory);
         panel.BackColor = Color.LightSkyBlue;
         flowPanel.Controls.Add(panel);
      }

      window.HexState.FlowPanelHexView = flowPanel;
      window.ViewSplitContainer.Panel1.Controls.Add(flowPanel);
   }

   private static HexPanel GetHexPanel(string path, ItemType type)
   {
      var panel = new HexPanel
      {
         Path = path,
         ItemType = type,
         Name = Path.GetFileName(path),
         Width = 100,
         Height = 130,
         BackColor = Color.DarkOliveGreen
      };
      return panel;
   }
}