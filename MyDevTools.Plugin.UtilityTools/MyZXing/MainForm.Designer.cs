namespace MyDevTools.Plugin.UtilityTools.MyZXing
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
            this.btnEncodeQRCode = new System.Windows.Forms.Button();
            this.btnDecodeQRCode = new System.Windows.Forms.Button();
            this.btnEncodeBarCode = new System.Windows.Forms.Button();
            this.btnDecodeBarCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEncodeQRCode
            // 
            this.btnEncodeQRCode.Location = new System.Drawing.Point(4, 102);
            this.btnEncodeQRCode.Name = "btnEncodeQRCode";
            this.btnEncodeQRCode.Size = new System.Drawing.Size(272, 39);
            this.btnEncodeQRCode.TabIndex = 0;
            this.btnEncodeQRCode.Text = "生成二维码";
            this.btnEncodeQRCode.UseVisualStyleBackColor = true;
            this.btnEncodeQRCode.Click += new System.EventHandler(this.btnEncodeQRCode_Click);
            // 
            // btnDecodeQRCode
            // 
            this.btnDecodeQRCode.Location = new System.Drawing.Point(4, 147);
            this.btnDecodeQRCode.Name = "btnDecodeQRCode";
            this.btnDecodeQRCode.Size = new System.Drawing.Size(272, 39);
            this.btnDecodeQRCode.TabIndex = 1;
            this.btnDecodeQRCode.Text = "识别二维码";
            this.btnDecodeQRCode.UseVisualStyleBackColor = true;
            this.btnDecodeQRCode.Click += new System.EventHandler(this.btnDecodeQRCode_Click);
            // 
            // btnEncodeBarCode
            // 
            this.btnEncodeBarCode.Location = new System.Drawing.Point(4, 12);
            this.btnEncodeBarCode.Name = "btnEncodeBarCode";
            this.btnEncodeBarCode.Size = new System.Drawing.Size(272, 39);
            this.btnEncodeBarCode.TabIndex = 2;
            this.btnEncodeBarCode.Text = "生成条形码";
            this.btnEncodeBarCode.UseVisualStyleBackColor = true;
            this.btnEncodeBarCode.Click += new System.EventHandler(this.btnEncodeBarCode_Click);
            // 
            // btnDecodeBarCode
            // 
            this.btnDecodeBarCode.Location = new System.Drawing.Point(4, 57);
            this.btnDecodeBarCode.Name = "btnDecodeBarCode";
            this.btnDecodeBarCode.Size = new System.Drawing.Size(272, 39);
            this.btnDecodeBarCode.TabIndex = 3;
            this.btnDecodeBarCode.Text = "识别条形码";
            this.btnDecodeBarCode.UseVisualStyleBackColor = true;
            this.btnDecodeBarCode.Click += new System.EventHandler(this.btnDecodeBarCode_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 197);
            this.Controls.Add(this.btnDecodeBarCode);
            this.Controls.Add(this.btnEncodeBarCode);
            this.Controls.Add(this.btnDecodeQRCode);
            this.Controls.Add(this.btnEncodeQRCode);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEncodeQRCode;
        private System.Windows.Forms.Button btnDecodeQRCode;
        private System.Windows.Forms.Button btnEncodeBarCode;
        private System.Windows.Forms.Button btnDecodeBarCode;
    }
}