using Hex_plorer.GuiHelper;
using System.Diagnostics;

namespace Hex_plorer;
public partial class HexPlorerWindow : Form
{
   public HexState HexState { get; set; } = new();
   public Navigation Nav { get; set; }
   public HexPlorerWindow()
   {
      Nav = new(10, this);
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
         Nav.AddToHistory(e.Node.FullPath);
   }

   private void FileTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
   {
      if (e.Node == null)
         return;
      e.Node.Nodes.Clear();
      e.Node.Nodes.Add(new TreeNode());
      Nav.AddToHistory(e.Node.FullPath);
   }

   public void NavigationButton_MouseDown(object? sender, MouseEventArgs e)
   {
      switch (e.Button)
      {
         // Mouse button 4 (back)
         case MouseButtons.XButton1:
            if (Nav.Current == 0)
            {
               FileTreeViewHelper.AddDisksToTreeView(this);
               return;
            }
            FileTreeViewHelper.NavigateTo(Nav.NavigateBack(), this);
            break;
         // Mouse button 5 (forward)
         case MouseButtons.XButton2:
            FileTreeViewHelper.NavigateTo(Nav.NavigateForward(), this);
            break;
      }
   }

   private void FileTreeView_Click(object sender, EventArgs e)
   {
      if (FileTreeView.SelectedNode == null)
         return;
      var nodeBelowCursor = FileTreeView.GetNodeAt(FileTreeView.PointToClient(Cursor.Position));
      Nav.NavigateTo(nodeBelowCursor.FullPath);
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
      if (FileTreeView.SelectedNode == null)
         return;
      ItemViewHelper.LoadItemView(FileTreeView.SelectedNode.FullPath, this);
   }

   private void WindowBeginResize(object? sender, EventArgs e) => splitContainer1.SuspendLayout();
   private void WindowEndResize(object? sender, EventArgs e) => splitContainer1.ResumeLayout();

   private void SelectedAddressChange(object? sender, EventArgs e)
   {
      AddressBar.Text = AddressBar.Items[AddressBar.SelectedIndex]?.ToString();
      if (string.IsNullOrEmpty(AddressBar.Text))
         return;
      Debug.WriteLine($"Navigating to: {AddressBar.Text}");
      Nav.NavigateTo(AddressBar.Text);
   }

   // ------------------------ Key Logic ------------------------ \\

   private void KeyLogic(object sender, KeyEventArgs e)
   {
      //TODO fix this
      if (e.Control && e.KeyCode == Keys.F)
         Debug.WriteLine("Ctrl + F pressed");
      switch (e.Modifiers)
      {
         case Keys.Control:
            switch (e.KeyCode)
            {
               case Keys.F:
                  SearchBox.Focus();
                  SearchBox.SelectionStart = 0;
                  SearchBox.SelectionLength = SearchBox.Text.Length;
                  break;
            }
            break;
      }
   }


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
      Debug.WriteLine($"Showing message in Preview: {text}");
      DrawHelper.DrawStringCenteredInRect(g, text, new Rectangle(0, 0, ViewSplitContainer.Panel2.Width, ViewSplitContainer.Panel2.Height), HexState.DFont, Brushes.White);
   }

   private void SearchBox_KeyDown(object sender, KeyEventArgs e)
   {
      return;
      if (e.KeyCode == Keys.Enter)
      {
         e.Handled = true;
         e.SuppressKeyPress = true;
         Debug.WriteLine("Searching for: " + SearchBox.Text);
      }
   }

   private void SearchBox_TextChanged(object sender, EventArgs e)
   {

   }
}
