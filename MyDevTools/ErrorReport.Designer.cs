namespace MyDevTools
{
    partial class ErrorReport
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNote = new System.Windows.Forms.Label();
            this.rtbErrors = new System.Windows.Forms.RichTextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnReStart = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MyDevTools.Properties.Resources.cry;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbNote
            // 
            this.lbNote.Location = new System.Drawing.Point(79, 13);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(361, 50);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "很抱歉，我们遇到了尚未能处理的异常。异常信息显示在下面，请将这些信息连同关于您的操作的描述一起反馈给我们以帮助我们解决问题，谢谢。";
            // 
            // rtbErrors
            // 
            this.rtbErrors.BackColor = System.Drawing.SystemColors.Control;
            this.rtbErrors.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbErrors.Location = new System.Drawing.Point(3, 66);
            this.rtbErrors.Name = "rtbErrors";
            this.rtbErrors.ReadOnly = true;
            this.rtbErrors.Size = new System.Drawing.Size(441, 149);
            this.rtbErrors.TabIndex = 0;
            this.rtbErrors.Text = "正在收集异常信息，请稍候……";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(3, 222);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "复制异常信息";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnReStart
            // 
            this.btnReStart.Location = new System.Drawing.Point(279, 222);
            this.btnReStart.Name = "btnReStart";
            this.btnReStart.Size = new System.Drawing.Size(75, 23);
            this.btnReStart.TabIndex = 2;
            this.btnReStart.Text = "重启程序";
            this.btnReStart.UseVisualStyleBackColor = true;
            this.btnReStart.Click += new System.EventHandler(this.btnReStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(360, 222);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ErrorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 250);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReStart);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.rtbErrors);
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ErrorReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应用程序错误";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.RichTextBox rtbErrors;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnReStart;
        private System.Windows.Forms.Button btnClose;
    }
}