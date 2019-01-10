namespace MyDevTools.Plugin.UtilityTools.MyZXing
{
    partial class EncodeBarCode
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BarCodeType = new System.Windows.Forms.ComboBox();
            this.btnCreateBarCode = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSaveBarCode = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(546, 115);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "条码类型";
            // 
            // BarCodeType
            // 
            this.BarCodeType.FormattingEnabled = true;
            this.BarCodeType.Items.AddRange(new object[] {
            "AZTEC",
            "CODABAR",
            "CODE_39",
            "CODE_93",
            "CODE_128",
            "DATA_MATRIX",
            "EAN_8",
            "EAN_13",
            "ITF",
            "MAXICODE",
            "PDF_417",
            "QR_CODE",
            "RSS_14",
            "RSS_EXPANDED",
            "UPC_A",
            "UPC_E",
            "All_1D",
            "UPC_EAN_EXTENSION",
            "MSI",
            "PLESSEY",
            "IMB"});
            this.BarCodeType.Location = new System.Drawing.Point(72, 132);
            this.BarCodeType.Name = "BarCodeType";
            this.BarCodeType.Size = new System.Drawing.Size(120, 20);
            this.BarCodeType.TabIndex = 2;
            this.BarCodeType.Text = "AZTEC";
            this.BarCodeType.TextChanged += new System.EventHandler(this.BarCodeType_TextChanged);
            // 
            // btnCreateBarCode
            // 
            this.btnCreateBarCode.Location = new System.Drawing.Point(435, 130);
            this.btnCreateBarCode.Name = "btnCreateBarCode";
            this.btnCreateBarCode.Size = new System.Drawing.Size(124, 23);
            this.btnCreateBarCode.TabIndex = 3;
            this.btnCreateBarCode.Text = "生产条形码";
            this.btnCreateBarCode.UseVisualStyleBackColor = true;
            this.btnCreateBarCode.Click += new System.EventHandler(this.btnCreateBarCode_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(544, 476);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnSaveBarCode
            // 
            this.btnSaveBarCode.Location = new System.Drawing.Point(444, 641);
            this.btnSaveBarCode.Name = "btnSaveBarCode";
            this.btnSaveBarCode.Size = new System.Drawing.Size(124, 23);
            this.btnSaveBarCode.TabIndex = 5;
            this.btnSaveBarCode.Text = "保存条形码";
            this.btnSaveBarCode.UseVisualStyleBackColor = true;
            this.btnSaveBarCode.Click += new System.EventHandler(this.btnSaveBarCode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "留白";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(245, 133);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 21);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // EncodeBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 676);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveBarCode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCreateBarCode);
            this.Controls.Add(this.BarCodeType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "EncodeBarCode";
            this.Text = "EncodeBarCode";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BarCodeType;
        private System.Windows.Forms.Button btnCreateBarCode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSaveBarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}