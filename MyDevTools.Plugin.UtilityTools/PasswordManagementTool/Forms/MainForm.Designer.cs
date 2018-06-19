namespace MyDevTools.Plugin.UtilityTools.PasswordManagementTool.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Remove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddExtendField = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddSafetyProblems = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_AddPassrowdItem = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProjectList = new System.Windows.Forms.ListBox();
            this.groupBox_ProjectDetail = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox_PasswordItems = new System.Windows.Forms.GroupBox();
            this.panel_PasswordItems = new System.Windows.Forms.Panel();
            this.groupBox_SafetyProblems = new System.Windows.Forms.GroupBox();
            this.panel_SafetyProblems = new System.Windows.Forms.Panel();
            this.groupBox_ExtendField = new System.Windows.Forms.GroupBox();
            this.panel_ExtensionFields = new System.Windows.Forms.Panel();
            this.groupBox_base = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Account = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_MobilPhone = new System.Windows.Forms.TextBox();
            this.toolStripButton_UpdateLoginPassword = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_ProjectDetail.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox_PasswordItems.SuspendLayout();
            this.groupBox_SafetyProblems.SuspendLayout();
            this.groupBox_ExtendField.SuspendLayout();
            this.groupBox_base.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Save,
            this.toolStripButton_AddNew,
            this.toolStripButton_Edit,
            this.toolStripButton_Remove,
            this.toolStripButton_AddExtendField,
            this.toolStripButton_AddSafetyProblems,
            this.toolStripButton_AddPassrowdItem,
            this.toolStripButton_UpdateLoginPassword});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Save.Image")));
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Save.Text = "保存";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripButton_AddNew
            // 
            this.toolStripButton_AddNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddNew.Image")));
            this.toolStripButton_AddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddNew.Name = "toolStripButton_AddNew";
            this.toolStripButton_AddNew.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_AddNew.Text = "新增";
            this.toolStripButton_AddNew.Click += new System.EventHandler(this.toolStripButton_AddNew_Click);
            // 
            // toolStripButton_Edit
            // 
            this.toolStripButton_Edit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Edit.Image")));
            this.toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Edit.Name = "toolStripButton_Edit";
            this.toolStripButton_Edit.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Edit.Text = "编辑";
            this.toolStripButton_Edit.Click += new System.EventHandler(this.toolStripButton_Edit_Click);
            // 
            // toolStripButton_Remove
            // 
            this.toolStripButton_Remove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Remove.Image")));
            this.toolStripButton_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Remove.Name = "toolStripButton_Remove";
            this.toolStripButton_Remove.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_Remove.Text = "删除";
            this.toolStripButton_Remove.Click += new System.EventHandler(this.toolStripButton_Remove_Click);
            // 
            // toolStripButton_AddExtendField
            // 
            this.toolStripButton_AddExtendField.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddExtendField.Image")));
            this.toolStripButton_AddExtendField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddExtendField.Name = "toolStripButton_AddExtendField";
            this.toolStripButton_AddExtendField.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton_AddExtendField.Text = "添加扩展字段";
            this.toolStripButton_AddExtendField.Click += new System.EventHandler(this.toolStripButton_AddExtendField_Click);
            // 
            // toolStripButton_AddSafetyProblems
            // 
            this.toolStripButton_AddSafetyProblems.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddSafetyProblems.Image")));
            this.toolStripButton_AddSafetyProblems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddSafetyProblems.Name = "toolStripButton_AddSafetyProblems";
            this.toolStripButton_AddSafetyProblems.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton_AddSafetyProblems.Text = "添加安全问题";
            this.toolStripButton_AddSafetyProblems.Click += new System.EventHandler(this.toolStripButton_AddSafetyProblems_Click);
            // 
            // toolStripButton_AddPassrowdItem
            // 
            this.toolStripButton_AddPassrowdItem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_AddPassrowdItem.Image")));
            this.toolStripButton_AddPassrowdItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_AddPassrowdItem.Name = "toolStripButton_AddPassrowdItem";
            this.toolStripButton_AddPassrowdItem.Size = new System.Drawing.Size(76, 22);
            this.toolStripButton_AddPassrowdItem.Text = "添加密码";
            this.toolStripButton_AddPassrowdItem.Click += new System.EventHandler(this.toolStripButton_AddPassrowdItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox_ProjectDetail);
            this.splitContainer1.Size = new System.Drawing.Size(784, 682);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ProjectList);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 676);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "密码项目列表";
            // 
            // ProjectList
            // 
            this.ProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProjectList.FormattingEnabled = true;
            this.ProjectList.ItemHeight = 12;
            this.ProjectList.Location = new System.Drawing.Point(6, 20);
            this.ProjectList.Name = "ProjectList";
            this.ProjectList.Size = new System.Drawing.Size(222, 640);
            this.ProjectList.TabIndex = 0;
            this.ProjectList.SelectedIndexChanged += new System.EventHandler(this.ProjectList_SelectedIndexChanged);
            // 
            // groupBox_ProjectDetail
            // 
            this.groupBox_ProjectDetail.Controls.Add(this.panel2);
            this.groupBox_ProjectDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_ProjectDetail.Location = new System.Drawing.Point(0, 0);
            this.groupBox_ProjectDetail.Name = "groupBox_ProjectDetail";
            this.groupBox_ProjectDetail.Size = new System.Drawing.Size(538, 682);
            this.groupBox_ProjectDetail.TabIndex = 0;
            this.groupBox_ProjectDetail.TabStop = false;
            this.groupBox_ProjectDetail.Text = "密码项目明细";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox_PasswordItems);
            this.panel2.Controls.Add(this.groupBox_SafetyProblems);
            this.panel2.Controls.Add(this.groupBox_ExtendField);
            this.panel2.Controls.Add(this.groupBox_base);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 662);
            this.panel2.TabIndex = 6;
            // 
            // groupBox_PasswordItems
            // 
            this.groupBox_PasswordItems.AutoSize = true;
            this.groupBox_PasswordItems.Controls.Add(this.panel_PasswordItems);
            this.groupBox_PasswordItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_PasswordItems.Location = new System.Drawing.Point(0, 204);
            this.groupBox_PasswordItems.Name = "groupBox_PasswordItems";
            this.groupBox_PasswordItems.Size = new System.Drawing.Size(532, 20);
            this.groupBox_PasswordItems.TabIndex = 8;
            this.groupBox_PasswordItems.TabStop = false;
            this.groupBox_PasswordItems.Text = "密码";
            // 
            // panel_PasswordItems
            // 
            this.panel_PasswordItems.AutoSize = true;
            this.panel_PasswordItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_PasswordItems.Location = new System.Drawing.Point(3, 17);
            this.panel_PasswordItems.Name = "panel_PasswordItems";
            this.panel_PasswordItems.Size = new System.Drawing.Size(526, 0);
            this.panel_PasswordItems.TabIndex = 0;
            // 
            // groupBox_SafetyProblems
            // 
            this.groupBox_SafetyProblems.AutoSize = true;
            this.groupBox_SafetyProblems.Controls.Add(this.panel_SafetyProblems);
            this.groupBox_SafetyProblems.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_SafetyProblems.Location = new System.Drawing.Point(0, 184);
            this.groupBox_SafetyProblems.Name = "groupBox_SafetyProblems";
            this.groupBox_SafetyProblems.Size = new System.Drawing.Size(532, 20);
            this.groupBox_SafetyProblems.TabIndex = 7;
            this.groupBox_SafetyProblems.TabStop = false;
            this.groupBox_SafetyProblems.Text = "安全问题";
            // 
            // panel_SafetyProblems
            // 
            this.panel_SafetyProblems.AutoSize = true;
            this.panel_SafetyProblems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_SafetyProblems.Location = new System.Drawing.Point(3, 17);
            this.panel_SafetyProblems.Name = "panel_SafetyProblems";
            this.panel_SafetyProblems.Size = new System.Drawing.Size(526, 0);
            this.panel_SafetyProblems.TabIndex = 0;
            // 
            // groupBox_ExtendField
            // 
            this.groupBox_ExtendField.AutoSize = true;
            this.groupBox_ExtendField.Controls.Add(this.panel_ExtensionFields);
            this.groupBox_ExtendField.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_ExtendField.Location = new System.Drawing.Point(0, 164);
            this.groupBox_ExtendField.Name = "groupBox_ExtendField";
            this.groupBox_ExtendField.Size = new System.Drawing.Size(532, 20);
            this.groupBox_ExtendField.TabIndex = 6;
            this.groupBox_ExtendField.TabStop = false;
            this.groupBox_ExtendField.Text = "扩展字段";
            // 
            // panel_ExtensionFields
            // 
            this.panel_ExtensionFields.AutoSize = true;
            this.panel_ExtensionFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ExtensionFields.Location = new System.Drawing.Point(3, 17);
            this.panel_ExtensionFields.Name = "panel_ExtensionFields";
            this.panel_ExtensionFields.Size = new System.Drawing.Size(526, 0);
            this.panel_ExtensionFields.TabIndex = 0;
            // 
            // groupBox_base
            // 
            this.groupBox_base.Controls.Add(this.panel1);
            this.groupBox_base.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_base.Location = new System.Drawing.Point(0, 0);
            this.groupBox_base.Name = "groupBox_base";
            this.groupBox_base.Size = new System.Drawing.Size(532, 164);
            this.groupBox_base.TabIndex = 9;
            this.groupBox_base.TabStop = false;
            this.groupBox_base.Text = "基础信息";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_Name);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_Account);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_Email);
            this.panel1.Controls.Add(this.textBox_Address);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_MobilPhone);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 144);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Name.Location = new System.Drawing.Point(62, 9);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(458, 21);
            this.textBox_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "地址";
            // 
            // textBox_Account
            // 
            this.textBox_Account.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Account.Location = new System.Drawing.Point(62, 62);
            this.textBox_Account.Name = "textBox_Account";
            this.textBox_Account.Size = new System.Drawing.Size(458, 21);
            this.textBox_Account.TabIndex = 1;
            this.textBox_Account.Leave += new System.EventHandler(this.textBox_Account_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "账号";
            // 
            // textBox_Email
            // 
            this.textBox_Email.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Email.Location = new System.Drawing.Point(62, 89);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(458, 21);
            this.textBox_Email.TabIndex = 1;
            this.textBox_Email.Leave += new System.EventHandler(this.textBox_Email_Leave);
            // 
            // textBox_Address
            // 
            this.textBox_Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Address.Location = new System.Drawing.Point(62, 36);
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(458, 21);
            this.textBox_Address.TabIndex = 1;
            this.textBox_Address.Leave += new System.EventHandler(this.textBox_Address_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "电子邮件";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "移动电话";
            // 
            // textBox_MobilPhone
            // 
            this.textBox_MobilPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_MobilPhone.Location = new System.Drawing.Point(62, 120);
            this.textBox_MobilPhone.Name = "textBox_MobilPhone";
            this.textBox_MobilPhone.Size = new System.Drawing.Size(458, 21);
            this.textBox_MobilPhone.TabIndex = 1;
            this.textBox_MobilPhone.Leave += new System.EventHandler(this.textBox_MobilPhone_Leave);
            // 
            // toolStripButton_UpdateLoginPassword
            // 
            this.toolStripButton_UpdateLoginPassword.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_UpdateLoginPassword.Image")));
            this.toolStripButton_UpdateLoginPassword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_UpdateLoginPassword.Name = "toolStripButton_UpdateLoginPassword";
            this.toolStripButton_UpdateLoginPassword.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton_UpdateLoginPassword.Text = "修改登录密码";
            this.toolStripButton_UpdateLoginPassword.Click += new System.EventHandler(this.toolStripButton_UpdateLoginPassword_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 707);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "密码管理工具";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox_ProjectDetail.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox_PasswordItems.ResumeLayout(false);
            this.groupBox_PasswordItems.PerformLayout();
            this.groupBox_SafetyProblems.ResumeLayout(false);
            this.groupBox_SafetyProblems.PerformLayout();
            this.groupBox_ExtendField.ResumeLayout(false);
            this.groupBox_ExtendField.PerformLayout();
            this.groupBox_base.ResumeLayout(false);
            this.groupBox_base.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ProjectList;
        private System.Windows.Forms.ToolStripButton toolStripButton_Save;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddNew;
        private System.Windows.Forms.ToolStripButton toolStripButton_Edit;
        private System.Windows.Forms.ToolStripButton toolStripButton_Remove;
        private System.Windows.Forms.GroupBox groupBox_ProjectDetail;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddExtendField;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddSafetyProblems;
        private System.Windows.Forms.ToolStripButton toolStripButton_AddPassrowdItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox_PasswordItems;
        private System.Windows.Forms.Panel panel_PasswordItems;
        private System.Windows.Forms.GroupBox groupBox_SafetyProblems;
        private System.Windows.Forms.Panel panel_SafetyProblems;
        private System.Windows.Forms.GroupBox groupBox_ExtendField;
        private System.Windows.Forms.Panel panel_ExtensionFields;
        private System.Windows.Forms.GroupBox groupBox_base;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Account;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_MobilPhone;
        private System.Windows.Forms.ToolStripButton toolStripButton_UpdateLoginPassword;
    }
}