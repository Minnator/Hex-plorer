using Hex_plorer.Providers;

namespace Hex_plorer.Helpers;

public static class DirectoryViewHelper
{
   private static void AddRootNodes(this TreeView treeView, string[] rootNodes)
   {
      treeView.Nodes.Clear();
      foreach (var node in rootNodes)
      {
         var root = new TreeNode(node)
         {
            Tag = node
         };
         treeView.Nodes.Add(root);
      }
   }

   private static void AddChildNodes(this TreeNode node, string[] headers)
   {
      node.Nodes.Clear();
      foreach (var child in headers) 
         node.AddChildNode(child, node.Tag.ToString()!);
   }

   private static void AddChildNode(this TreeNode node, string header, string path)
   {
      var child = new TreeNode(header)
      {
         Tag = Path.Combine(path, header)
      };
      node.Nodes.Add(child);
   }

   private static void AddChildNodeWithIndicator(this TreeNode node, string header, string path)
   {
      node.AddChildNode(header, path);
      if (node.Nodes[^1].HasChildNodes())
         node.Nodes[^1].Nodes.Add(new TreeNode());
   }

   private static void AddChildNodesWithIndicator(this TreeNode node, string[] headers)
   {
      node.Nodes.Clear();
      foreach (var child in headers)
         node.AddChildNodeWithIndicator(child, node.Tag.ToString()!);
   }

   private static bool HasChildNodes(this TreeNode node)
   {
      if (node.Tag == null)
         return false;
      return DirectoryProvider.GetDirectories(node.Tag.ToString()!).Length > 0;
   }

   private static void CollapseNode(this TreeNode node)
   {
      var hasChildren = node.Nodes.Count > 0;
      node.Nodes.Clear();
      if (hasChildren)
         node.Nodes.Add(new TreeNode());
   }

   private static void ExpandNode(this TreeNode node)
   {
      node.Nodes.Clear();
      node.AddChildNodes(DirectoryProvider.GetAccessibleDirectories(node.Tag.ToString()!));
   }

   private static void ExpandNodeWithIndicator(this TreeNode node)
   {
      node.Nodes.Clear();
      node.AddChildNodesWithIndicator(DirectoryProvider.GetAccessibleDirectories(node.Tag.ToString()!));
   }

   // ================ Methods for expanding and collapsing nodes ================

   private static void UpdateTreeViewContent(this TreeView treeView, Action action)
   {
      treeView.SuspendLayout();
      treeView.BeginUpdate();
      action();
      treeView.ResumeLayout(false);
      treeView.PerformLayout();
      treeView.EndUpdate();
   }

   // ================ Public methods for interaction ================

   public static void ExpandRoots(this TreeView treeView)
   {
      treeView.UpdateTreeViewContent(() =>
      {
         treeView.AddRootNodes(DirectoryProvider.GetActiveDisks());
      });
   }

   public static void Expand(this TreeNode node, bool withIndicator = true)
   {
      UpdateTreeViewContent(node.TreeView, () =>
      {
         if (withIndicator)
            node.ExpandNodeWithIndicator();
         else
            node.ExpandNode();
      });
   }

   public static void Collapse(this TreeNode node)
   {
      UpdateTreeViewContent(node.TreeView, node.CollapseNode);
   }

}