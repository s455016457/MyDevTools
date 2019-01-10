using MyDevTools.Properties;
using MyDevTools.Repositories;
using MyDevTools.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using MyDevTools.Plugin.Interfaces;
using LogProvider.Factories;
using LogProvider.Interfaces;
using LogProvider;

namespace MyDevTools
{
    public partial class Form1 : Form
    {
        private IList<IPlugin> allPluginList;
        private IList<IPlugin> pluginList;
        private static ILogSaveProvider log = new LogSaveLocalhostProvider();
        IMenuItemRepository menuItemRepository = new MenuItemRepository();
        public Form1()
        {
            this.Icon = Resources.icon;
            InitializeComponent();
            SetPluginList();
            FillListView();
            GroupToolStripMenuItem.CheckedChanged += GroupToolStripMenuItem_CheckedChanged;
            Form1.SetWindowTheme(this.lvPlugin.Handle, "Explorer", null);
            notifyIcon1.BalloonTipText = "工具集";
            notifyIcon1.BalloonTipTitle = "工具集";
            notifyIcon1.ContextMenuStrip = contextMenuStrip2;
        }

        private void SetPluginList()
        {
            allPluginList = pluginList = menuItemRepository.GetPlugins();
        }

        private void GroupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            lvPlugin.ShowGroups = GroupToolStripMenuItem.Checked;
        }

        private void toolStripLabel_Help_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 填充ListView
        /// </summary>
        private void FillListView()
        {
            this.lvPlugin.BeginUpdate();
            this.lvPlugin.Items.Clear();
            this.lvPlugin.Groups.Clear();
            this.smallImageList.Images.Clear();
            this.largeImageList.Images.Clear();
            if (this.menuItemRepository != null)
            {
                Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>(StringComparer.InvariantCultureIgnoreCase);
                foreach (IPlugin plugin in pluginList)
                {
                    string groupName = plugin.Group;
                    ListViewGroup group;
                    if (groups.ContainsKey(groupName))
                    {
                        group = groups[groupName];
                    }
                    else
                    {
                        group = new ListViewGroup(groupName);
                        groups.Add(groupName, group);
                        this.lvPlugin.Groups.Add(group);
                    }
                    ListViewItem item = new ListViewItem(plugin.Title, group);
                    item.SubItems.Add(plugin.Description);
                    item.SubItems.Add(plugin.Author);
                    this.smallImageList.Images.Add(plugin.Icon);
                    this.largeImageList.Images.Add(plugin.Icon);
                    item.ImageIndex = this.smallImageList.Images.Count - 1;
                    item.ToolTipText = plugin.Description;
                    item.Tag = plugin;
                    this.lvPlugin.Items.Add(item);
                }
            }
            this.lvPlugin.EndUpdate();
        }

        private void ChangeListViewDisplayType(object sender, ToolStripItemClickedEventArgs e)
        {
            var menuItem = e.ClickedItem as ToolStripMenuItem;
            if (menuItem == null && !menuItem.Checked)
            {
                return;
            }
            lvPlugin.BeginUpdate();
            string name;
            if ((name = menuItem.Name) != null)
            {
                DetailToolStripMenuItem.Checked = name.Equals("DetailToolStripMenuItem");
                LargeImageToolStripMenuItem.Checked = name.Equals("LargeImageToolStripMenuItem");
                SmallImageToolStripMenuItem.Checked = name.Equals("SmallImageToolStripMenuItem");
                TitleToolStripMenuItem.Checked = name.Equals("TitleToolStripMenuItem");
                ListToolStripMenuItem.Checked = name.Equals("ListToolStripMenuItem");

                if (DetailToolStripMenuItem.Checked)
                    lvPlugin.View = View.Details;
                if (LargeImageToolStripMenuItem.Checked)
                    lvPlugin.View = View.LargeIcon;
                if (SmallImageToolStripMenuItem.Checked)
                    lvPlugin.View = View.SmallIcon;
                if (TitleToolStripMenuItem.Checked)
                    lvPlugin.View = View.Tile;
                if (ListToolStripMenuItem.Checked)
                    lvPlugin.View = View.List;
            }

            this.lvPlugin.EndUpdate();
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            String text = toolStripComboBox1.Text.Trim();
            if (String.IsNullOrEmpty(text))
            {
                pluginList = allPluginList;
            }
            else
            {
                pluginList = allPluginList.Where(p => p.Title.ToUpper().Contains(text.ToUpper())
                    || p.Description.ToUpper().Contains(text.ToUpper())).ToList();
            }
            FillListView();
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string subAppName, string subIdList);

        private void toolStripButton_DisplayAll_Click(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = String.Empty;
        }

        private void lvPlugin_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvPlugin.SelectedItems.Count > 0)
            {
                try
                {
                    IPlugin plugin = this.lvPlugin.SelectedItems[0].Tag as IPlugin;
                    plugin.StartUp();
                }
                catch (Exception ex)
                {
                    var entity = LogEntityFactory.Create(String.Format("启动工具失败:{0}", ex.ToString()),
                          LogTypeFacotry.CreateExceptionLogType(),
                          LogLevelFactory.CreateGravenessLogLevel());
                    log.SaveLog(entity);

                    MessageBox.Show(ex.ToString(), "启动工具失败");
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem menuItem = e.ClickedItem;
            if (menuItem == null) return;

            switch (menuItem.Text) {
                case "显示":
                    this.Show();
                    break;
                case "隐藏":
                    this.Hide();
                    break;
                case "退出":
                    this.Dispose(true);
                    break;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
