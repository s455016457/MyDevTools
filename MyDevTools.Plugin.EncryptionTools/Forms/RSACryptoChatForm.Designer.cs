namespace MyDevTools.Plugin.EncryptionTools.Forms
{
    partial class RSACryptoChatForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AliceSend = new System.Windows.Forms.Button();
            this.AliceSendText = new System.Windows.Forms.TextBox();
            this.AliceChatHistory = new System.Windows.Forms.TextBox();
            this.AlicePublicKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BobSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BobSendText = new System.Windows.Forms.TextBox();
            this.BobChatHistory = new System.Windows.Forms.TextBox();
            this.BobPublicKey = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_console = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AliceSend);
            this.groupBox1.Controls.Add(this.AliceSendText);
            this.groupBox1.Controls.Add(this.AliceChatHistory);
            this.groupBox1.Controls.Add(this.AlicePublicKey);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 586);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alice";
            // 
            // AliceSend
            // 
            this.AliceSend.Location = new System.Drawing.Point(9, 554);
            this.AliceSend.Name = "AliceSend";
            this.AliceSend.Size = new System.Drawing.Size(75, 23);
            this.AliceSend.TabIndex = 6;
            this.AliceSend.Text = "发送";
            this.AliceSend.UseVisualStyleBackColor = true;
            this.AliceSend.Click += new System.EventHandler(this.AliceSend_Click);
            // 
            // AliceSendText
            // 
            this.AliceSendText.Location = new System.Drawing.Point(9, 425);
            this.AliceSendText.Multiline = true;
            this.AliceSendText.Name = "AliceSendText";
            this.AliceSendText.Size = new System.Drawing.Size(450, 123);
            this.AliceSendText.TabIndex = 5;
            this.AliceSendText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // AliceChatHistory
            // 
            this.AliceChatHistory.Location = new System.Drawing.Point(9, 48);
            this.AliceChatHistory.Multiline = true;
            this.AliceChatHistory.Name = "AliceChatHistory";
            this.AliceChatHistory.ReadOnly = true;
            this.AliceChatHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AliceChatHistory.Size = new System.Drawing.Size(450, 353);
            this.AliceChatHistory.TabIndex = 4;
            this.AliceChatHistory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // AlicePublicKey
            // 
            this.AlicePublicKey.Location = new System.Drawing.Point(45, 21);
            this.AlicePublicKey.Name = "AlicePublicKey";
            this.AlicePublicKey.ReadOnly = true;
            this.AlicePublicKey.Size = new System.Drawing.Size(414, 21);
            this.AlicePublicKey.TabIndex = 2;
            this.AlicePublicKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "公钥：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BobSend);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.BobSendText);
            this.groupBox2.Controls.Add(this.BobChatHistory);
            this.groupBox2.Controls.Add(this.BobPublicKey);
            this.groupBox2.Location = new System.Drawing.Point(514, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 586);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bob";
            // 
            // BobSend
            // 
            this.BobSend.Location = new System.Drawing.Point(8, 554);
            this.BobSend.Name = "BobSend";
            this.BobSend.Size = new System.Drawing.Size(75, 23);
            this.BobSend.TabIndex = 13;
            this.BobSend.Text = "发送";
            this.BobSend.UseVisualStyleBackColor = true;
            this.BobSend.Click += new System.EventHandler(this.BobSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "公钥：";
            // 
            // BobSendText
            // 
            this.BobSendText.Location = new System.Drawing.Point(8, 425);
            this.BobSendText.Multiline = true;
            this.BobSendText.Name = "BobSendText";
            this.BobSendText.Size = new System.Drawing.Size(450, 123);
            this.BobSendText.TabIndex = 12;
            this.BobSendText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // BobChatHistory
            // 
            this.BobChatHistory.Location = new System.Drawing.Point(8, 44);
            this.BobChatHistory.Multiline = true;
            this.BobChatHistory.Name = "BobChatHistory";
            this.BobChatHistory.ReadOnly = true;
            this.BobChatHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BobChatHistory.Size = new System.Drawing.Size(450, 357);
            this.BobChatHistory.TabIndex = 11;
            this.BobChatHistory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // BobPublicKey
            // 
            this.BobPublicKey.Location = new System.Drawing.Point(44, 17);
            this.BobPublicKey.Name = "BobPublicKey";
            this.BobPublicKey.ReadOnly = true;
            this.BobPublicKey.Size = new System.Drawing.Size(414, 21);
            this.BobPublicKey.TabIndex = 9;
            this.BobPublicKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_console);
            this.groupBox3.Location = new System.Drawing.Point(12, 605);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(969, 170);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "控制台";
            // 
            // textBox_console
            // 
            this.textBox_console.Location = new System.Drawing.Point(1, 20);
            this.textBox_console.Multiline = true;
            this.textBox_console.Name = "textBox_console";
            this.textBox_console.ReadOnly = true;
            this.textBox_console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_console.Size = new System.Drawing.Size(962, 144);
            this.textBox_console.TabIndex = 7;
            this.textBox_console.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // RSACryptoChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 787);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RSACryptoChatForm";
            this.Text = "非对称加密聊天";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AliceSend;
        private System.Windows.Forms.TextBox AliceSendText;
        private System.Windows.Forms.TextBox AliceChatHistory;
        private System.Windows.Forms.TextBox AlicePublicKey;
        private System.Windows.Forms.Button BobSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox BobSendText;
        private System.Windows.Forms.TextBox BobChatHistory;
        private System.Windows.Forms.TextBox BobPublicKey;
        private System.Windows.Forms.TextBox textBox_console;
    }
}