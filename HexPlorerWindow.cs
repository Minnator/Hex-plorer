using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hex_plorer;
public partial class HexPlorerWindow : Form
{
   private static bool _isDarkMode = false;
   private static bool _isLoadingPath = false;

   public HexPlorerWindow()
   {
      InitializeComponent();
      // Initialize the tree view
      AddDisksToTreeView();
   }

   // Add disks to the tree view
   private void AddDisksToTreeView()
   {
      FileTreeView.Nodes.Clear();
      foreach (var drive in DriveInfo.GetDrives())
      {
         // verify that the disc is connected to the computer
         if (!drive.IsReady)
            continue;
         var root = new TreeNode(drive.Name.Trim(Path.DirectorySeparatorChar));
         FileTreeView.Nodes.Add(root);
         root.Nodes.Add(new TreeNode());
      }
   }

   // Open the folder in the tree view and catch exceptions for unauthorized access and IO exceptions
   private void OpenFolderFileTreeView(TreeNode node)
   {
      node.Nodes.Clear();
      try
      {
         foreach (var item in Directory.EnumerateDirectories(node.FullPath + Path.DirectorySeparatorChar))
         {
            node.Nodes.Add(Path.GetFileName(item));
            if (Directory.EnumerateDirectories(item).Any())
               node.Nodes[^1].Nodes.Add(new TreeNode());
            node.Expand();
         }
      }
      catch (UnauthorizedAccessException) {}
      catch (IOException){}
   }

   private void NavigateTo(string? path)
   {
      if (string.IsNullOrEmpty(path))
         return;
      _isLoadingPath = true;
      AddDisksToTreeView();
      var pathParts = path.Split(Path.DirectorySeparatorChar);

      foreach (var part in pathParts)
      {
         var currentNode = FindNodeInTree(FileTreeView.Nodes, part);
         if (currentNode == null)
            return;
         OpenFolderFileTreeView(currentNode);
      }
      _isLoadingPath = false;
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


   private void OpenFolderFileTreeView(object sender, EventArgs e)
   {
      OpenFolderFileTreeView(FileTreeView.SelectedNode);
      FolderHistory.Add(FileTreeView.SelectedNode.FullPath);
   }
   
   private void FileTreeView_AfterExpand(object sender, TreeViewEventArgs e)
   {
      if (e.Node == null)
         return;
      OpenFolderFileTreeView(e.Node);
      if (!_isLoadingPath)
         FolderHistory.Add(e.Node.FullPath);
   }

   private void FileTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
   {
      if (e.Node == null) 
         return;
      e.Node.Nodes.Clear();
      e.Node.Nodes.Add(new TreeNode());
      FolderHistory.Add(e.Node.FullPath);
   }

   private void Form1_MouseDown(object sender, MouseEventArgs e)
   {
      switch (e.Button)
      {
         // Mouse button 4 (back)
         case MouseButtons.XButton1:
            if (FolderHistory.GetCurrent() == 0)
            {
               AddDisksToTreeView();
               return;
            }
            NavigateTo(FolderHistory.NavigateBack());
            break;
         // Mouse button 5 (forward)
         case MouseButtons.XButton2:
            NavigateTo(FolderHistory.NavigateForward());
            break;
      }
   }

}
