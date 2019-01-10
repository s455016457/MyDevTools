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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("组", System.Windows.Forms.HorizontalAlignment.Left);
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
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripButton_DisplayAll,
            this.toolStripDropDownButton1,
            this.toolStripButton_Help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(724, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "筛选";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.TextChanged += new System.EventHandler(this.toolStripComboBox1_TextChanged);
            // 
            // toolStripButton_DisplayAll
            // 
            this.toolStripButton_DisplayAll.Image = global::MyDevTools.Properties.Resources.application_form_magnify;
            this.toolStripButton_DisplayAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DisplayAll.Name = "toolStripButton_DisplayAll";
            this.toolStripButton_DisplayAll.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_DisplayAll.Text = "全部显示";
            this.toolStripButton_DisplayAll.Click += new System.EventHandler(this.toolStripButton_DisplayAll_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DetailToolStripMenuItem,
            this.LargeImageToolStripMenuItem,
            this.SmallImageToolStripMenuItem,
            this.TitleToolStripMenuItem,
            this.ListToolStripMenuItem,
            this.toolStripSeparator1,
            this.GroupToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::MyDevTools.Properties.Resources.application_view_tile;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripDropDownButton1.Text = "布局";
            this.toolStripDropDownButton1.ToolTipText = "选择布局";
            this.toolStripDropDownButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ChangeListViewDisplayType);
            // 
            // DetailToolStripMenuItem
            // 
            this.DetailToolStripMenuItem.Name = "DetailToolStripMenuItem";
            this.DetailToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.DetailToolStripMenuItem.Text = "详细信息";
            // 
            // LargeImageToolStripMenuItem
            // 
            this.LargeImageToolStripMenuItem.Name = "LargeImageToolStripMenuItem";
            this.LargeImageToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.LargeImageToolStripMenuItem.Text = "大图标";
            // 
            // SmallImageToolStripMenuItem
            // 
            this.SmallImageToolStripMenuItem.Name = "SmallImageToolStripMenuItem";
            this.SmallImageToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.SmallImageToolStripMenuItem.Text = "小图标";
            // 
            // TitleToolStripMenuItem
            // 
            this.TitleToolStripMenuItem.Name = "TitleToolStripMenuItem";
            this.TitleToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.TitleToolStripMenuItem.Text = "平铺";
            // 
            // ListToolStripMenuItem
            // 
            this.ListToolStripMenuItem.Name = "ListToolStripMenuItem";
            this.ListToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ListToolStripMenuItem.Text = "列表";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // GroupToolStripMenuItem
            // 
            this.GroupToolStripMenuItem.Checked = true;
            this.GroupToolStripMenuItem.CheckOnClick = true;
            this.GroupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GroupToolStripMenuItem.Name = "GroupToolStripMenuItem";
            this.GroupToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.GroupToolStripMenuItem.Text = "分组显示";
            // 
            // toolStripButton_Help
            // 
            this.toolStripButton_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Help.Image = global::MyDevTools.Properties.Resources.help;
            this.toolStripButton_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Help.Name = "toolStripButton_Help";
            this.toolStripButton_Help.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Help.Text = "帮助";
            this.toolStripButton_Help.ToolTipText = "帮助";
            // 
            // lvPlugin
            // 
            this.lvPlugin.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvPlugin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPlugin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Description,
            this.Author});
            this.lvPlugin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPlugin.FullRowSelect = true;
            listViewGroup1.Header = "组";
            listViewGroup1.Name = "Goup";
            this.lvPlugin.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvPlugin.LargeImageList = this.largeImageList;
            this.lvPlugin.Location = new System.Drawing.Point(0, 25);
            this.lvPlugin.MultiSelect = false;
            this.lvPlugin.Name = "lvPlugin";
            this.lvPlugin.ShowItemToolTips = true;
            this.lvPlugin.Size = new System.Drawing.Size(724, 369);
            this.lvPlugin.SmallImageList = this.smallImageList;
            this.lvPlugin.TabIndex = 3;
            this.lvPlugin.UseCompatibleStateImageBehavior = false;
            this.lvPlugin.View = System.Windows.Forms.View.Tile;
            this.lvPlugin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPlugin_MouseDoubleClick);
            // 
            // Title
            // 
            this.Title.Text = "名称";
            this.Title.Width = 120;
            // 
            // Description
            // 
            this.Description.Text = "详情";
            this.Description.Width = 360;
            // 
            // Author
            // 
            this.Author.Text = "作者";
            this.Author.Width = 100;
            // 
            // largeImageList
            // 
            this.largeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.largeImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // smallImageList
            // 
            this.smallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.smallImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "工具集";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.隐藏toolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 70);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // 隐藏toolStripMenuItem
            // 
            this.隐藏toolStripMenuItem.Name = "隐藏toolStripMenuItem";
            this.隐藏toolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.隐藏toolStripMenuItem.Text = "隐藏";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 394);
            this.Controls.Add(this.lvPlugin);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工具集";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
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
    }
}

