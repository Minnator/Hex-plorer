using Hex_plorer.GuiHelper;

namespace Hex_plorer;
public partial class HexPlorerWindow : Form
{
   public HexPlorerWindow()
   {
      State.HPWindow = this;
      InitializeComponent();
      // Initialize the tree view
      FileTreeViewHelper.AddDisksToTreeView();
   }

   private void OpenFolderFileTreeView(object sender, EventArgs e)
   {
      FileTreeViewHelper.OpenFolderFileTreeView(FileTreeView.SelectedNode);
      FolderHistory.Add(FileTreeView.SelectedNode.FullPath);
   }

   private void FileTreeView_AfterExpand(object sender, TreeViewEventArgs e)
   {
      if (e.Node == null)
         return;
      FileTreeViewHelper.OpenFolderFileTreeView(e.Node);
      if (!State.IsLoadingPath)
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
               FileTreeViewHelper.AddDisksToTreeView();
               return;
            }
            FileTreeViewHelper.NavigateTo(FolderHistory.NavigateBack());
            break;
         // Mouse button 5 (forward)
         case MouseButtons.XButton2:
            FileTreeViewHelper.NavigateTo(FolderHistory.NavigateForward());
            break;
      }
   }

   private void FileTreeView_Click(object sender, EventArgs e)
   {
      if (FileTreeView.SelectedNode == null)
         return;
      var nodeBelowCursor = FileTreeView.GetNodeAt(FileTreeView.PointToClient(Cursor.Position));
      switch (State.ItemDisplayMode)
      {
         case ItemDisplayMode.Hex:
            break;
         case ItemDisplayMode.List:
            ItemViewHelper.DisplayList(nodeBelowCursor);
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }
   }
}
