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
      textBox1 = new TextBox();
      button5 = new Button();
      comboBox1 = new ComboBox();
      toolStripContainer1 = new ToolStripContainer();
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
      toolStripContainer1.ContentPanel.SuspendLayout();
      toolStripContainer1.SuspendLayout();
      SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.ColumnCount = 1;
      tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
      tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
      tableLayoutPanel1.Dock = DockStyle.Fill;
      tableLayoutPanel1.Location = new Point(0, 0);
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 2;
      tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
      tableLayoutPanel1.RowStyles.Add(new RowStyle());
      tableLayoutPanel1.Size = new Size(1156, 697);
      tableLayoutPanel1.TabIndex = 0;
      // 
      // splitContainer1
      // 
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
      splitContainer1.Size = new Size(1150, 661);
      splitContainer1.SplitterDistance = 250;
      splitContainer1.TabIndex = 0;
      splitContainer1.TabStop = false;
      // 
      // FileTreeView
      // 
      FileTreeView.Dock = DockStyle.Fill;
      FileTreeView.FullRowSelect = true;
      FileTreeView.HotTracking = true;
      FileTreeView.Location = new Point(0, 0);
      FileTreeView.Margin = new Padding(0);
      FileTreeView.Name = "FileTreeView";
      FileTreeView.Size = new Size(250, 661);
      FileTreeView.TabIndex = 0;
      FileTreeView.AfterCollapse += FileTreeView_AfterCollapse;
      FileTreeView.AfterExpand += FileTreeView_AfterExpand;
      FileTreeView.Click += FileTreeView_Click;
      FileTreeView.DoubleClick += OpenFolderFileTreeView;
      FileTreeView.MouseDown += NavigationButton_MouseDown;
      // 
      // ViewSplitContainer
      // 
      ViewSplitContainer.Dock = DockStyle.Fill;
      ViewSplitContainer.Location = new Point(0, 0);
      ViewSplitContainer.Margin = new Padding(0);
      ViewSplitContainer.Name = "ViewSplitContainer";
      // 
      // ViewSplitContainer.Panel2
      // 
      ViewSplitContainer.Panel2.Controls.Add(PreviewPanel);
      ViewSplitContainer.Size = new Size(896, 661);
      ViewSplitContainer.SplitterDistance = 700;
      ViewSplitContainer.TabIndex = 0;
      // 
      // PreviewPanel
      // 
      PreviewPanel.BorderStyle = BorderStyle.FixedSingle;
      PreviewPanel.Dock = DockStyle.Fill;
      PreviewPanel.Location = new Point(0, 0);
      PreviewPanel.Name = "PreviewPanel";
      PreviewPanel.Size = new Size(192, 661);
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
      tableLayoutPanel3.ColumnCount = 2;
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
      tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
      tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 1, 0);
      tableLayoutPanel3.Controls.Add(comboBox1, 0, 0);
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
      tableLayoutPanel4.Controls.Add(textBox1, 0, 0);
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
      // textBox1
      // 
      textBox1.Dock = DockStyle.Fill;
      textBox1.Location = new Point(3, 3);
      textBox1.Name = "textBox1";
      textBox1.PlaceholderText = "Search x";
      textBox1.Size = new Size(275, 23);
      textBox1.TabIndex = 0;
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
      // comboBox1
      // 
      comboBox1.Dock = DockStyle.Fill;
      comboBox1.FormattingEnabled = true;
      comboBox1.Location = new Point(3, 3);
      comboBox1.Name = "comboBox1";
      comboBox1.Size = new Size(719, 23);
      comboBox1.TabIndex = 1;
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.ContentPanel
      // 
      toolStripContainer1.ContentPanel.AutoScroll = true;
      toolStripContainer1.ContentPanel.Controls.Add(tableLayoutPanel1);
      toolStripContainer1.ContentPanel.Size = new Size(1156, 697);
      toolStripContainer1.Dock = DockStyle.Fill;
      toolStripContainer1.LeftToolStripPanelVisible = false;
      toolStripContainer1.Location = new Point(0, 0);
      toolStripContainer1.Name = "toolStripContainer1";
      toolStripContainer1.RightToolStripPanelVisible = false;
      toolStripContainer1.Size = new Size(1156, 697);
      toolStripContainer1.TabIndex = 0;
      toolStripContainer1.Text = "toolStripContainer1";
      toolStripContainer1.TopToolStripPanelVisible = false;
      // 
      // HexPlorerWindow
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1156, 697);
      Controls.Add(toolStripContainer1);
      Name = "HexPlorerWindow";
      Text = "Hex-Plorer";
      MouseDown += NavigationButton_MouseDown;
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
      toolStripContainer1.ContentPanel.ResumeLayout(false);
      toolStripContainer1.ResumeLayout(false);
      toolStripContainer1.PerformLayout();
      ResumeLayout(false);
   }

   #endregion

   private TableLayoutPanel tableLayoutPanel1;
   private SplitContainer splitContainer1;
   private ToolStripContainer toolStripContainer1;
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
   private TextBox textBox1;
   private Button button5;
   private ComboBox comboBox1;
}