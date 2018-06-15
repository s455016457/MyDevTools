namespace MyDevTools.Plugin.EncryptionTools.Forms
{
    partial class HMACSHA1SignForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Sign = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Body = new System.Windows.Forms.TextBox();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.btn_CreateSign = new System.Windows.Forms.Button();
            this.btn_Encrypt = new System.Windows.Forms.Button();
            this.btn_Verify = new System.Windows.Forms.Button();
            this.btn_CopyResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "签名";
            // 
            // textBox_Sign
            // 
            this.textBox_Sign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Sign.Location = new System.Drawing.Point(75, 10);
            this.textBox_Sign.Name = "textBox_Sign";
            this.textBox_Sign.Size = new System.Drawing.Size(603, 21);
            this.textBox_Sign.TabIndex = 2;
            this.textBox_Sign.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "待处理文本";
            // 
            // textBox_Body
            // 
            this.textBox_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Body.Location = new System.Drawing.Point(20, 49);
            this.textBox_Body.Multiline = true;
            this.textBox_Body.Name = "textBox_Body";
            this.textBox_Body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Body.Size = new System.Drawing.Size(658, 173);
            this.textBox_Body.TabIndex = 5;
            this.textBox_Body.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBox_Result
            // 
            this.textBox_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Result.Location = new System.Drawing.Point(20, 257);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ReadOnly = true;
            this.textBox_Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Result.Size = new System.Drawing.Size(658, 128);
            this.textBox_Result.TabIndex = 6;
            this.textBox_Result.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // btn_CreateSign
            // 
            this.btn_CreateSign.Location = new System.Drawing.Point(20, 228);
            this.btn_CreateSign.Name = "btn_CreateSign";
            this.btn_CreateSign.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateSign.TabIndex = 7;
            this.btn_CreateSign.Text = "创建签名";
            this.btn_CreateSign.UseVisualStyleBackColor = true;
            this.btn_CreateSign.Click += new System.EventHandler(this.btn_CreateSign_Click);
            // 
            // btn_Encrypt
            // 
            this.btn_Encrypt.Location = new System.Drawing.Point(101, 228);
            this.btn_Encrypt.Name = "btn_Encrypt";
            this.btn_Encrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_Encrypt.TabIndex = 8;
            this.btn_Encrypt.Text = "加密";
            this.btn_Encrypt.UseVisualStyleBackColor = true;
            this.btn_Encrypt.Click += new System.EventHandler(this.btn_DoSign_Click);
            // 
            // btn_Verify
            // 
            this.btn_Verify.Location = new System.Drawing.Point(182, 228);
            this.btn_Verify.Name = "btn_Verify";
            this.btn_Verify.Size = new System.Drawing.Size(75, 23);
            this.btn_Verify.TabIndex = 9;
            this.btn_Verify.Text = "验证";
            this.btn_Verify.UseVisualStyleBackColor = true;
            this.btn_Verify.Click += new System.EventHandler(this.btn_Verify_Click);
            // 
            // btn_CopyResult
            // 
            this.btn_CopyResult.Location = new System.Drawing.Point(263, 228);
            this.btn_CopyResult.Name = "btn_CopyResult";
            this.btn_CopyResult.Size = new System.Drawing.Size(75, 23);
            this.btn_CopyResult.TabIndex = 10;
            this.btn_CopyResult.Text = "复制结果";
            this.btn_CopyResult.UseVisualStyleBackColor = true;
            this.btn_CopyResult.Click += new System.EventHandler(this.btn_CopyResult_Click);
            // 
            // HMACSHA1SignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 397);
            this.Controls.Add(this.btn_CopyResult);
            this.Controls.Add(this.btn_Verify);
            this.Controls.Add(this.btn_Encrypt);
            this.Controls.Add(this.btn_CreateSign);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.textBox_Body);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Sign);
            this.Controls.Add(this.label1);
            this.Name = "HMACSHA1SignForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HMACSHA1签名";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Sign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Body;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Button btn_CreateSign;
        private System.Windows.Forms.Button btn_Encrypt;
        private System.Windows.Forms.Button btn_Verify;
        private System.Windows.Forms.Button btn_CopyResult;
    }
}