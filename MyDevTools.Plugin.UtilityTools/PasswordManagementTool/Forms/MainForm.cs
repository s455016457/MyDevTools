using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Entity;
using MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Repository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Forms
{
    /**
     * 还需添加登陆密码验证，登陆密码更新
     * 密码用MD5不可逆加密，保存在.data文件中
     * 并用密码加密字符串再对密文做次加密
     * 密码登录后才从硬盘中加载数据
     * */
    public partial class MainForm : Form
    {
        /// <summary>
        /// 程序签名
        /// </summary>
        internal const String Sign = "DD01A9A0FA8864D6E18BA40243A433ABA6A4732707FD9EE9F43972B8682C63DC";
        internal IPassworkProjectRepository repository { get; private set; }

        private DetailAction _projectDetailAction = DetailAction.Display;

        public event EventHandler<DetailActionChangeEventArg> onProjectDetailActionChange;

        private PasswordProject SelectPassworkProject = null;

        private Boolean isLogin = false;

        public DetailAction ProjectDetailAction
        {
            get { return _projectDetailAction; }
            private set
            {
                _projectDetailAction = value;
                if (onProjectDetailActionChange != null)
                {
                    onProjectDetailActionChange.Invoke(this, new DetailActionChangeEventArg(value));
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            onProjectDetailActionChange += MainForm_onProjectDetailActionChange;
            ProjectDetailAction = DetailAction.Display;
            repository = Factory.CreatePassworkProjectRepository();
            if (String.IsNullOrEmpty(repository.GetPassword()))
            {
                new CreatePassword(repository) { TopMost=true}.Show();
            }
            else
            {
                ShowLoginForm();
            }
        }

        private void ShowLoginForm()
        {
            ConfirmForm passwordForm = new ConfirmForm("请登录", "请输入登录密码", "", p =>
            {
                try
                {
                    if (!repository.VerificationPassword(p))
                    {
                        MessageBox.Show("密码不正确！", "温馨提示");
                        return false;
                    }
                    isLogin = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "温馨提示");
                    return false;
                }
                ProjectList.Items.AddRange(repository.GetPassworkProjectNameList().ToArray());
                return true;
            })
            {
                TopMost = true,
            };
            passwordForm.Show();
        }

        private void MainForm_onProjectDetailActionChange(object sender, DetailActionChangeEventArg e)
        {
            switch (e.DetailAction) {
                case DetailAction.Display:
                    ShowDisplay();
                    break;
                case DetailAction.AddNew:
                    AddNew();
                    break;
                case DetailAction.Edit:
                    Edit();
                    break;
            }
        }

        private void ShowDisplay()
        {
            textBox_Name.ReadOnly = true;
            textBox_Address.ReadOnly = true;
            textBox_Account.ReadOnly = true;
            textBox_Email.ReadOnly = true;
            textBox_MobilPhone.ReadOnly = true;
            SetExtensionFieldsTextBoxIsReadOnly();
            SetSafetyProblemsTextBoxReadOnly();
            SetPasswordItemsTextBoxReadOnly();
            DisplayExtensionFields();
            DisplaySafetyProblems();
            ChangeToolStripButtonEnabled();

        }
        private void AddNew()
        {
            textBox_Name.ReadOnly = true;
            textBox_Address.ReadOnly = false;
            textBox_Account.ReadOnly = false;
            textBox_Email.ReadOnly = false;
            textBox_MobilPhone.ReadOnly = false;
            SetExtensionFieldsTextBoxIsEdit();
            SetSafetyProblemsTextBoxIsEdit();
            SetPasswordItemsTextBoxIsEdit();
            DisplayExtensionFields();
            DisplaySafetyProblems();
            ChangeToolStripButtonEnabled();
        }
        private void Edit()
        {
            textBox_Name.ReadOnly = true;
            textBox_Address.ReadOnly = false;
            textBox_Account.ReadOnly = false;
            textBox_Email.ReadOnly = false;
            textBox_MobilPhone.ReadOnly = false;
            SetExtensionFieldsTextBoxIsEdit();
            SetSafetyProblemsTextBoxIsEdit();
            SetPasswordItemsTextBoxIsEdit();
            DisplayExtensionFields();
            DisplaySafetyProblems();
            ChangeToolStripButtonEnabled();
        }

        private void ChangeToolStripButtonEnabled()
        {
            toolStripButton_AddSafetyProblems.Enabled = ProjectDetailAction != DetailAction.Display;
            toolStripButton_AddExtendField.Enabled = ProjectDetailAction != DetailAction.Display;
            toolStripButton_AddPassrowdItem.Enabled = ProjectDetailAction != DetailAction.Display;
            //toolStripButton_Save.Enabled = ProjectDetailAction != DetailAction.Display;
            toolStripButton_Edit.Enabled = SelectPassworkProject != null;
            toolStripButton_Remove.Enabled =  SelectPassworkProject != null;
        }

        /// <summary>
        /// 设置扩展字段输入框为只读
        /// </summary>
        private void SetExtensionFieldsTextBoxIsReadOnly()
        {
            ChildrenControlAction<TextBox>(panel_ExtensionFields, p => p.ReadOnly = true);
            ChildrenControlAction<Button>(panel_ExtensionFields, p => p.Enabled = false);
        }
        /// <summary>
        /// 设置扩展字段输入框可编辑
        /// </summary>
        private void SetExtensionFieldsTextBoxIsEdit()
        {
            ChildrenControlAction<TextBox>(panel_ExtensionFields, p =>p.ReadOnly = false);
            ChildrenControlAction<Button>(panel_ExtensionFields, p => p.Enabled = true);
        }
        /// <summary>
        /// 设置安全问题输入框为只读
        /// </summary>
        private void SetSafetyProblemsTextBoxReadOnly()
        {
            ChildrenControlAction<TextBox>(panel_SafetyProblems, p => p.ReadOnly = true);
            ChildrenControlAction<Button>(panel_SafetyProblems, p => p.Enabled = false);
        }
        /// <summary>
        /// 设置安全问题输入框为只读
        /// </summary>
        private void SetSafetyProblemsTextBoxIsEdit()
        {
            ChildrenControlAction<TextBox>(panel_SafetyProblems, p => p.ReadOnly = false);
            ChildrenControlAction<Button>(panel_SafetyProblems, p => p.Enabled = true);
        }
        /// <summary>
        /// 设置密码输入框为只读
        /// </summary>
        private void SetPasswordItemsTextBoxReadOnly()
        {
            ChildrenControlAction<TextBox>(panel_PasswordItems, p => p.ReadOnly = true);
            ChildrenControlAction<Button>(panel_PasswordItems, p => p.Enabled = false);
        }
        /// <summary>
        /// 设置密码输入框为只读
        /// </summary>
        private void SetPasswordItemsTextBoxIsEdit()
        {
            ChildrenControlAction<TextBox>(panel_PasswordItems, p => p.ReadOnly = false);
            ChildrenControlAction<Button>(panel_PasswordItems, p => p.Enabled = true);
        }

        private void DisplayExtensionFields()
        {
            groupBox_ExtendField.Visible = 
                SelectPassworkProject != null
                && SelectPassworkProject.ExtensionFields != null
                && SelectPassworkProject.ExtensionFields.Count > 0;
        }
        private void DisplaySafetyProblems()
        {
            groupBox_SafetyProblems.Visible = 
                SelectPassworkProject != null
                && SelectPassworkProject.SafetyProblems != null
                && SelectPassworkProject.SafetyProblems.Count > 0; 
        }

        private void ChildrenControlAction<T>(Control ParentControl,Action<T> action) where T : Control
        {
            if (!ParentControl.HasChildren) return;
            foreach (Control control in ParentControl.Controls)
            {
                if (control is T)
                {
                    action((control as T));
                }
                else
                {
                    ChildrenControlAction<T>(control, action);
                }
            }
        }
        
        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isLogin)
                {
                    ShowLoginForm();
                    return;
                }
                textBox_Name.Focus();
                repository.SaveChanges();
                ProjectDetailAction = DetailAction.Display;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "温馨提示");
            }
        }

        private void toolStripButton_AddNew_Click(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                ShowLoginForm();
                return;
            }
            ConfirmForm confirmForm = new ConfirmForm("添加密码项目", "请输入密码项目名称", "", p =>
            {
                if (p.Length <= 0)
                {
                    MessageBox.Show("项目名称不能为空！", "温馨提示");
                    return false;
                }
                SelectPassworkProject = repository.CreatePassworkProject(p, String.Empty);
                ProjectList.Items.Add(p);
                ProjectList.SelectedItem = p;
                ProjectDetailAction = DetailAction.Edit;

                return true;
            });
            confirmForm.Show();
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            ProjectDetailAction = DetailAction.Edit;
        }

        private void toolStripButton_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                repository.RemovePassworkProject(SelectPassworkProject);
                ProjectList.Items.Clear();
                ProjectList.Items.AddRange(repository.GetPassworkProjectNameList().ToArray());
                SelectPassworkProject = null;
                RefreshDetailView();
                ProjectDetailAction = DetailAction.Display;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "温馨提示");
            }
        }

        private void toolStripButton_AddExtendField_Click(object sender, EventArgs e)
        {
            if (ProjectDetailAction == DetailAction.Display)
            {
                MessageBox.Show("预览状态，不能新增扩展字段", "温馨提示");
                return;
            }

            if (SelectPassworkProject == null)
            {
                MessageBox.Show("密码项目不存在","温馨提示");
                return;
            }
            ConfirmForm confirmForm = new ConfirmForm("添加扩展字段", "请输入扩展字段名称", "", p =>
            {
                if (p.Length <= 0)
                {
                    MessageBox.Show("扩展字段名称不能为空！", "温馨提示");
                    return false;
                }
                try
                {
                    if (SelectPassworkProject == null) return false;
                    SelectPassworkProject.AddExtensionField(p);
                    AddExtendFieldChildControl(panel_ExtensionFields, p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "温馨提示");
                    return false;
                }
                if (!groupBox_ExtendField.Visible) groupBox_ExtendField.Visible = true;

                return true;
            });
            confirmForm.Show();
        }

        private void toolStripButton_AddSafetyProblems_Click(object sender, EventArgs e)
        {
            if (ProjectDetailAction == DetailAction.Display)
            {
                MessageBox.Show("预览状态，不能新增安全问题", "温馨提示");
                return;
            }
            if (SelectPassworkProject == null)
            {
                MessageBox.Show("密码项目不存在", "温馨提示");
                return;
            }
            ConfirmForm confirmForm = new ConfirmForm("添加安全问题", "请输入安全问题", "", p =>
            {
                if (p.Length <= 0)
                {
                    MessageBox.Show("安全问题不能为空！", "温馨提示");
                    return false;
                }
                try
                {
                    if (SelectPassworkProject == null) return false;
                    SelectPassworkProject.AddSafetyProblem(p);
                    AddSafetyProblemChildControl(panel_SafetyProblems, p);

                    if (!groupBox_SafetyProblems.Visible) groupBox_SafetyProblems.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "温馨提示");
                    return false;
                }

                return true;
            });
            confirmForm.Show();
        }
        private void toolStripButton_AddPassrowdItem_Click(object sender, EventArgs e)
        {
            if (ProjectDetailAction == DetailAction.Display)
            {
                MessageBox.Show("预览状态，不能新增密码", "温馨提示");
                return;
            }
            if (SelectPassworkProject == null)
            {
                MessageBox.Show("密码项目不存在", "温馨提示");
                return;
            }
            ConfirmForm confirmForm = new ConfirmForm("添加密码", "请输入密码名称", "", p =>
            {
                if (p.Length <= 0)
                {
                    MessageBox.Show("密码名称不能为空！", "温馨提示");
                    return false;
                }
                try
                {
                    if (SelectPassworkProject == null) return false;
                    SelectPassworkProject.AddPasswordItem(p);
                    AddPassrowdItemChildControl(panel_PasswordItems, p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "温馨提示");
                    return false;
                }
                return true;
            });
            confirmForm.Show();
        }

        private void ProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPassworkProject = repository.GetPassworkProject(ProjectList.SelectedItem.ToString());
            RefreshDetailView();
            ProjectDetailAction = DetailAction.Display;
        }

        private void RefreshDetailView()
        {
            if (SelectPassworkProject != null)
            {
                textBox_Name.Text = SelectPassworkProject.Name;
                textBox_Account.Text = SelectPassworkProject.Account;
                textBox_Address.Text = SelectPassworkProject.Address;
                textBox_Email.Text = SelectPassworkProject.Email;
                textBox_MobilPhone.Text = SelectPassworkProject.MobilPhone;
            }
            else
            {
                textBox_Name.Text = String.Empty;
                textBox_Account.Text = String.Empty;
                textBox_Address.Text = String.Empty;
                textBox_Email.Text = String.Empty;
                textBox_MobilPhone.Text = String.Empty;
            }
            RefreshExtendFieldPanel();
            RefreshSafetyProblemsPanel();
            RefreshPasswordItemsPanel();
            DisplaySafetyProblems();
            DisplayExtensionFields();
        }

        private void RefreshExtendFieldPanel()
        {
            panel_ExtensionFields.Controls.Clear();
            if (SelectPassworkProject != null 
                && SelectPassworkProject.ExtensionFields != null 
                && SelectPassworkProject.ExtensionFields.Count > 0)
            {
                foreach (ExtensionField extnesionField in SelectPassworkProject.ExtensionFields)
                {
                    AddExtendFieldChildControl(panel_ExtensionFields, extnesionField.Name, extnesionField.Value);
                }
            }
        }
        private void RefreshSafetyProblemsPanel()
        {
            panel_SafetyProblems.Controls.Clear();
            if (SelectPassworkProject != null
                && SelectPassworkProject.SafetyProblems != null
                && SelectPassworkProject.SafetyProblems.Count > 0)
            {
                foreach (SafetyProblem sp in SelectPassworkProject.SafetyProblems)
                {
                    AddSafetyProblemChildControl(panel_SafetyProblems, sp.Problem, sp.Solution);
                }
            }
        }
        private void RefreshPasswordItemsPanel()
        {
            panel_PasswordItems.Controls.Clear();
            if (SelectPassworkProject != null
                && SelectPassworkProject.PasswordItems != null
                && SelectPassworkProject.PasswordItems.Count > 0)
            {
                foreach (PasswordItem pi in SelectPassworkProject.PasswordItems)
                {
                    AddPassrowdItemChildControl(panel_PasswordItems, pi.Name, pi.Password,pi.Remark);
                }
            }
        }
        private void AddExtendFieldChildControl(Control parentControl,String Name="",String Value="")
        {
            if (parentControl == null) return;
            if (String.IsNullOrEmpty(Name)) return;
            Panel panel = new Panel
            {
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
                AutoSize = true,
                Dock = DockStyle.Fill,
                Name = "panel_" + Guid.NewGuid().ToString(),
                Padding = new Padding
                {
                    Top = 10,
                    Bottom = 10,
                },
            };
            panel.Dock = DockStyle.Bottom;

            Label keyLabel = new Label
            {
                Location = new Point(0, 0),
                Size = new Size(80, 21),
                Text = Name,                
                Name = "KeyLabel_" + Guid.NewGuid().ToString(),
            };

            TextBox valueTextBox = new TextBox
            {
                Location = new Point(90, 0),
                Size = new Size(350, 21),
                Text = !String.IsNullOrEmpty(Value) ? Value : "扩展字段值",
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
                ForeColor = !String.IsNullOrEmpty(Value) ? Color.Black : Color.Gray,
                Name = "ValueTextBox_" + Guid.NewGuid().ToString(),
            };
            valueTextBox.Enter += (object sender, EventArgs e) =>
            {
                var textbox = sender as TextBox;
                if (textbox == null) return;
                if (ProjectDetailAction == DetailAction.Display) return;
                if (textbox.Text.Equals("扩展字段值"))
                {
                    textbox.ForeColor = Color.Black;
                    textbox.Text = String.Empty;
                }
            };

            valueTextBox.Leave += (object sender, EventArgs e) =>
            {
                var textbox = sender as TextBox;
                if (textbox == null) return;
                if (ProjectDetailAction == DetailAction.Display) return;
                if (SelectPassworkProject == null) return;

                SelectPassworkProject.UpdateExtensionField(keyLabel.Text.Trim(), textbox.Text.Trim());

                if (textbox.Text.Equals(String.Empty))
                {
                    textbox.ForeColor = Color.Gray;
                    textbox.Text = "扩展字段值";
                }
            };

            Button removeButton = new Button
            {
                Location = new Point(450, 0),
                Text = "删除",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size=new Size(75, 23),
            };

            removeButton.Click += (sender, e) =>
            {
                try
                {
                    if (SelectPassworkProject == null) return;
                    SelectPassworkProject.RemoveExtensionFields(keyLabel.Text.Trim());
                    parentControl.Controls.Remove(panel);
                    DisplayExtensionFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "温馨提示");
                }
            };

            parentControl.Controls.Add(panel);
            panel.Controls.Add(keyLabel);
            panel.Controls.Add(valueTextBox);            
            panel.Controls.Add(removeButton);
        }

        private void AddSafetyProblemChildControl(Control parentControl, String Name = "", String Value = "")
        {
            if (parentControl == null) return;
            if (String.IsNullOrEmpty(Name)) return;
            Panel panel = new Panel
            {
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
                AutoSize = true,
                Dock = DockStyle.Fill,
                Name = "panel_" + Guid.NewGuid().ToString(),
                Padding = new Padding
                {
                  Top=10,
                  Bottom=10,
                },
            };
            panel.Dock = DockStyle.Bottom;

            Label keyLabel = new Label
            {
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
                Location = new Point(0, 0),
                Size = new Size(435, 21),
                Text = Name,
                Name = "KeyLabel_" + Guid.NewGuid().ToString(),
            };
            Button removeButton = new Button
            {
                Text = "删除",
                Location = new Point(450, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size = new Size(75, 23),
            };
            removeButton.Click += (sender, e) =>
            {
                try
                {
                    if (SelectPassworkProject == null) return;
                    SelectPassworkProject.RemoveSafetyProblem(keyLabel.Text.Trim());
                    parentControl.Controls.Remove(panel);
                    DisplaySafetyProblems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "温馨提示s");
                }
            };

            TextBox valueTextBox = new TextBox
            {
                Location = new Point(0, 25),
                Size = new Size(520, 21),
                Text = !String.IsNullOrEmpty(Value) ? Value : "问题答案",
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                ForeColor = !String.IsNullOrEmpty(Value) ? Color.Black : Color.Gray,
                Name = "ValueTextBox_" + Guid.NewGuid().ToString(),
            };
            valueTextBox.Enter += (object sender, EventArgs e) =>
            {
                var textbox = sender as TextBox;
                if (textbox == null) return;
                if (ProjectDetailAction == DetailAction.Display) return;
                if (textbox.Text.Equals("问题答案"))
                {
                    textbox.ForeColor = Color.Black;
                    textbox.Text = String.Empty;
                }
            };

            valueTextBox.Leave += (object sender, EventArgs e) =>
            {
                var textbox = sender as TextBox;
                if (textbox == null) return;
                if (ProjectDetailAction == DetailAction.Display) return;
                if (SelectPassworkProject == null) return;

                SelectPassworkProject.UpdateSafetyProblem(keyLabel.Text.Trim(), textbox.Text.Trim());

                if (textbox.Text.Equals(String.Empty))
                {
                    textbox.ForeColor = Color.Gray;
                    textbox.Text = "问题答案";
                }
            };

            parentControl.Controls.Add(panel);
            panel.Controls.Add(keyLabel);
            panel.Controls.Add(removeButton);
            panel.Controls.Add(valueTextBox);
        }
        private void AddPassrowdItemChildControl(Control parentControl, String Name = "", String Value = "",String Remark="")
        {
            if (parentControl == null) return;
            if (String.IsNullOrEmpty(Name)) return;
            Panel panel = new Panel
            {
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
                AutoSize = true,
                Dock = DockStyle.Fill,
                Name = "panel_" + Guid.NewGuid().ToString(),
                Padding = new Padding
                {
                    Top = 10,
                    Bottom = 10,
                },
            };
            panel.Dock = DockStyle.Bottom;

            Label keyLabel = new Label
            {
                Location = new Point(0, 0),
                Size = new Size(80, 21),
                Text = Name,
                Name = "KeyLabel" + Guid.NewGuid().ToString(),
            };

            TextBox valueTextBox = new TextBox
            {
                Location = new Point(90, 0),
                Size = new Size(160, 21),
                Text = !String.IsNullOrEmpty(Value) ? Value : "密码",
                ForeColor = !String.IsNullOrEmpty(Value) ? Color.Black : Color.Gray,
                Name = "ValueTextBox_" + Guid.NewGuid().ToString(),
            };

            valueTextBox.Enter += (object sender, EventArgs e) =>
            {
                var textbox = sender as TextBox;
                if (textbox == null) return;
                if (ProjectDetailAction == DetailAction.Display) return;
                if (textbox.Text.Equals("密码"))
                {
                    textbox.ForeColor = Color.Black;
                    textbox.Text = String.Empty;
                }
            };

            valueTextBox.Leave += (object sender, EventArgs e) =>
            {
                var textbox = sender as TextBox;
                if (textbox == null) return;
                if (ProjectDetailAction == DetailAction.Display) return;
                if (SelectPassworkProject == null) return;

                SelectPassworkProject.UpdatePassword(keyLabel.Text.Trim(), textbox.Text.Trim());

                if (textbox.Text.Equals(String.Empty))
                {
                    textbox.ForeColor = Color.Gray;
                    textbox.Text = "密码";
                }
            };

            TextBox remarkTextBox = new TextBox
            {
                Location = new Point(280, 0),
                Size = new Size(160, 21),
                Text =   !String.IsNullOrEmpty(Remark) ? Remark : "备注",
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
                ForeColor = !String.IsNullOrEmpty(Remark) ? Color.Black : Color.Gray,
                Name = "RemarkTextBox_" + Guid.NewGuid().ToString(),
            };

            remarkTextBox.Enter += (object sender, EventArgs e) =>
            {
                var textbox = sender as TextBox;
                if (textbox == null) return;
                if (ProjectDetailAction == DetailAction.Display) return;
                if (textbox.Text.Equals("备注"))
                {
                    textbox.ForeColor = Color.Black;
                    textbox.Text = String.Empty;
                }
            };

            remarkTextBox.Leave += (object sender, EventArgs e) =>
            {
                var textbox = sender as TextBox;
                if (textbox == null) return;
                if (ProjectDetailAction == DetailAction.Display) return;
                if (SelectPassworkProject == null) return;

                SelectPassworkProject.UpdatePasswordRemark(keyLabel.Text.Trim(), textbox.Text.Trim());

                if (textbox.Text.Equals(String.Empty))
                {
                    textbox.ForeColor = Color.Gray;
                    textbox.Text = "备注";
                }
            };
            Button removeButton = new Button
            {
                Text = "删除",
                Location = new Point(450, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Size = new Size(75, 23),
            };
            removeButton.Click += (sender, e) =>
            {
                try
                {
                    if (SelectPassworkProject == null) return;
                    SelectPassworkProject.RemovePasswordItem(keyLabel.Text.Trim());
                    parentControl.Controls.Remove(panel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "温馨提示");
                }
            };

            parentControl.Controls.Add(panel);
            panel.Controls.Add(keyLabel);
            panel.Controls.Add(valueTextBox);
            panel.Controls.Add(remarkTextBox);
            panel.Controls.Add(removeButton);
        }

        private void textBox_Address_Leave(object sender, EventArgs e)
        {
            if (ProjectDetailAction == DetailAction.Display) return;
            if (SelectPassworkProject == null) return;
            SelectPassworkProject.Address = textBox_Address.Text.Trim();
        }

        private void textBox_Account_Leave(object sender, EventArgs e)
        {
            if (ProjectDetailAction == DetailAction.Display) return;
            if (SelectPassworkProject == null) return;
            SelectPassworkProject.Account = textBox_Account.Text.Trim();
        }

        private void textBox_Email_Leave(object sender, EventArgs e)
        {
            if (ProjectDetailAction == DetailAction.Display) return;
            if (SelectPassworkProject == null) return;
            SelectPassworkProject.Email = textBox_Email.Text.Trim();
        }

        private void textBox_MobilPhone_Leave(object sender, EventArgs e)
        {
            if (ProjectDetailAction == DetailAction.Display) return;
            if (SelectPassworkProject == null) return;
            SelectPassworkProject.MobilPhone = textBox_MobilPhone.Text.Trim();
        }

        private void toolStripButton_UpdateLoginPassword_Click(object sender, EventArgs e)
        {
            new UpdatePassword(repository)
            {
                TopMost = true
            }.Show();
        }
    }

    public class DetailActionChangeEventArg : EventArgs
    {
        public DetailAction DetailAction { get; private set; }
        public DetailActionChangeEventArg(DetailAction DetailAction)
        {
            this.DetailAction = DetailAction;
        }
    }

    public enum DetailAction
    {
        /// <summary>
        /// 显示
        /// </summary>
        Display=0,
        /// <summary>
        /// 添加数据
        /// </summary>
        AddNew=1,
        /// <summary>
        /// 更新数据
        /// </summary>
        Edit=2,
    }
}
