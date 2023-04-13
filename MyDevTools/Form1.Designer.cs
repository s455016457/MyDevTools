namespace MyDevTools
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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_DisplayAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.DetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmallImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.GroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_Help = new System.Windows.Forms.ToolStripButton();
            this.lvPlugin = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.largeImageList = new System.Windows.Forms.ImageList(this.components);
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelUAC = new System.Windows.Forms.Panel();
            this.lbUAC = new System.Windows.Forms.Label();
            this.btnStartWithAdmin = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_RunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.panelUAC.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripButton_DisplayAll,
            this.toolStripDropDownButton1,
            this.toolStripButton_Help});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            this.toolStripLabel1.Name = "toolStripLabel1";
            // 
            // toolStripComboBox1
            // 
            resources.ApplyResources(this.toolStripComboBox1, "toolStripComboBox1");
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // toolStripButton_DisplayAll
            // 
            resources.ApplyResources(this.toolStripButton_DisplayAll, "toolStripButton_DisplayAll");
            this.toolStripButton_DisplayAll.Image = global::MyDevTools.Properties.Resources.application_form_magnify;
            this.toolStripButton_DisplayAll.Name = "toolStripButton_DisplayAll";
            this.toolStripButton_DisplayAll.Click += new System.EventHandler(this.toolStripButton_DisplayAll_Click);
            // 
            // toolStripDropDownButton1
            // 
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DetailToolStripMenuItem,
            this.LargeImageToolStripMenuItem,
            this.SmallImageToolStripMenuItem,
            this.TitleToolStripMenuItem,
            this.ListToolStripMenuItem,
            this.toolStripSeparator1,
            this.GroupToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::MyDevTools.Properties.Resources.application_view_tile;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ChangeListViewDisplayType);
            // 
            // DetailToolStripMenuItem
            // 
            resources.ApplyResources(this.DetailToolStripMenuItem, "DetailToolStripMenuItem");
            this.DetailToolStripMenuItem.Name = "DetailToolStripMenuItem";
            // 
            // LargeImageToolStripMenuItem
            // 
            resources.ApplyResources(this.LargeImageToolStripMenuItem, "LargeImageToolStripMenuItem");
            this.LargeImageToolStripMenuItem.Name = "LargeImageToolStripMenuItem";
            // 
            // SmallImageToolStripMenuItem
            // 
            resources.ApplyResources(this.SmallImageToolStripMenuItem, "SmallImageToolStripMenuItem");
            this.SmallImageToolStripMenuItem.Name = "SmallImageToolStripMenuItem";
            // 
            // TitleToolStripMenuItem
            // 
            resources.ApplyResources(this.TitleToolStripMenuItem, "TitleToolStripMenuItem");
            this.TitleToolStripMenuItem.Name = "TitleToolStripMenuItem";
            // 
            // ListToolStripMenuItem
            // 
            resources.ApplyResources(this.ListToolStripMenuItem, "ListToolStripMenuItem");
            this.ListToolStripMenuItem.Name = "ListToolStripMenuItem";
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // GroupToolStripMenuItem
            // 
            resources.ApplyResources(this.GroupToolStripMenuItem, "GroupToolStripMenuItem");
            this.GroupToolStripMenuItem.Checked = true;
            this.GroupToolStripMenuItem.CheckOnClick = true;
            this.GroupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GroupToolStripMenuItem.Name = "GroupToolStripMenuItem";
            // 
            // toolStripButton_Help
            // 
            resources.ApplyResources(this.toolStripButton_Help, "toolStripButton_Help");
            this.toolStripButton_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Help.Image = global::MyDevTools.Properties.Resources.help;
            this.toolStripButton_Help.Name = "toolStripButton_Help";
            // 
            // lvPlugin
            // 
            resources.ApplyResources(this.lvPlugin, "lvPlugin");
            this.lvPlugin.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvPlugin.AllowDrop = true;
            this.lvPlugin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPlugin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Description,
            this.Author});
            this.lvPlugin.FullRowSelect = true;
            this.lvPlugin.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("lvPlugin.Groups")))});
            this.lvPlugin.HideSelection = false;
            this.lvPlugin.LargeImageList = this.largeImageList;
            this.lvPlugin.MultiSelect = false;
            this.lvPlugin.Name = "lvPlugin";
            this.lvPlugin.ShowItemToolTips = true;
            this.lvPlugin.SmallImageList = this.smallImageList;
            this.lvPlugin.UseCompatibleStateImageBehavior = false;
            this.lvPlugin.View = System.Windows.Forms.View.Tile;
            this.lvPlugin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPlugin_MouseDoubleClick);
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            // 
            // Description
            // 
            resources.ApplyResources(this.Description, "Description");
            // 
            // Author
            // 
            resources.ApplyResources(this.Author, "Author");
            // 
            // largeImageList
            // 
            this.largeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.largeImageList, "largeImageList");
            this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // smallImageList
            // 
            this.smallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            resources.ApplyResources(this.smallImageList, "smallImageList");
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.隐藏toolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // 显示ToolStripMenuItem
            // 
            resources.ApplyResources(this.显示ToolStripMenuItem, "显示ToolStripMenuItem");
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            // 
            // 隐藏toolStripMenuItem
            // 
            resources.ApplyResources(this.隐藏toolStripMenuItem, "隐藏toolStripMenuItem");
            this.隐藏toolStripMenuItem.Name = "隐藏toolStripMenuItem";
            // 
            // 退出ToolStripMenuItem
            // 
            resources.ApplyResources(this.退出ToolStripMenuItem, "退出ToolStripMenuItem");
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            // 
            // panelUAC
            // 
            resources.ApplyResources(this.panelUAC, "panelUAC");
            this.panelUAC.Controls.Add(this.lbUAC);
            this.panelUAC.Controls.Add(this.btnStartWithAdmin);
            this.panelUAC.Name = "panelUAC";
            // 
            // lbUAC
            // 
            resources.ApplyResources(this.lbUAC, "lbUAC");
            this.lbUAC.Name = "lbUAC";
            // 
            // btnStartWithAdmin
            // 
            resources.ApplyResources(this.btnStartWithAdmin, "btnStartWithAdmin");
            this.btnStartWithAdmin.Name = "btnStartWithAdmin";
            this.btnStartWithAdmin.UseVisualStyleBackColor = true;
            this.btnStartWithAdmin.Click += new System.EventHandler(this.btnStartWithAdmin_Click);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_RunTime});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel_RunTime
            // 
            resources.ApplyResources(this.toolStripStatusLabel_RunTime, "toolStripStatusLabel_RunTime");
            this.toolStripStatusLabel_RunTime.Name = "toolStripStatusLabel_RunTime";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvPlugin);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelUAC);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panelUAC.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton_DisplayAll;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem DetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LargeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SmallImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem GroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_Help;
        private System.Windows.Forms.ListView lvPlugin;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ImageList smallImageList;
        private System.Windows.Forms.ImageList largeImageList;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏toolStripMenuItem;
        private System.Windows.Forms.Panel panelUAC;
        private System.Windows.Forms.Label lbUAC;
        private System.Windows.Forms.Button btnStartWithAdmin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_RunTime;
    }
}

