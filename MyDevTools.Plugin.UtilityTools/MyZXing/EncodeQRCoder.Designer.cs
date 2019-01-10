namespace MyDevTools.Plugin.UtilityTools.MyZXing
{
    partial class EncodeQRCoder
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
            this.textBoxContext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CEELevel = new System.Windows.Forms.ComboBox();
            this.btnCreateQrCoder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.iconPath = new System.Windows.Forms.TextBox();
            this.btnSelectIcon = new System.Windows.Forms.Button();
            this.textBoxImageSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveQrCoder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxImageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxContext
            // 
            this.textBoxContext.Location = new System.Drawing.Point(12, 12);
            this.textBoxContext.Multiline = true;
            this.textBoxContext.Name = "textBoxContext";
            this.textBoxContext.Size = new System.Drawing.Size(514, 115);
            this.textBoxContext.TabIndex = 13;
            this.textBoxContext.TextChanged += new System.EventHandler(this.textBoxContext_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "纠错码等级";
            // 
            // CEELevel
            // 
            this.CEELevel.FormattingEnabled = true;
            this.CEELevel.Items.AddRange(new object[] {
            "L",
            "M",
            "Q",
            "H"});
            this.CEELevel.Location = new System.Drawing.Point(81, 167);
            this.CEELevel.Name = "CEELevel";
            this.CEELevel.Size = new System.Drawing.Size(157, 20);
            this.CEELevel.TabIndex = 15;
            this.CEELevel.Text = "L";
            // 
            // btnCreateQrCoder
            // 
            this.btnCreateQrCoder.Location = new System.Drawing.Point(451, 164);
            this.btnCreateQrCoder.Name = "btnCreateQrCoder";
            this.btnCreateQrCoder.Size = new System.Drawing.Size(75, 23);
            this.btnCreateQrCoder.TabIndex = 16;
            this.btnCreateQrCoder.Text = "生成二维码";
            this.btnCreateQrCoder.UseVisualStyleBackColor = true;
            this.btnCreateQrCoder.Click += new System.EventHandler(this.btnCreateQrCoder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "图片";
            // 
            // iconPath
            // 
            this.iconPath.Location = new System.Drawing.Point(81, 139);
            this.iconPath.Name = "iconPath";
            this.iconPath.Size = new System.Drawing.Size(346, 21);
            this.iconPath.TabIndex = 18;
            // 
            // btnSelectIcon
            // 
            this.btnSelectIcon.Location = new System.Drawing.Point(451, 135);
            this.btnSelectIcon.Name = "btnSelectIcon";
            this.btnSelectIcon.Size = new System.Drawing.Size(75, 23);
            this.btnSelectIcon.TabIndex = 19;
            this.btnSelectIcon.Text = "选择";
            this.btnSelectIcon.UseVisualStyleBackColor = true;
            this.btnSelectIcon.Click += new System.EventHandler(this.btnSelectIcon_Click);
            // 
            // textBoxImageSize
            // 
            this.textBoxImageSize.Location = new System.Drawing.Point(70, 715);
            this.textBoxImageSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.textBoxImageSize.Name = "textBoxImageSize";
            this.textBoxImageSize.Size = new System.Drawing.Size(168, 21);
            this.textBoxImageSize.TabIndex = 23;
            this.textBoxImageSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 718);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "图片大小";
            // 
            // btnSaveQrCoder
            // 
            this.btnSaveQrCoder.Location = new System.Drawing.Point(451, 713);
            this.btnSaveQrCoder.Name = "btnSaveQrCoder";
            this.btnSaveQrCoder.Size = new System.Drawing.Size(75, 23);
            this.btnSaveQrCoder.TabIndex = 22;
            this.btnSaveQrCoder.Text = "保存二维码";
            this.btnSaveQrCoder.UseVisualStyleBackColor = true;
            this.btnSaveQrCoder.Click += new System.EventHandler(this.btnSaveQrCoder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 193);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 514);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // EncodeQRCoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 747);
            this.Controls.Add(this.textBoxImageSize);
            this.Controls.Add(this.btnSaveQrCoder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSelectIcon);
            this.Controls.Add(this.iconPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateQrCoder);
            this.Controls.Add(this.CEELevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxContext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EncodeQRCoder";
            this.Text = "EncodeQRCoder";
            ((System.ComponentModel.ISupportInitialize)(this.textBoxImageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CEELevel;
        private System.Windows.Forms.Button btnCreateQrCoder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox iconPath;
        private System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.NumericUpDown textBoxImageSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveQrCoder;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}