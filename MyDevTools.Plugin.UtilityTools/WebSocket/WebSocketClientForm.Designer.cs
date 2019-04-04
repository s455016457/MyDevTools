namespace MyDevTools.Plugin.UtilityTools.WebSocket
{
    partial class WebSocketClientForm
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
            this.components = new System.ComponentModel.Container();
            this.btnOpen = new System.Windows.Forms.Button();
            this.textBox_SubProtocol = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.textBox_Ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGrid_RequestHead = new System.Windows.Forms.DataGridView();
            this.RequestHead_Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestHead_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGrid_RequestCookie = new System.Windows.Forms.DataGridView();
            this.Cookies_Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cookies_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_RequestHead)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_RequestCookie)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(14, 247);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 13;
            this.btnOpen.Text = "连接";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_ClickAsync);
            // 
            // textBox_SubProtocol
            // 
            this.textBox_SubProtocol.Location = new System.Drawing.Point(563, 6);
            this.textBox_SubProtocol.Name = "textBox_SubProtocol";
            this.textBox_SubProtocol.Size = new System.Drawing.Size(181, 21);
            this.textBox_SubProtocol.TabIndex = 12;
            this.textBox_SubProtocol.Text = "chat";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(317, 6);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(161, 21);
            this.textBox_Port.TabIndex = 11;
            this.textBox_Port.Text = "8081";
            this.textBox_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Port_KeyPress);
            // 
            // textBox_Ip
            // 
            this.textBox_Ip.Location = new System.Drawing.Point(59, 6);
            this.textBox_Ip.Name = "textBox_Ip";
            this.textBox_Ip.Size = new System.Drawing.Size(199, 21);
            this.textBox_Ip.TabIndex = 10;
            this.textBox_Ip.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "子协议";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP地址";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "请求头";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "Cookies";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGrid_RequestHead);
            this.panel1.Location = new System.Drawing.Point(14, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 184);
            this.panel1.TabIndex = 16;
            // 
            // dataGrid_RequestHead
            // 
            this.dataGrid_RequestHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_RequestHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestHead_Key,
            this.RequestHead_Value});
            this.dataGrid_RequestHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_RequestHead.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_RequestHead.Name = "dataGrid_RequestHead";
            this.dataGrid_RequestHead.RowTemplate.Height = 23;
            this.dataGrid_RequestHead.Size = new System.Drawing.Size(369, 184);
            this.dataGrid_RequestHead.TabIndex = 0;
            // 
            // RequestHead_Key
            // 
            this.RequestHead_Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RequestHead_Key.HeaderText = "Key";
            this.RequestHead_Key.Name = "RequestHead_Key";
            // 
            // RequestHead_Value
            // 
            this.RequestHead_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RequestHead_Value.HeaderText = "Value";
            this.RequestHead_Value.Name = "RequestHead_Value";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGrid_RequestCookie);
            this.panel2.Location = new System.Drawing.Point(392, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 184);
            this.panel2.TabIndex = 17;
            // 
            // dataGrid_RequestCookie
            // 
            this.dataGrid_RequestCookie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_RequestCookie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cookies_Key,
            this.Cookies_Value});
            this.dataGrid_RequestCookie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_RequestCookie.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_RequestCookie.Name = "dataGrid_RequestCookie";
            this.dataGrid_RequestCookie.RowTemplate.Height = 23;
            this.dataGrid_RequestCookie.Size = new System.Drawing.Size(396, 184);
            this.dataGrid_RequestCookie.TabIndex = 0;
            // 
            // Cookies_Key
            // 
            this.Cookies_Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cookies_Key.HeaderText = "Key";
            this.Cookies_Key.Name = "Cookies_Key";
            // 
            // Cookies_Value
            // 
            this.Cookies_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cookies_Value.HeaderText = "Value";
            this.Cookies_Value.Name = "Cookies_Value";
            // 
            // textBox_Send
            // 
            this.textBox_Send.Location = new System.Drawing.Point(14, 277);
            this.textBox_Send.Multiline = true;
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.Size = new System.Drawing.Size(774, 90);
            this.textBox_Send.TabIndex = 18;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(14, 373);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 19;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Log.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_Log.Location = new System.Drawing.Point(12, 402);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.ReadOnly = true;
            this.richTextBox_Log.Size = new System.Drawing.Size(776, 179);
            this.richTextBox_Log.TabIndex = 20;
            this.richTextBox_Log.Text = "";
            // 
            // WebSocketClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.Controls.Add(this.richTextBox_Log);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textBox_Send);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.textBox_SubProtocol);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_Ip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WebSocketClientForm";
            this.Text = "WebSocket客户端";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_RequestHead)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_RequestCookie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox textBox_SubProtocol;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.TextBox textBox_Ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGrid_RequestHead;
        private System.Windows.Forms.DataGridView dataGrid_RequestCookie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cookies_Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cookies_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestHead_Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestHead_Value;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
    }
}