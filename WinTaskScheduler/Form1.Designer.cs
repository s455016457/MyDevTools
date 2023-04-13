namespace WinTaskScheduler
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_New = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Run = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Import = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Export = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.folderTree = new System.Windows.Forms.TreeView();
            this.taskListView1 = new Microsoft.Win32.TaskScheduler.TaskListView();
            this.taskEditDialog1 = new Microsoft.Win32.TaskScheduler.TaskEditDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.refreshTask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_New,
            this.toolStripButton_Edit,
            this.toolStripButton_Delete,
            this.toolStripButton_Run,
            this.toolStripButton_Import,
            this.toolStripButton_Export});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1223, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton_New
            // 
            this.toolStripButton_New.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_New.Image")));
            this.toolStripButton_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_New.Name = "toolStripButton_New";
            this.toolStripButton_New.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_New.Text = "新增";
            // 
            // toolStripButton_Edit
            // 
            this.toolStripButton_Edit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Edit.Image")));
            this.toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Edit.Name = "toolStripButton_Edit";
            this.toolStripButton_Edit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Edit.Text = "编辑";
            // 
            // toolStripButton_Delete
            // 
            this.toolStripButton_Delete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Delete.Image")));
            this.toolStripButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Delete.Name = "toolStripButton_Delete";
            this.toolStripButton_Delete.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Delete.Text = "删除";
            // 
            // toolStripButton_Run
            // 
            this.toolStripButton_Run.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Run.Image")));
            this.toolStripButton_Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Run.Name = "toolStripButton_Run";
            this.toolStripButton_Run.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Run.Text = "运行";
            // 
            // toolStripButton_Import
            // 
            this.toolStripButton_Import.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Import.Image")));
            this.toolStripButton_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Import.Name = "toolStripButton_Import";
            this.toolStripButton_Import.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_Import.Text = "导入任务";
            // 
            // toolStripButton_Export
            // 
            this.toolStripButton_Export.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Export.Image")));
            this.toolStripButton_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Export.Name = "toolStripButton_Export";
            this.toolStripButton_Export.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_Export.Text = "导出任务";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1223, 676);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folderTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.taskListView1);
            this.splitContainer1.Size = new System.Drawing.Size(1223, 676);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // folderTree
            // 
            this.folderTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderTree.Location = new System.Drawing.Point(0, 0);
            this.folderTree.Name = "folderTree";
            this.folderTree.Size = new System.Drawing.Size(266, 676);
            this.folderTree.TabIndex = 0;
            this.folderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.folderTree_AfterSelect);
            this.folderTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.folderTree_NodeMouseClick);
            // 
            // taskListView1
            // 
            this.taskListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taskListView1.Location = new System.Drawing.Point(3, 3);
            this.taskListView1.Name = "taskListView1";
            this.taskListView1.SelectedIndex = -1;
            this.taskListView1.Size = new System.Drawing.Size(947, 663);
            this.taskListView1.TabIndex = 0;
            this.taskListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.taskListView1_MouseDoubleClick);
            // 
            // taskEditDialog1
            // 
            this.taskEditDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.taskEditDialog1.Name = "TaskEditDialog";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolder,
            this.deleteFolder,
            this.refreshTask});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // newFolder
            // 
            this.newFolder.Name = "newFolder";
            this.newFolder.Size = new System.Drawing.Size(180, 22);
            this.newFolder.Text = "新增文件夹";
            // 
            // deleteFolder
            // 
            this.deleteFolder.Name = "deleteFolder";
            this.deleteFolder.Size = new System.Drawing.Size(180, 22);
            this.deleteFolder.Text = "删除文件夹";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "请选择要导入的任务备份文件";
            // 
            // refreshTask
            // 
            this.refreshTask.Name = "refreshTask";
            this.refreshTask.Size = new System.Drawing.Size(180, 22);
            this.refreshTask.Text = "刷新";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 707);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "任务列表";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_New;
        private System.Windows.Forms.ToolStripButton toolStripButton_Edit;
        private System.Windows.Forms.ToolStripButton toolStripButton_Delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView folderTree;
        private Microsoft.Win32.TaskScheduler.TaskListView taskListView1;
        private Microsoft.Win32.TaskScheduler.TaskEditDialog taskEditDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newFolder;
        private System.Windows.Forms.ToolStripMenuItem deleteFolder;
        private System.Windows.Forms.ToolStripButton toolStripButton_Run;
        private System.Windows.Forms.ToolStripButton toolStripButton_Import;
        private System.Windows.Forms.ToolStripButton toolStripButton_Export;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem refreshTask;
    }
}

