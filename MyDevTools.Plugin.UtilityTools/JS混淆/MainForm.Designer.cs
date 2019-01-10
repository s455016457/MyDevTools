namespace MyDevTools.Plugin.UtilityTools.JS混淆
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
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfusion = new System.Windows.Forms.Button();
            this.btnUnobfuscate = new System.Windows.Forms.Button();
            this.btnFileConfusion = new System.Windows.Forms.Button();
            this.btnFileUnobfuscate = new System.Windows.Forms.Button();
            this.buttonCopyResult = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(12, 28);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(765, 192);
            this.textBoxSource.TabIndex = 0;
            this.textBoxSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(12, 279);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(765, 184);
            this.textBoxResult.TabIndex = 1;
            this.textBoxResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "源代码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "处理结果";
            // 
            // btnConfusion
            // 
            this.btnConfusion.Location = new System.Drawing.Point(17, 227);
            this.btnConfusion.Name = "btnConfusion";
            this.btnConfusion.Size = new System.Drawing.Size(75, 23);
            this.btnConfusion.TabIndex = 4;
            this.btnConfusion.Text = "混淆";
            this.btnConfusion.UseVisualStyleBackColor = true;
            this.btnConfusion.Click += new System.EventHandler(this.btnConfusion_Click);
            // 
            // btnUnobfuscate
            // 
            this.btnUnobfuscate.Location = new System.Drawing.Point(98, 226);
            this.btnUnobfuscate.Name = "btnUnobfuscate";
            this.btnUnobfuscate.Size = new System.Drawing.Size(75, 23);
            this.btnUnobfuscate.TabIndex = 5;
            this.btnUnobfuscate.Text = "反混淆";
            this.btnUnobfuscate.UseVisualStyleBackColor = true;
            this.btnUnobfuscate.Click += new System.EventHandler(this.btnUnobfuscate_Click);
            // 
            // btnFileConfusion
            // 
            this.btnFileConfusion.Location = new System.Drawing.Point(260, 227);
            this.btnFileConfusion.Name = "btnFileConfusion";
            this.btnFileConfusion.Size = new System.Drawing.Size(85, 23);
            this.btnFileConfusion.TabIndex = 6;
            this.btnFileConfusion.Text = "选择混淆文件";
            this.btnFileConfusion.UseVisualStyleBackColor = true;
            this.btnFileConfusion.Click += new System.EventHandler(this.btnFileConfusion_ClickAsync);
            // 
            // btnFileUnobfuscate
            // 
            this.btnFileUnobfuscate.Location = new System.Drawing.Point(351, 227);
            this.btnFileUnobfuscate.Name = "btnFileUnobfuscate";
            this.btnFileUnobfuscate.Size = new System.Drawing.Size(98, 23);
            this.btnFileUnobfuscate.TabIndex = 7;
            this.btnFileUnobfuscate.Text = "选择反混淆文件";
            this.btnFileUnobfuscate.UseVisualStyleBackColor = true;
            this.btnFileUnobfuscate.Click += new System.EventHandler(this.btnFileUnobfuscate_Click);
            // 
            // buttonCopyResult
            // 
            this.buttonCopyResult.Location = new System.Drawing.Point(179, 227);
            this.buttonCopyResult.Name = "buttonCopyResult";
            this.buttonCopyResult.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyResult.TabIndex = 8;
            this.buttonCopyResult.Text = "复制结果";
            this.buttonCopyResult.UseVisualStyleBackColor = true;
            this.buttonCopyResult.Click += new System.EventHandler(this.buttonCopyResult_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "文本文件(*.txt)|*.txt|Js文件(*.js)|*.js";
            this.openFileDialog1.Multiselect = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 475);
            this.Controls.Add(this.buttonCopyResult);
            this.Controls.Add(this.btnFileUnobfuscate);
            this.Controls.Add(this.btnFileConfusion);
            this.Controls.Add(this.btnUnobfuscate);
            this.Controls.Add(this.btnConfusion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.textBoxSource);
            this.Name = "MainForm";
            this.Text = "JS混淆工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfusion;
        private System.Windows.Forms.Button btnUnobfuscate;
        private System.Windows.Forms.Button btnFileConfusion;
        private System.Windows.Forms.Button btnFileUnobfuscate;
        private System.Windows.Forms.Button buttonCopyResult;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}