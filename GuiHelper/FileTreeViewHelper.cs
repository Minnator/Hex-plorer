using static Hex_plorer.State;

namespace Hex_plorer.GuiHelper;

public static class FileTreeViewHelper
{
   internal static TreeNode? NavigateTo(string? path)
   {
      if (string.IsNullOrEmpty(path))
         return null;
      IsLoadingPath = true;
      AddDisksToTreeView();
      var pathParts = path.Split(Path.DirectorySeparatorChar);
      TreeNode? currentNode = null;

      foreach (var part in pathParts)
      {
         currentNode = FindNodeInTree(HPWindow.FileTreeView.Nodes, part);
         if (currentNode == null)
            continue;
         OpenFolderFileTreeView(currentNode);
      }
      IsLoadingPath = false;
      return currentNode;
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
      node.TreeView.BeginUpdate();
      foreach (var item in Directory.EnumerateDirectories(node.FullPath + Path.DirectorySeparatorChar))
      {
         try
         {
            node.Nodes.Add(Path.GetFileName(item));
            if (Directory.EnumerateDirectories(item).Any())
               node.Nodes[^1].Nodes.Add(new TreeNode());
            node.Expand();
         }
         catch (UnauthorizedAccessException) { }
         catch (IOException) { }
      }
      node.TreeView.EndUpdate();
   }

}