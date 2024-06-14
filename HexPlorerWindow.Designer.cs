namespace Hex_plorer;

partial class HexPlorerWindow
{
   /// <summary>
   /// Required designer variable.
   /// </summary>
   private System.ComponentModel.IContainer components = null;

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   protected override void Dispose(bool disposing)
   {
      if (disposing && (components != null))
      {
         components.Dispose();
      }
      base.Dispose(disposing);
   }

   #region Windows Form Designer generated code

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   private void InitializeComponent()
   {
      components = new System.ComponentModel.Container();
      SearchOptionsStrip = new ContextMenuStrip(components);
      UseDeepSearch = new ToolStripMenuItem();
      MatchCase = new ToolStripMenuItem();
      UseRegex = new ToolStripMenuItem();
      MatchFullWord = new ToolStripMenuItem();
      tableLayoutPanel1 = new TableLayoutPanel();
      splitContainer1 = new SplitContainer();
      FileTreeView = new TreeView();
      ViewSplitContainer = new SplitContainer();
      PreviewPanel = new Panel();
      tableLayoutPanel2 = new TableLayoutPanel();
      button1 = new Button();
      button2 = new Button();
      button3 = new Button();
      button4 = new Button();
      tableLayoutPanel3 = new TableLayoutPanel();
      tableLayoutPanel4 = new TableLayoutPanel();
      SearchBox = new TextBox();
      button5 = new Button();
      AddressBar = new ComboBox();
      DirectoryContextMenu = new ContextMenuStrip(components);
      openFolderToolStripMenuItem = new ToolStripMenuItem();
      openInNewWindowToolStripMenuItem = new ToolStripMenuItem();
      toolStripSeparator1 = new ToolStripSeparator();
      copyToolStripMenuItem = new ToolStripMenuItem();
      cutToolStripMenuItem = new ToolStripMenuItem();
      deleteToolStripMenuItem = new ToolStripMenuItem();
      renameToolStripMenuItem = new ToolStripMenuItem();
      toolStripSeparator2 = new ToolStripSeparator();
      createShortcutToolStripMenuItem1 = new ToolStripMenuItem();
      toolStripSeparator3 = new ToolStripSeparator();
      propertiesToolStripMenuItem = new ToolStripMenuItem();
      FileContextMenu = new ContextMenuStrip(components);
      openToolStripMenuItem = new ToolStripMenuItem();
      openWithToolStripMenuItem = new ToolStripMenuItem();
      toolStripSeparator4 = new ToolStripSeparator();
      copyToolStripMenuItem1 = new ToolStripMenuItem();
      cutToolStripMenuItem1 = new ToolStripMenuItem();
      deleteToolStripMenuItem1 = new ToolStripMenuItem();
      renameToolStripMenuItem1 = new ToolStripMenuItem();
      toolStripSeparator5 = new ToolStripSeparator();
      createShortcutToolStripMenuItem = new ToolStripMenuItem();
      toolStripSeparator6 = new ToolStripSeparator();
      propertiesToolStripMenuItem1 = new ToolStripMenuItem();
      MainMenuStrip = new MenuStrip();
      viewToolStripMenuItem = new ToolStripMenuItem();
      ItemDisplayModeSelection = new ToolStripComboBox();
      SearchOptionsStrip.SuspendLayout();
      tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)ViewSplitContainer).BeginInit();
      ViewSplitContainer.Panel2.SuspendLayout();
      ViewSplitContainer.SuspendLayout();
      tableLayoutPanel2.SuspendLayout();
      tableLayoutPanel3.SuspendLayout();
      tableLayoutPanel4.SuspendLayout();
      DirectoryContextMenu.SuspendLayout();
      FileContextMenu.SuspendLayout();
      MainMenuStrip.SuspendLayout();
      SuspendLayout();
      // 
      // SearchOptionsStrip
      // 
      SearchOptionsStrip.Items.AddRange(new ToolStripItem[] { UseDeepSearch, MatchCase, UseRegex, MatchFullWord });
      SearchOptionsStrip.Name = "SearchOptionsStrip";
      SearchOptionsStrip.Size = new Size(149, 92);
      // 
      // UseDeepSearch
      // 
      UseDeepSearch.Checked = true;
      UseDeepSearch.CheckState = CheckState.Checked;
      UseDeepSearch.Name = "UseDeepSearch";
      UseDeepSearch.Size = new Size(148, 22);
      UseDeepSearch.Text = "Deep Search";
      UseDeepSearch.Click += UseDeepSearch_Click;
      // 
      // MatchCase
      // 
      MatchCase.Name = "MatchCase";
      MatchCase.Size = new Size(148, 22);
      MatchCase.Text = "Case Sensitive";
      MatchCase.Click += MatchCase_Click;
      // 
      // UseRegex
      // 
      UseRegex.Name = "UseRegex";
      UseRegex.Size = new Size(148, 22);
      UseRegex.Text = "Regex";
      UseRegex.Click += UseRegex_Click;
      // 
      // MatchFullWord
      // 
      MatchFullWord.Name = "MatchFullWord";
      MatchFullWord.Size = new Size(148, 22);
      MatchFullWord.Text = "Full Word";
      MatchFullWord.Click += MatchFullWord_Click;
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      tableLayoutPanel1.BackColor = SystemColors.ActiveCaptionText;
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel1.Location = new Point(0, 24);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle());
      tableLayoutPanel1.Size = new Size(1156, 673);
      tableLayoutPanel1.TabIndex = 1;
      // 
      // splitContainer1
      // 
      splitContainer1.BackColor = SystemColors.ActiveCaptionText;
      splitContainer1.Dock = DockStyle.Fill;
      splitContainer1.FixedPanel = FixedPanel.Panel1;
      splitContainer1.Location = new Point(3, 33);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(FileTreeView);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(ViewSplitContainer);
      splitContainer1.Size = new Size(1150, 637);
      splitContainer1.SplitterDistance = 250;
      splitContainer1.TabIndex = 0;
      splitContainer1.TabStop = false;
      // 
      // FileTreeView
      // 
      FileTreeView.BackColor = SystemColors.ControlDarkDark;
      FileTreeView.Dock = DockStyle.Fill;
      FileTreeView.FullRowSelect = true;
      FileTreeView.HotTracking = true;
      FileTreeView.Location = new Point(0, 0);
      FileTreeView.Margin = new Padding(0);
      FileTreeView.Name = "FileTreeView";
      FileTreeView.Size = new Size(250, 637);
      FileTreeView.TabIndex = 0;
      FileTreeView.AfterCollapse += FileTreeView_AfterCollapse;
      FileTreeView.AfterExpand += FileTreeView_AfterExpand;
      FileTreeView.Click += FileTreeView_Click;
      FileTreeView.MouseDown += NavigationButton_MouseDown;
      // 
      // ViewSplitContainer
      // 
      ViewSplitContainer.Dock = DockStyle.Fill;
      ViewSplitContainer.Location = new Point(0, 0);
      ViewSplitContainer.Margin = new Padding(0);
      ViewSplitContainer.Name = "ViewSplitContainer";
      // 
      // ViewSplitContainer.Panel1
      // 
      ViewSplitContainer.Panel1.BackColor = SystemColors.ControlDarkDark;
      // 
      // ViewSplitContainer.Panel2
      // 
      ViewSplitContainer.Panel2.Controls.Add(PreviewPanel);
      ViewSplitContainer.Size = new Size(896, 637);
      ViewSplitContainer.SplitterDistance = 700;
      ViewSplitContainer.TabIndex = 0;
      // 
      // PreviewPanel
      // 
      PreviewPanel.BackColor = SystemColors.ControlDarkDark;
      PreviewPanel.BorderStyle = BorderStyle.FixedSingle;
      PreviewPanel.Dock = DockStyle.Fill;
      PreviewPanel.Location = new Point(0, 0);
      PreviewPanel.Name = "PreviewPanel";
      PreviewPanel.Size = new Size(192, 637);
      PreviewPanel.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      tableLayoutPanel2.ColumnCount = 5;
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
      tableLayoutPanel2.Controls.Add(button1, 0, 0);
      tableLayoutPanel2.Controls.Add(button2, 1, 0);
      tableLayoutPanel2.Controls.Add(button3, 2, 0);
      tableLayoutPanel2.Controls.Add(button4, 3, 0);
      tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 4, 0);
      tableLayoutPanel2.Dock = DockStyle.Fill;
      tableLayoutPanel2.Location = new Point(0, 0);
      tableLayoutPanel2.Margin = new Padding(0);
      tableLayoutPanel2.Name = "tableLayoutPanel2";
      tableLayoutPanel2.RowCount = 1;
      tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel2.Size = new Size(1156, 30);
      tableLayoutPanel2.TabIndex = 1;
      // 
      // button1
      // 
      button1.Dock = DockStyle.Fill;
      button1.Location = new Point(0, 0);
      button1.Margin = new Padding(0);
      button1.Name = "button1";
      button1.Size = new Size(30, 30);
      button1.TabIndex = 0;
      button1.Text = "<";
      button1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      button2.Dock = DockStyle.Fill;
      button2.Location = new Point(30, 0);
      button2.Margin = new Padding(0);
      button2.Name = "button2";
      button2.Size = new Size(30, 30);
      button2.TabIndex = 1;
      button2.Text = ">";
      button2.UseVisualStyleBackColor = true;
      // 
      // button3
      // 
      button3.Dock = DockStyle.Fill;
      button3.Location = new Point(60, 0);
      button3.Margin = new Padding(0);
      button3.Name = "button3";
      button3.Size = new Size(30, 30);
      button3.TabIndex = 2;
      button3.Text = "v";
      button3.UseVisualStyleBackColor = true;
      // 
      // button4
      // 
      button4.Dock = DockStyle.Fill;
      button4.Location = new Point(90, 0);
      button4.Margin = new Padding(0);
      button4.Name = "button4";
      button4.Size = new Size(30, 30);
      button4.TabIndex = 3;
      button4.Text = "up";
      button4.UseVisualStyleBackColor = true;
      // 
      // tableLayoutPanel3
      // 
      tableLayoutPanel3.BackColor = SystemColors.WindowFrame;
      tableLayoutPanel3.ColumnCount = 2;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
      tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 1, 0);
      tableLayoutPanel3.Controls.Add(AddressBar, 0, 0);
      tableLayoutPanel3.Dock = DockStyle.Fill;
      tableLayoutPanel3.Location = new Point(120, 0);
      tableLayoutPanel3.Margin = new Padding(0);
      tableLayoutPanel3.Name = "tableLayoutPanel3";
      tableLayoutPanel3.RowCount = 1;
      tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel3.Size = new Size(1036, 30);
      tableLayoutPanel3.TabIndex = 4;
      // 
      // tableLayoutPanel4
      // 
      tableLayoutPanel4.ColumnCount = 2;
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
      tableLayoutPanel4.Controls.Add(SearchBox, 0, 0);
      tableLayoutPanel4.Controls.Add(button5, 1, 0);
      tableLayoutPanel4.Dock = DockStyle.Fill;
      tableLayoutPanel4.Location = new Point(725, 0);
      tableLayoutPanel4.Margin = new Padding(0);
      tableLayoutPanel4.Name = "tableLayoutPanel4";
      tableLayoutPanel4.RowCount = 1;
      tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
      tableLayoutPanel4.Size = new Size(311, 30);
      tableLayoutPanel4.TabIndex = 0;
      // 
      // SearchBox
      // 
      SearchBox.BackColor = SystemColors.ControlDark;
      SearchBox.ContextMenuStrip = SearchOptionsStrip;
      SearchBox.Dock = DockStyle.Fill;
      SearchBox.Location = new Point(3, 3);
      SearchBox.Name = "SearchBox";
      SearchBox.PlaceholderText = "Search x";
      SearchBox.Size = new Size(275, 23);
      SearchBox.TabIndex = 0;
      SearchBox.TextChanged += SearchBox_TextChanged;
      SearchBox.KeyDown += SearchBox_KeyDown;
      // 
      // button5
      // 
      button5.Dock = DockStyle.Fill;
      button5.Location = new Point(284, 3);
      button5.Name = "button5";
      button5.Size = new Size(24, 24);
      button5.TabIndex = 1;
      button5.Text = "X";
      button5.UseVisualStyleBackColor = true;
      // 
      // AddressBar
      // 
      AddressBar.BackColor = SystemColors.ControlDark;
      AddressBar.Dock = DockStyle.Fill;
      AddressBar.FlatStyle = FlatStyle.Popup;
      AddressBar.FormattingEnabled = true;
      AddressBar.Location = new Point(3, 3);
      AddressBar.Name = "AddressBar";
      AddressBar.Size = new Size(719, 23);
      AddressBar.TabIndex = 1;
      AddressBar.SelectionChangeCommitted += SelectedAddressChange;
      // 
      // DirectoryContextMenu
      // 
      DirectoryContextMenu.Items.AddRange(new ToolStripItem[] { openFolderToolStripMenuItem, openInNewWindowToolStripMenuItem, toolStripSeparator1, copyToolStripMenuItem, cutToolStripMenuItem, deleteToolStripMenuItem, renameToolStripMenuItem, toolStripSeparator2, createShortcutToolStripMenuItem1, toolStripSeparator3, propertiesToolStripMenuItem });
      DirectoryContextMenu.Name = "DirectoryContextMenu";
      DirectoryContextMenu.Size = new Size(189, 198);
      // 
      // openFolderToolStripMenuItem
      // 
      openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
      openFolderToolStripMenuItem.Size = new Size(188, 22);
      openFolderToolStripMenuItem.Text = "Open folder";
      // 
      // openInNewWindowToolStripMenuItem
      // 
      openInNewWindowToolStripMenuItem.Name = "openInNewWindowToolStripMenuItem";
      openInNewWindowToolStripMenuItem.Size = new Size(188, 22);
      openInNewWindowToolStripMenuItem.Text = "Open in new Window";
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new Size(185, 6);
      // 
      // copyToolStripMenuItem
      // 
      copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      copyToolStripMenuItem.Size = new Size(188, 22);
      copyToolStripMenuItem.Text = "Copy";
      // 
      // cutToolStripMenuItem
      // 
      cutToolStripMenuItem.Name = "cutToolStripMenuItem";
      cutToolStripMenuItem.Size = new Size(188, 22);
      cutToolStripMenuItem.Text = "Cut";
      // 
      // deleteToolStripMenuItem
      // 
      deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      deleteToolStripMenuItem.Size = new Size(188, 22);
      deleteToolStripMenuItem.Text = "Delete";
      // 
      // renameToolStripMenuItem
      // 
      renameToolStripMenuItem.Name = "renameToolStripMenuItem";
      renameToolStripMenuItem.Size = new Size(188, 22);
      renameToolStripMenuItem.Text = "Rename";
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new Size(185, 6);
      // 
      // createShortcutToolStripMenuItem1
      // 
      createShortcutToolStripMenuItem1.Name = "createShortcutToolStripMenuItem1";
      createShortcutToolStripMenuItem1.Size = new Size(188, 22);
      createShortcutToolStripMenuItem1.Text = "Create Shortcut";
      // 
      // toolStripSeparator3
      // 
      toolStripSeparator3.Name = "toolStripSeparator3";
      toolStripSeparator3.Size = new Size(185, 6);
      // 
      // propertiesToolStripMenuItem
      // 
      propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
      propertiesToolStripMenuItem.Size = new Size(188, 22);
      propertiesToolStripMenuItem.Text = "Properties";
      // 
      // FileContextMenu
      // 
      FileContextMenu.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, openWithToolStripMenuItem, toolStripSeparator4, copyToolStripMenuItem1, cutToolStripMenuItem1, deleteToolStripMenuItem1, renameToolStripMenuItem1, toolStripSeparator5, createShortcutToolStripMenuItem, toolStripSeparator6, propertiesToolStripMenuItem1 });
      FileContextMenu.Name = "FileContextMenu";
      FileContextMenu.Size = new Size(157, 198);
      // 
      // openToolStripMenuItem
      // 
      openToolStripMenuItem.Name = "openToolStripMenuItem";
      openToolStripMenuItem.Size = new Size(156, 22);
      openToolStripMenuItem.Text = "Open";
      // 
      // openWithToolStripMenuItem
      // 
      openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
      openWithToolStripMenuItem.Size = new Size(156, 22);
      openWithToolStripMenuItem.Text = "Open With";
      // 
      // toolStripSeparator4
      // 
      toolStripSeparator4.Name = "toolStripSeparator4";
      toolStripSeparator4.Size = new Size(153, 6);
      // 
      // copyToolStripMenuItem1
      // 
      copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
      copyToolStripMenuItem1.Size = new Size(156, 22);
      copyToolStripMenuItem1.Text = "Copy";
      // 
      // cutToolStripMenuItem1
      // 
      cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
      cutToolStripMenuItem1.Size = new Size(156, 22);
      cutToolStripMenuItem1.Text = "Cut";
      // 
      // deleteToolStripMenuItem1
      // 
      deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
      deleteToolStripMenuItem1.Size = new Size(156, 22);
      deleteToolStripMenuItem1.Text = "Delete";
      // 
      // renameToolStripMenuItem1
      // 
      renameToolStripMenuItem1.Name = "renameToolStripMenuItem1";
      renameToolStripMenuItem1.Size = new Size(156, 22);
      renameToolStripMenuItem1.Text = "Rename";
      // 
      // toolStripSeparator5
      // 
      toolStripSeparator5.Name = "toolStripSeparator5";
      toolStripSeparator5.Size = new Size(153, 6);
      // 
      // createShortcutToolStripMenuItem
      // 
      createShortcutToolStripMenuItem.Name = "createShortcutToolStripMenuItem";
      createShortcutToolStripMenuItem.Size = new Size(156, 22);
      createShortcutToolStripMenuItem.Text = "Create Shortcut";
      // 
      // toolStripSeparator6
      // 
      toolStripSeparator6.Name = "toolStripSeparator6";
      toolStripSeparator6.Size = new Size(153, 6);
      // 
      // propertiesToolStripMenuItem1
      // 
      propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
      propertiesToolStripMenuItem1.Size = new Size(156, 22);
      propertiesToolStripMenuItem1.Text = "Properties";
      // 
      // MainMenuStrip
      // 
      MainMenuStrip.BackColor = SystemColors.ControlDarkDark;
      MainMenuStrip.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
      MainMenuStrip.Location = new Point(0, 0);
      MainMenuStrip.Name = "MainMenuStrip";
      MainMenuStrip.Size = new Size(1156, 24);
      MainMenuStrip.TabIndex = 3;
      MainMenuStrip.Text = "menuStrip1";
      // 
      // viewToolStripMenuItem
      // 
      viewToolStripMenuItem.BackColor = SystemColors.ControlDarkDark;
      viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ItemDisplayModeSelection });
      viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      viewToolStripMenuItem.Size = new Size(44, 20);
      viewToolStripMenuItem.Text = "View";
      viewToolStripMenuItem.DropDownOpening += viewToolStripMenuItem_DropDownOpening;
      // 
      // ItemDisplayModeSelection
      // 
      ItemDisplayModeSelection.BackColor = SystemColors.ControlDark;
      ItemDisplayModeSelection.DropDownStyle = ComboBoxStyle.DropDownList;
      ItemDisplayModeSelection.Items.AddRange(new object[] { "List", "Hex" });
      ItemDisplayModeSelection.Name = "ItemDisplayModeSelection";
      ItemDisplayModeSelection.Size = new Size(121, 23);
      ItemDisplayModeSelection.SelectedIndexChanged += ItemDisplayModeSelection_SelectedIndexChanged;
      // 
      // HexPlorerWindow
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1156, 697);
      Controls.Add(tableLayoutPanel1);
      Controls.Add(MainMenuStrip);
      Name = "HexPlorerWindow";
      Text = "Hex-Plorer";
      KeyDown += KeyLogic;
      MouseDown += NavigationButton_MouseDown;
      SearchOptionsStrip.ResumeLayout(false);
      tableLayoutPanel1.ResumeLayout(false);
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
      splitContainer1.ResumeLayout(false);
      ViewSplitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)ViewSplitContainer).EndInit();
      ViewSplitContainer.ResumeLayout(false);
      tableLayoutPanel2.ResumeLayout(false);
      tableLayoutPanel3.ResumeLayout(false);
      tableLayoutPanel4.ResumeLayout(false);
      tableLayoutPanel4.PerformLayout();
      DirectoryContextMenu.ResumeLayout(false);
      FileContextMenu.ResumeLayout(false);
      MainMenuStrip.ResumeLayout(false);
      MainMenuStrip.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
   }

   #endregion
   internal ContextMenuStrip SearchOptionsStrip;
   internal ToolStripMenuItem UseDeepSearch;
   internal ToolStripMenuItem MatchCase;
   internal ToolStripMenuItem UseRegex;
   internal ToolStripMenuItem MatchFullWord;
   private TableLayoutPanel tableLayoutPanel1;
   private SplitContainer splitContainer1;
   public TreeView FileTreeView;
   public SplitContainer ViewSplitContainer;
   private Panel PreviewPanel;
   private TableLayoutPanel tableLayoutPanel2;
   private Button button1;
   private Button button2;
   private Button button3;
   private Button button4;
   private TableLayoutPanel tableLayoutPanel3;
   private TableLayoutPanel tableLayoutPanel4;
   private TextBox SearchBox;
   private Button button5;
   public ComboBox AddressBar;
   public ContextMenuStrip DirectoryContextMenu;
   private ToolStripMenuItem openFolderToolStripMenuItem;
   private ToolStripMenuItem openInNewWindowToolStripMenuItem;
   private ToolStripSeparator toolStripSeparator1;
   private ToolStripMenuItem copyToolStripMenuItem;
   private ToolStripMenuItem cutToolStripMenuItem;
   private ToolStripMenuItem deleteToolStripMenuItem;
   private ToolStripMenuItem renameToolStripMenuItem;
   private ToolStripSeparator toolStripSeparator2;
   public ContextMenuStrip FileContextMenu;
   private ToolStripMenuItem propertiesToolStripMenuItem;
   private ToolStripSeparator toolStripSeparator3;
   private ToolStripMenuItem createShortcutToolStripMenuItem1;
   private ToolStripMenuItem openToolStripMenuItem;
   private ToolStripMenuItem openWithToolStripMenuItem;
   private ToolStripSeparator toolStripSeparator4;
   private ToolStripMenuItem copyToolStripMenuItem1;
   private ToolStripMenuItem cutToolStripMenuItem1;
   private ToolStripMenuItem deleteToolStripMenuItem1;
   private ToolStripMenuItem renameToolStripMenuItem1;
   private ToolStripSeparator toolStripSeparator5;
   private ToolStripMenuItem createShortcutToolStripMenuItem;
   private ToolStripSeparator toolStripSeparator6;
   private ToolStripMenuItem propertiesToolStripMenuItem1;
   private MenuStrip MainMenuStrip;
   private ToolStripMenuItem viewToolStripMenuItem;
   private ToolStripComboBox ItemDisplayModeSelection;
}