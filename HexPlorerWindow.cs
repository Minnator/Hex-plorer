using Hex_plorer.GuiHelper;
using System.Diagnostics;

namespace Hex_plorer;
public partial class HexPlorerWindow : Form
{
   public HexState HexState { get; set; } = new();
   public HexPlorerWindow()
   {
      InitializeComponent();

      ResizeBegin += WindowBeginResize;
      ResizeEnd += WindowEndResize;
      
      // Initialize the tree view
      FileTreeViewHelper.AddDisksToTreeView(this);
   }

   private void FileTreeView_AfterExpand(object sender, TreeViewEventArgs e)
   {
      if (e.Node == null)
         return;
      FileTreeViewHelper.OpenFolderFileTreeView(e.Node);
      if (!HexState.IsLoadingPath)
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

   public void NavigationButton_MouseDown(object? sender, MouseEventArgs e)
   {
      switch (e.Button)
      {
         // Mouse button 4 (back)
         case MouseButtons.XButton1:
            if (FolderHistory.GetCurrent() == 0)
            {
               FileTreeViewHelper.AddDisksToTreeView(this);
               return;
            }
            FileTreeViewHelper.NavigateTo(FolderHistory.NavigateBack(), this);
            break;
         // Mouse button 5 (forward)
         case MouseButtons.XButton2:
            FileTreeViewHelper.NavigateTo(FolderHistory.NavigateForward(), this);
            break;
      }
   }

   private void FileTreeView_Click(object sender, EventArgs e)
   {
      if (FileTreeView.SelectedNode == null)
         return;
      var nodeBelowCursor = FileTreeView.GetNodeAt(FileTreeView.PointToClient(Cursor.Position));
      ItemViewHelper.LoadItemView(nodeBelowCursor, this);
   }

   private void MatchCase_Click(object sender, EventArgs e) => MatchCase.Checked = !MatchCase.Checked;
   private void UseDeepSearch_Click(object sender, EventArgs e) => MatchCase.Checked = !MatchCase.Checked;
   private void UseRegex_Click(object sender, EventArgs e) => MatchCase.Checked = !MatchCase.Checked;
   private void MatchFullWord_Click(object sender, EventArgs e) => MatchCase.Checked = !MatchCase.Checked;
   private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
   {
      ItemDisplayModeSelection.SelectedItem = HexState.ItemDisplayMode.ToString();
   }

   private void ItemDisplayModeSelection_SelectedIndexChanged(object sender, EventArgs e)
   {
      HexState.ItemDisplayMode = (ItemDisplayMode)Enum.Parse(typeof(ItemDisplayMode), ItemDisplayModeSelection.SelectedItem?.ToString() ?? "List");
      ItemViewHelper.LoadItemView(FileTreeView.SelectedNode, this);
   }

   private void WindowBeginResize(object? sender, EventArgs e) => splitContainer1.SuspendLayout();
   private void WindowEndResize(object? sender, EventArgs e) => splitContainer1.ResumeLayout();



   // ------------------------ Methods ------------------------ \\

   public void SetPreview(string path)
   {
      if (HexState.LastPreviewPath.Equals(path))
         return;
      FilePreviewHelper.DisposeComponents(this);
      if (File.Exists(path))
         FilePreviewHelper.ShowPreview(path, this);
      else 
         ShowMessageInPreview("No file to preview");
   }

   private void ShowMessageInPreview(string text)
   {
      var g = ViewSplitContainer.Panel2.CreateGraphics();
      Debug.WriteLine ($"Showing message in Preview: {text}");
      DrawHelper.DrawStringCenteredInRect(g, text, new Rectangle(0, 0, ViewSplitContainer.Panel2.Width, ViewSplitContainer.Panel2.Height), HexState.DFont, Brushes.White);
   }
}
