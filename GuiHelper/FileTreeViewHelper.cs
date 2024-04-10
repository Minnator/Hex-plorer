using static Hex_plorer.State;

namespace Hex_plorer.GuiHelper;

public static class FileTreeViewHelper
{
   internal static void NavigateTo(string? path)
   {
      if (string.IsNullOrEmpty(path))
         return;
      IsLoadingPath = true;
      AddDisksToTreeView();
      var pathParts = path.Split(Path.DirectorySeparatorChar);

      foreach (var part in pathParts)
      {
         var currentNode = FindNodeInTree(HPWindow.FileTreeView.Nodes, part);
         if (currentNode == null)
            return;
         OpenFolderFileTreeView(currentNode);
      }
      IsLoadingPath = false;
   }

   // Find a node in the tree view RECURSIVELY
   private static TreeNode? FindNodeInTree(TreeNodeCollection nodes, string nodeText)
   {
      foreach (TreeNode node in nodes)
      {
         if (node.Text.Equals(nodeText, StringComparison.OrdinalIgnoreCase))
            return node;
         var foundNode = FindNodeInTree(node.Nodes, nodeText);
         if (foundNode != null)
            return foundNode;
      }
      return null;
   }

   // Add disks to the tree view
   internal static void AddDisksToTreeView()
   {
      HPWindow.FileTreeView.Nodes.Clear();
      foreach (var drive in DriveInfo.GetDrives())
      {
         // verify that the disc is connected to the computer
         if (!drive.IsReady)
            continue;
         var root = new TreeNode(drive.Name.Trim(Path.DirectorySeparatorChar));
         HPWindow.FileTreeView.Nodes.Add(root);
         root.Nodes.Add(new TreeNode());
      }

      HPWindow.FileTreeView.SelectedNode = null;
   }

   // Open the folder in the tree view and catch exceptions for unauthorized access and IO exceptions
   internal static void OpenFolderFileTreeView(TreeNode node)
   {
      node.Nodes.Clear();
      try
      {
         node.TreeView.BeginUpdate();
         foreach (var item in Directory.EnumerateDirectories(node.FullPath + Path.DirectorySeparatorChar))
         {
            node.Nodes.Add(Path.GetFileName(item));
            if (Directory.EnumerateDirectories(item).Any())
               node.Nodes[^1].Nodes.Add(new TreeNode());
            node.Expand();
         }
      }
      catch (UnauthorizedAccessException)
      {
      }
      catch (IOException)
      {
      }
      finally
      {
         node.TreeView.EndUpdate();
      }
   }

}