namespace Microsoft.Win32.TaskScheduler.UIComponents
{
    partial class SendNotificationActionUI
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.msgMsgText = new System.Windows.Forms.TextBox();
            this.msgMsgLabel = new System.Windows.Forms.Label();
            this.msgTitleText = new System.Windows.Forms.TextBox();
            this.msgTitleLabel = new System.Windows.Forms.Label();
            this.msgIntroLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msgMsgText
            // 
            this.msgMsgText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgMsgText.Location = new System.Drawing.Point(90, 55);
            this.msgMsgText.Multiline = true;
            this.msgMsgText.Name = "msgMsgText";
            this.msgMsgText.Size = new System.Drawing.Size(366, 271);
            this.msgMsgText.TabIndex = 14;
            this.msgMsgText.TextChanged += new System.EventHandler(this.msgMsgText_TextChanged);
            // 
            // msgMsgLabel
            // 
            this.msgMsgLabel.AutoSize = true;
            this.msgMsgLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.msgMsgLabel.Location = new System.Drawing.Point(3, 59);
            this.msgMsgLabel.Name = "msgMsgLabel";
            this.msgMsgLabel.Size = new System.Drawing.Size(41, 12);
            this.msgMsgLabel.TabIndex = 13;
            this.msgMsgLabel.Text = "信息：";
            // 
            // msgTitleText
            // 
            this.msgTitleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgTitleText.Location = new System.Drawing.Point(90, 25);
            this.msgTitleText.Name = "msgTitleText";
            this.msgTitleText.Size = new System.Drawing.Size(366, 21);
            this.msgTitleText.TabIndex = 12;
            // 
            // msgTitleLabel
            // 
            this.msgTitleLabel.AutoSize = true;
            this.msgTitleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.msgTitleLabel.Location = new System.Drawing.Point(3, 29);
            this.msgTitleLabel.Name = "msgTitleLabel";
            this.msgTitleLabel.Size = new System.Drawing.Size(41, 12);
            this.msgTitleLabel.TabIndex = 11;
            this.msgTitleLabel.Text = "标题：";
            // 
            // msgIntroLabel
            // 
            this.msgIntroLabel.AutoSize = true;
            this.msgIntroLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.msgIntroLabel.Location = new System.Drawing.Point(3, 0);
            this.msgIntroLabel.Name = "msgIntroLabel";
            this.msgIntroLabel.Size = new System.Drawing.Size(209, 12);
            this.msgIntroLabel.TabIndex = 10;
            this.msgIntroLabel.Text = "这个动作在王操作系统推送一个消息。";
            // 
            // SendNotificationActionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.msgMsgText);
            this.Controls.Add(this.msgMsgLabel);
            this.Controls.Add(this.msgTitleText);
            this.Controls.Add(this.msgTitleLabel);
            this.Controls.Add(this.msgIntroLabel);
            this.Name = "SendNotificationActionUI";
            this.Size = new System.Drawing.Size(456, 326);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox msgMsgText;
        private System.Windows.Forms.Label msgMsgLabel;
        private System.Windows.Forms.TextBox msgTitleText;
        private System.Windows.Forms.Label msgTitleLabel;
        private System.Windows.Forms.Label msgIntroLabel;
    }
}
