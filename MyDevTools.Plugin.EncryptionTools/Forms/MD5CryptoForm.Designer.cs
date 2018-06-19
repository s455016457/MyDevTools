namespace MyDevTools.Plugin.EncryptionTools.Forms
{
    partial class MD5CryptoForm
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
            this.textBox_body = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.button_Md5Crypto = new System.Windows.Forms.Button();
            this.button_HashCrypto = new System.Windows.Forms.Button();
            this.button_CopyResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "字符串";
            // 
            // textBox_body
            // 
            this.textBox_body.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_body.Location = new System.Drawing.Point(72, 13);
            this.textBox_body.Multiline = true;
            this.textBox_body.Name = "textBox_body";
            this.textBox_body.Size = new System.Drawing.Size(509, 86);
            this.textBox_body.TabIndex = 1;
            this.textBox_body.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Md5/Hash";
            // 
            // textBox_Result
            // 
            this.textBox_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Result.Location = new System.Drawing.Point(72, 105);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.ReadOnly = true;
            this.textBox_Result.Size = new System.Drawing.Size(509, 86);
            this.textBox_Result.TabIndex = 3;
            this.textBox_Result.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // button_Md5Crypto
            // 
            this.button_Md5Crypto.Location = new System.Drawing.Point(72, 197);
            this.button_Md5Crypto.Name = "button_Md5Crypto";
            this.button_Md5Crypto.Size = new System.Drawing.Size(75, 23);
            this.button_Md5Crypto.TabIndex = 4;
            this.button_Md5Crypto.Text = "MD5";
            this.button_Md5Crypto.UseVisualStyleBackColor = true;
            this.button_Md5Crypto.Click += new System.EventHandler(this.button_Md5Crypto_Click);
            // 
            // button_HashCrypto
            // 
            this.button_HashCrypto.Location = new System.Drawing.Point(153, 197);
            this.button_HashCrypto.Name = "button_HashCrypto";
            this.button_HashCrypto.Size = new System.Drawing.Size(75, 23);
            this.button_HashCrypto.TabIndex = 5;
            this.button_HashCrypto.Text = "Hash";
            this.button_HashCrypto.UseVisualStyleBackColor = true;
            this.button_HashCrypto.Click += new System.EventHandler(this.button_HashCrypto_Click);
            // 
            // button_CopyResult
            // 
            this.button_CopyResult.Location = new System.Drawing.Point(234, 197);
            this.button_CopyResult.Name = "button_CopyResult";
            this.button_CopyResult.Size = new System.Drawing.Size(75, 23);
            this.button_CopyResult.TabIndex = 6;
            this.button_CopyResult.Text = "复制结果";
            this.button_CopyResult.UseVisualStyleBackColor = true;
            this.button_CopyResult.Click += new System.EventHandler(this.button_CopyResult_Click);
            // 
            // MD5CryptoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 230);
            this.Controls.Add(this.button_CopyResult);
            this.Controls.Add(this.button_HashCrypto);
            this.Controls.Add(this.button_Md5Crypto);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_body);
            this.Controls.Add(this.label1);
            this.Name = "MD5CryptoForm";
            this.Text = "MD5CryptoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_body;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Button button_Md5Crypto;
        private System.Windows.Forms.Button button_HashCrypto;
        private System.Windows.Forms.Button button_CopyResult;
    }
}