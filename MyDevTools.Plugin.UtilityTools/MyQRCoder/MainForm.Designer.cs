namespace MyDevTools.Plugin.UtilityTools.MyQRCoder
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
            this.textBoxContext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CEELevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iconPath = new System.Windows.Forms.TextBox();
            this.btnSelectIcon = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveQrCoder = new System.Windows.Forms.Button();
            this.textBoxImageSize = new System.Windows.Forms.NumericUpDown();
            this.btnCreateQrCoder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxImageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxContext
            // 
            this.textBoxContext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContext.Location = new System.Drawing.Point(12, 28);
            this.textBoxContext.Multiline = true;
            this.textBoxContext.Name = "textBoxContext";
            this.textBoxContext.Size = new System.Drawing.Size(514, 115);
            this.textBoxContext.TabIndex = 0;
            this.textBoxContext.TextChanged += new System.EventHandler(this.textBoxContext_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "内容";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
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
            this.CEELevel.Location = new System.Drawing.Point(81, 183);
            this.CEELevel.Name = "CEELevel";
            this.CEELevel.Size = new System.Drawing.Size(157, 20);
            this.CEELevel.TabIndex = 3;
            this.CEELevel.Text = "L";
            this.CEELevel.SelectedValueChanged += new System.EventHandler(this.CEELevel_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "图片";
            // 
            // iconPath
            // 
            this.iconPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPath.Location = new System.Drawing.Point(81, 155);
            this.iconPath.Name = "iconPath";
            this.iconPath.Size = new System.Drawing.Size(346, 21);
            this.iconPath.TabIndex = 6;
            // 
            // btnSelectIcon
            // 
            this.btnSelectIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectIcon.Location = new System.Drawing.Point(451, 151);
            this.btnSelectIcon.Name = "btnSelectIcon";
            this.btnSelectIcon.Size = new System.Drawing.Size(75, 23);
            this.btnSelectIcon.TabIndex = 7;
            this.btnSelectIcon.Text = "选择";
            this.btnSelectIcon.UseVisualStyleBackColor = true;
            this.btnSelectIcon.Click += new System.EventHandler(this.btnSelectIcon_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 209);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 514);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 734);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "图片大小";
            // 
            // btnSaveQrCoder
            // 
            this.btnSaveQrCoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveQrCoder.Location = new System.Drawing.Point(451, 729);
            this.btnSaveQrCoder.Name = "btnSaveQrCoder";
            this.btnSaveQrCoder.Size = new System.Drawing.Size(75, 23);
            this.btnSaveQrCoder.TabIndex = 11;
            this.btnSaveQrCoder.Text = "保存二维码";
            this.btnSaveQrCoder.UseVisualStyleBackColor = true;
            this.btnSaveQrCoder.Click += new System.EventHandler(this.btnSaveQrCoder_Click);
            // 
            // textBoxImageSize
            // 
            this.textBoxImageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxImageSize.Location = new System.Drawing.Point(70, 731);
            this.textBoxImageSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.textBoxImageSize.Name = "textBoxImageSize";
            this.textBoxImageSize.Size = new System.Drawing.Size(168, 21);
            this.textBoxImageSize.TabIndex = 12;
            this.textBoxImageSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnCreateQrCoder
            // 
            this.btnCreateQrCoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateQrCoder.Location = new System.Drawing.Point(451, 180);
            this.btnCreateQrCoder.Name = "btnCreateQrCoder";
            this.btnCreateQrCoder.Size = new System.Drawing.Size(75, 23);
            this.btnCreateQrCoder.TabIndex = 4;
            this.btnCreateQrCoder.Text = "生成二维码";
            this.btnCreateQrCoder.UseVisualStyleBackColor = true;
            this.btnCreateQrCoder.Click += new System.EventHandler(this.btnCreateQrCoder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 760);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxContext);
            this.Name = "MainForm";
            this.Text = "二维码生成器";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxImageSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CEELevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox iconPath;
        private System.Windows.Forms.Button btnSelectIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveQrCoder;
        private System.Windows.Forms.NumericUpDown textBoxImageSize;
        private System.Windows.Forms.Button btnCreateQrCoder;
    }
}