using Microsoft.Win32.TaskScheduler;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace WinTaskScheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadFolderTree();
            LoadTaskList();
        }

        private void LoadFolderTree()
        {
            var rootNode = new TreeNode("任务计划程序库");
            rootNode.Tag = TaskService.Instance.RootFolder;
            LoadChilderNode(rootNode, TaskService.Instance.RootFolder);
            folderTree.Nodes.Clear();
            folderTree.Nodes.Add(rootNode);
        }

        private void LoadChilderNode(TreeNode parentNode, TaskFolder parentFolder)
        {
            if (parentNode == null || parentNode == null) { return; }
            foreach (var folder in parentFolder.SubFolders)
            {
                var node = new TreeNode(folder.Name);
                node.Tag = folder;
                parentNode.Nodes.Add(node);
                LoadChilderNode(node, folder);
            }
        }

        private void LoadTaskList()
        {
            var service = TaskService.Instance;
            taskListView1.Folder = service.RootFolder;
        }

        private void folderTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            taskListView1.Folder = e.Node.Tag as TaskFolder;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Edit":
                    ShowTaskEditDialog();
                    break;
                case "toolStripButton_New":
                    ShowTaskSchedulerWizard();
                    break;
                case "toolStripButton_Delete":
                    DeleteTask();
                    break;
                case "toolStripButton_Run":
                    RunTask();
                    break;
                case "toolStripButton_Import":
                    ImportTask();
                    break;
                case "toolStripButton_Export":
                    ExportTask();
                    break;
                default:
                    break;
            }
        }

        private void taskListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowTaskEditDialog();
        }

        private void ShowTaskEditDialog()
        {
            if (taskListView1.SelectedIndex >= 0 && taskListView1.Tasks.Count >= 0)
            {
                taskEditDialog1.Initialize(taskListView1.Tasks[taskListView1.SelectedIndex]);
            }
            taskEditDialog1.Editable = true;
            taskEditDialog1.ShowActionRunButton = true;
            taskEditDialog1.AvailableActions = AvailableActions.AllActions;
            taskEditDialog1.RegisterTaskOnAccept = true;
            var result = taskEditDialog1.ShowDialog();
        }

        private void ShowTaskSchedulerWizard()
        {
            var taskSchedulerWizard1 = new TaskSchedulerWizard(TaskService.Instance, registerOnFinish: true);
            taskSchedulerWizard1.Title = "任务创建向导";
            taskSchedulerWizard1.TaskFolder = (folderTree.SelectedNode.Tag as TaskFolder)?.Name;
            taskSchedulerWizard1.StartPosition = FormStartPosition.CenterParent;
            var result = taskSchedulerWizard1.ShowDialog();
            if (result == DialogResult.OK)
            {
                taskListView1.Folder = GetSelectedTaskFolder() ?? TaskService.Instance.RootFolder;
            }
        }

        private void DeleteTask()
        {
            var task = GetSelectedTask();
            if (task == null)
            {
                MessageBox.Show("请选择要删除的任务");
                return;
            }
            CheckCurrentIdentityPermissionLevel();
            TaskService.Instance.RootFolder.DeleteTask(task.Path);
            taskListView1.Folder = GetSelectedTaskFolder() ?? TaskService.Instance.RootFolder;
        }

        private void CheckCurrentIdentityPermissionLevel()
        {
            // Check to make sure account privileges allow task deletion
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                throw new Exception($@"当前用户 '{identity.Name}' 的权限等级不能执行该项操作。
即使您使用的是管理员帐户，也可能需要“以管理员身份”运行此应用程序。");
        }

        private void RunTask()
        {
            var task = GetSelectedTask();
            task.Run();
        }

        private void ImportTask()
        {
            CheckCurrentIdentityPermissionLevel();
            var folder = GetSelectedTaskFolder();
            openFileDialog1.InitialDirectory = Path.Combine(Application.UserAppDataPath);
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (openFileDialog1.FileNames.Length > 0)
                {
                    foreach (var fileName in openFileDialog1.FileNames)
                    {
                        var fileInfo = new FileInfo(fileName);
                        if (fileInfo.Exists)
                        {
                            var taskName = fileInfo.Name.Substring(fileInfo.Name.LastIndexOf('_') + 1, fileInfo.Name.Length - fileInfo.Extension.Length - fileInfo.Name.LastIndexOf('_') - 1);
                            (folder ?? TaskService.Instance.RootFolder).ImportTask(taskName, fileInfo.FullName);
                        }
                    }
                }
            }

            taskListView1.Folder = folder ?? TaskService.Instance.RootFolder;
        }

        private void ExportTask()
        {
            var directory = Path.Combine(Application.UserAppDataPath, "Export");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            {
                var task = GetSelectedTask();
                if (task != null)
                {
                    ExportTask(task, directory);
                    OpenDirectory(directory);
                    return;
                }
            }
            var folder = GetSelectedTaskFolder();
            if (folder != null)
            {
                ExportFolderTask(folder, directory);
                OpenDirectory(directory);
                return;
            }
            MessageBox.Show("请选择要导出的任务或要导出任务的文件夹");
        }

        private void ExportFolderTask(TaskFolder folder, string directory)
        {
            foreach (var task in folder.Tasks)
            {
                ExportTask(task, directory);
            }
            foreach (var f in folder.SubFolders)
            {
                ExportFolderTask(f, directory);
            }
        }

        private void ExportTask(Task task, string directory)
        {
            task.Export(Path.Combine(directory, $"{task.Path.Replace('\\', '_').Replace('/', '_')}.xml"));
        }

        private void OpenDirectory(string directory)
        {
            var p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = directory;
            p.Start();
        }

        private Task GetSelectedTask()
        {
            if (taskListView1.SelectedIndex < 0 || taskListView1.Tasks.Count <= 0)
            {
                return null;
            }
            return taskListView1.Tasks[taskListView1.SelectedIndex];
        }

        private TaskFolder GetSelectedTaskFolder()
        {
            return folderTree.SelectedNode.Tag as TaskFolder;
        }

        private void folderTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(folderTree, new Point(e.X, e.Y));
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var currentFolder = folderTree.SelectedNode.Tag as TaskFolder;
            switch (e.ClickedItem.Name)
            {
                case "newFolder":
                    var result = new NewFolder(currentFolder).ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        LoadFolderTree();
                    }
                    break;
                case "deleteFolder":
                    currentFolder.Parent.SubFolders.Remove(currentFolder);
                    LoadFolderTree();
                    break;
                case "refreshTask":
                    taskListView1.Folder = GetSelectedTaskFolder() ?? TaskService.Instance.RootFolder;
                    break;
                default: break;
            }
        }
    }
}
