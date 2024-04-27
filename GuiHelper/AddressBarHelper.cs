namespace Hex_plorer;

public static class AddressBarHelper
{
   public static void SetAddressBar(string path, HexPlorerWindow window)
   {
      var pathParts = path.Split('\\');
      window.AddressBar.Items.Clear();
      var prev = string.Empty;
      foreach (var part in pathParts)
      {
         if (string.IsNullOrEmpty(part))
            continue;
         prev += part + '\\';
         window.AddressBar.Items.Add(prev);
      }
      window.AddressBar.SelectedIndex = window.AddressBar.Items.Count - 1;
   }
}