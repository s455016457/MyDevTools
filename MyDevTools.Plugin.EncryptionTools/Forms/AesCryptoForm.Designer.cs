﻿namespace MyDevTools.Plugin.EncryptionTools.Forms
{
    partial class AesCryptoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.textBox_IV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Body = new System.Windows.Forms.TextBox();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.btn_CreateKey = new System.Windows.Forms.Button();
            this.btn_Encrypt = new System.Windows.Forms.Button();
            this.btn_Decrypt = new System.Windows.Forms.Button();
            this.btn_CopyResult = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_EncryptType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_KeyDisplayFormat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_CiphertextDisplayFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "秘钥";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "偏移量";
            // 
            // textBox_Key
            // 
            this.textBox_Key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Key.Location = new System.Drawing.Point(75, 10);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(603, 21);
            this.textBox_Key.TabIndex = 2;
            this.textBox_Key.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBox_IV
            // 
            this.textBox_IV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_IV.Location = new System.Drawing.Point(75, 42);
            this.textBox_IV.Name = "textBox_IV";
            this.textBox_IV.Size = new System.Drawing.Size(603, 21);
            this.textBox_IV.TabIndex = 3;
            this.textBox_IV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "待处理文本";
            // 
            // textBox_Body
            // 
            this.textBox_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Body.Location = new System.Drawing.Point(20, 121);
            this.textBox_Body.Multiline = true;
            this.textBox_Body.Name = "textBox_Body";
            this.textBox_Body.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Body.Size = new System.Drawing.Size(658, 101);
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
            // btn_CreateKey
            // 
            this.btn_CreateKey.Location = new System.Drawing.Point(20, 228);
            this.btn_CreateKey.Name = "btn_CreateKey";
            this.btn_CreateKey.Size = new System.Drawing.Size(75, 23);
            this.btn_CreateKey.TabIndex = 7;
            this.btn_CreateKey.Text = "创建秘钥";
            this.btn_CreateKey.UseVisualStyleBackColor = true;
            this.btn_CreateKey.Click += new System.EventHandler(this.btn_CreateKey_Click);
            // 
            // btn_Encrypt
            // 
            this.btn_Encrypt.Location = new System.Drawing.Point(101, 228);
            this.btn_Encrypt.Name = "btn_Encrypt";
            this.btn_Encrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_Encrypt.TabIndex = 8;
            this.btn_Encrypt.Text = "加密";
            this.btn_Encrypt.UseVisualStyleBackColor = true;
            this.btn_Encrypt.Click += new System.EventHandler(this.btn_Encrypt_Click);
            // 
            // btn_Decrypt
            // 
            this.btn_Decrypt.Location = new System.Drawing.Point(182, 228);
            this.btn_Decrypt.Name = "btn_Decrypt";
            this.btn_Decrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_Decrypt.TabIndex = 9;
            this.btn_Decrypt.Text = "解密";
            this.btn_Decrypt.UseVisualStyleBackColor = true;
            this.btn_Decrypt.Click += new System.EventHandler(this.btn_Decrypt_Click);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "加密方式";
            // 
            // comboBox_EncryptType
            // 
            this.comboBox_EncryptType.FormattingEnabled = true;
            this.comboBox_EncryptType.Items.AddRange(new object[] {
            "无偏移量加密",
            "有偏移量加密"});
            this.comboBox_EncryptType.Location = new System.Drawing.Point(75, 73);
            this.comboBox_EncryptType.Name = "comboBox_EncryptType";
            this.comboBox_EncryptType.Size = new System.Drawing.Size(124, 20);
            this.comboBox_EncryptType.TabIndex = 12;
            this.comboBox_EncryptType.SelectedIndexChanged += new System.EventHandler(this.comboBox_EncryptType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "秘钥显示格式";
            // 
            // comboBox_KeyDisplayFormat
            // 
            this.comboBox_KeyDisplayFormat.FormattingEnabled = true;
            this.comboBox_KeyDisplayFormat.Items.AddRange(new object[] {
            "Base64String",
            "BitString"});
            this.comboBox_KeyDisplayFormat.Location = new System.Drawing.Point(310, 71);
            this.comboBox_KeyDisplayFormat.Name = "comboBox_KeyDisplayFormat";
            this.comboBox_KeyDisplayFormat.Size = new System.Drawing.Size(124, 20);
            this.comboBox_KeyDisplayFormat.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(470, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "密文显示格式";
            // 
            // comboBox_CiphertextDisplayFormat
            // 
            this.comboBox_CiphertextDisplayFormat.FormattingEnabled = true;
            this.comboBox_CiphertextDisplayFormat.Items.AddRange(new object[] {
            "Base64String",
            "BitString"});
            this.comboBox_CiphertextDisplayFormat.Location = new System.Drawing.Point(554, 73);
            this.comboBox_CiphertextDisplayFormat.Name = "comboBox_CiphertextDisplayFormat";
            this.comboBox_CiphertextDisplayFormat.Size = new System.Drawing.Size(124, 20);
            this.comboBox_CiphertextDisplayFormat.TabIndex = 12;
            // 
            // AesCryptoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 397);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_CiphertextDisplayFormat);
            this.Controls.Add(this.comboBox_KeyDisplayFormat);
            this.Controls.Add(this.comboBox_EncryptType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_CopyResult);
            this.Controls.Add(this.btn_Decrypt);
            this.Controls.Add(this.btn_Encrypt);
            this.Controls.Add(this.btn_CreateKey);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.textBox_Body);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_IV);
            this.Controls.Add(this.textBox_Key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AesCryptoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AES加密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.TextBox textBox_IV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Body;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.Button btn_CreateKey;
        private System.Windows.Forms.Button btn_Encrypt;
        private System.Windows.Forms.Button btn_Decrypt;
        private System.Windows.Forms.Button btn_CopyResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_EncryptType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_KeyDisplayFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_CiphertextDisplayFormat;
    }
}