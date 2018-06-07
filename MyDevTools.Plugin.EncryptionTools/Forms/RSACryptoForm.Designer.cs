namespace MyDevTools.Plugin.EncryptionTools
{
    partial class RSACryptoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RSACryptoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_PublicKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_PrivateKey = new System.Windows.Forms.TextBox();
            this.CreateKey = new System.Windows.Forms.Button();
            this.CopyPublicKey = new System.Windows.Forms.Button();
            this.CopyPrivateKey = new System.Windows.Forms.Button();
            this.textBox_Body = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PublicKeyEncrypt = new System.Windows.Forms.Button();
            this.PublicKeyVerifyHash = new System.Windows.Forms.Button();
            this.PrivateKeySigna = new System.Windows.Forms.Button();
            this.PrivateKeyDncrypt = new System.Windows.Forms.Button();
            this.CopyCryptBody = new System.Windows.Forms.Button();
            this.textBox_CryptBody = new System.Windows.Forms.TextBox();
            this.textBox_Signa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CopySigna = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "公钥";
            // 
            // textBox_PublicKey
            // 
            this.textBox_PublicKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PublicKey.Location = new System.Drawing.Point(39, 10);
            this.textBox_PublicKey.Name = "textBox_PublicKey";
            this.textBox_PublicKey.Size = new System.Drawing.Size(843, 21);
            this.textBox_PublicKey.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "私钥";
            // 
            // textBox_PrivateKey
            // 
            this.textBox_PrivateKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PrivateKey.Location = new System.Drawing.Point(39, 37);
            this.textBox_PrivateKey.Name = "textBox_PrivateKey";
            this.textBox_PrivateKey.Size = new System.Drawing.Size(843, 21);
            this.textBox_PrivateKey.TabIndex = 3;
            // 
            // CreateKey
            // 
            this.CreateKey.Location = new System.Drawing.Point(12, 74);
            this.CreateKey.Name = "CreateKey";
            this.CreateKey.Size = new System.Drawing.Size(75, 23);
            this.CreateKey.TabIndex = 4;
            this.CreateKey.Text = "创建秘钥";
            this.CreateKey.UseVisualStyleBackColor = true;
            this.CreateKey.Click += new System.EventHandler(this.CreateKey_Click);
            // 
            // CopyPublicKey
            // 
            this.CopyPublicKey.Location = new System.Drawing.Point(93, 74);
            this.CopyPublicKey.Name = "CopyPublicKey";
            this.CopyPublicKey.Size = new System.Drawing.Size(75, 23);
            this.CopyPublicKey.TabIndex = 5;
            this.CopyPublicKey.Text = "复制公钥";
            this.CopyPublicKey.UseVisualStyleBackColor = true;
            this.CopyPublicKey.Click += new System.EventHandler(this.CopyPublicKey_Click);
            // 
            // CopyPrivateKey
            // 
            this.CopyPrivateKey.Location = new System.Drawing.Point(174, 74);
            this.CopyPrivateKey.Name = "CopyPrivateKey";
            this.CopyPrivateKey.Size = new System.Drawing.Size(75, 23);
            this.CopyPrivateKey.TabIndex = 6;
            this.CopyPrivateKey.Text = "复制私钥";
            this.CopyPrivateKey.UseVisualStyleBackColor = true;
            this.CopyPrivateKey.Click += new System.EventHandler(this.CopyPrivateKey_Click);
            // 
            // textBox_Body
            // 
            this.textBox_Body.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Body.Location = new System.Drawing.Point(6, 126);
            this.textBox_Body.Multiline = true;
            this.textBox_Body.Name = "textBox_Body";
            this.textBox_Body.Size = new System.Drawing.Size(876, 136);
            this.textBox_Body.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "待处理文本";
            // 
            // PublicKeyEncrypt
            // 
            this.PublicKeyEncrypt.Location = new System.Drawing.Point(6, 333);
            this.PublicKeyEncrypt.Name = "PublicKeyEncrypt";
            this.PublicKeyEncrypt.Size = new System.Drawing.Size(75, 23);
            this.PublicKeyEncrypt.TabIndex = 9;
            this.PublicKeyEncrypt.Text = "公钥加密";
            this.PublicKeyEncrypt.UseVisualStyleBackColor = true;
            this.PublicKeyEncrypt.Click += new System.EventHandler(this.PublicKeyEncrypt_Click);
            // 
            // PublicKeyVerifyHash
            // 
            this.PublicKeyVerifyHash.Location = new System.Drawing.Point(87, 333);
            this.PublicKeyVerifyHash.Name = "PublicKeyVerifyHash";
            this.PublicKeyVerifyHash.Size = new System.Drawing.Size(75, 23);
            this.PublicKeyVerifyHash.TabIndex = 10;
            this.PublicKeyVerifyHash.Text = "公钥验证签名";
            this.PublicKeyVerifyHash.UseVisualStyleBackColor = true;
            this.PublicKeyVerifyHash.Click += new System.EventHandler(this.PublicKeyVerifyHash_Click);
            // 
            // PrivateKeySigna
            // 
            this.PrivateKeySigna.Location = new System.Drawing.Point(168, 333);
            this.PrivateKeySigna.Name = "PrivateKeySigna";
            this.PrivateKeySigna.Size = new System.Drawing.Size(75, 23);
            this.PrivateKeySigna.TabIndex = 11;
            this.PrivateKeySigna.Text = "私钥签名";
            this.PrivateKeySigna.UseVisualStyleBackColor = true;
            this.PrivateKeySigna.Click += new System.EventHandler(this.PrivateKeySigna_Click);
            // 
            // PrivateKeyDncrypt
            // 
            this.PrivateKeyDncrypt.Location = new System.Drawing.Point(249, 333);
            this.PrivateKeyDncrypt.Name = "PrivateKeyDncrypt";
            this.PrivateKeyDncrypt.Size = new System.Drawing.Size(75, 23);
            this.PrivateKeyDncrypt.TabIndex = 12;
            this.PrivateKeyDncrypt.Text = "私钥解密";
            this.PrivateKeyDncrypt.UseVisualStyleBackColor = true;
            this.PrivateKeyDncrypt.Click += new System.EventHandler(this.PrivateKeyDncrypt_Click);
            // 
            // CopyCryptBody
            // 
            this.CopyCryptBody.Location = new System.Drawing.Point(411, 333);
            this.CopyCryptBody.Name = "CopyCryptBody";
            this.CopyCryptBody.Size = new System.Drawing.Size(75, 23);
            this.CopyCryptBody.TabIndex = 13;
            this.CopyCryptBody.Text = "复制密文";
            this.CopyCryptBody.UseVisualStyleBackColor = true;
            this.CopyCryptBody.Click += new System.EventHandler(this.CopyCryptBody_Click);
            // 
            // textBox_CryptBody
            // 
            this.textBox_CryptBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CryptBody.Location = new System.Drawing.Point(6, 390);
            this.textBox_CryptBody.Multiline = true;
            this.textBox_CryptBody.Name = "textBox_CryptBody";
            this.textBox_CryptBody.ReadOnly = true;
            this.textBox_CryptBody.Size = new System.Drawing.Size(876, 125);
            this.textBox_CryptBody.TabIndex = 14;
            // 
            // textBox_Signa
            // 
            this.textBox_Signa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Signa.Location = new System.Drawing.Point(6, 282);
            this.textBox_Signa.Multiline = true;
            this.textBox_Signa.Name = "textBox_Signa";
            this.textBox_Signa.Size = new System.Drawing.Size(876, 44);
            this.textBox_Signa.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "签名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "密文";
            // 
            // CopySigna
            // 
            this.CopySigna.Location = new System.Drawing.Point(330, 333);
            this.CopySigna.Name = "CopySigna";
            this.CopySigna.Size = new System.Drawing.Size(75, 23);
            this.CopySigna.TabIndex = 18;
            this.CopySigna.Text = "复制签名";
            this.CopySigna.UseVisualStyleBackColor = true;
            this.CopySigna.Click += new System.EventHandler(this.CopySigna_Click);
            // 
            // RSACryptoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 520);
            this.Controls.Add(this.CopySigna);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Signa);
            this.Controls.Add(this.textBox_CryptBody);
            this.Controls.Add(this.CopyCryptBody);
            this.Controls.Add(this.PrivateKeyDncrypt);
            this.Controls.Add(this.PrivateKeySigna);
            this.Controls.Add(this.PublicKeyVerifyHash);
            this.Controls.Add(this.PublicKeyEncrypt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Body);
            this.Controls.Add(this.CopyPrivateKey);
            this.Controls.Add(this.CopyPublicKey);
            this.Controls.Add(this.CreateKey);
            this.Controls.Add(this.textBox_PrivateKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_PublicKey);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RSACryptoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSA加密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_PublicKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PrivateKey;
        private System.Windows.Forms.Button CreateKey;
        private System.Windows.Forms.Button CopyPublicKey;
        private System.Windows.Forms.Button CopyPrivateKey;
        private System.Windows.Forms.TextBox textBox_Body;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PublicKeyEncrypt;
        private System.Windows.Forms.Button PublicKeyVerifyHash;
        private System.Windows.Forms.Button PrivateKeySigna;
        private System.Windows.Forms.Button PrivateKeyDncrypt;
        private System.Windows.Forms.Button CopyCryptBody;
        private System.Windows.Forms.TextBox textBox_CryptBody;
        private System.Windows.Forms.TextBox textBox_Signa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CopySigna;
    }
}