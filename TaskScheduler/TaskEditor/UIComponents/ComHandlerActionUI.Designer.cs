namespace Microsoft.Win32.TaskScheduler.UIComponents
{
	partial class ComHandlerActionUI
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComHandlerActionUI));
            this.getCLSIDButton = new System.Windows.Forms.Button();
            this.clsidMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lookupCLSIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuallyEnterCLSIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comDataText = new System.Windows.Forms.TextBox();
            this.comDataLabel = new System.Windows.Forms.Label();
            this.comCLSIDText = new System.Windows.Forms.TextBox();
            this.comCLSIDLabel = new System.Windows.Forms.Label();
            this.comIntroLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.clsidMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // getCLSIDButton
            // 
            resources.ApplyResources(this.getCLSIDButton, "getCLSIDButton");
            this.getCLSIDButton.CausesValidation = false;
            this.getCLSIDButton.ContextMenuStrip = this.clsidMenuStrip;
            this.errorProvider.SetError(this.getCLSIDButton, resources.GetString("getCLSIDButton.Error"));
            this.errorProvider.SetIconAlignment(this.getCLSIDButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("getCLSIDButton.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.getCLSIDButton, ((int)(resources.GetObject("getCLSIDButton.IconPadding"))));
            this.getCLSIDButton.Name = "getCLSIDButton";
            this.toolTip.SetToolTip(this.getCLSIDButton, resources.GetString("getCLSIDButton.ToolTip"));
            this.getCLSIDButton.UseVisualStyleBackColor = true;
            this.getCLSIDButton.Click += new System.EventHandler(this.getCLSIDButton_Click);
            // 
            // clsidMenuStrip
            // 
            resources.ApplyResources(this.clsidMenuStrip, "clsidMenuStrip");
            this.errorProvider.SetError(this.clsidMenuStrip, resources.GetString("clsidMenuStrip.Error"));
            this.errorProvider.SetIconAlignment(this.clsidMenuStrip, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("clsidMenuStrip.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.clsidMenuStrip, ((int)(resources.GetObject("clsidMenuStrip.IconPadding"))));
            this.clsidMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lookupCLSIDToolStripMenuItem,
            this.manuallyEnterCLSIDToolStripMenuItem});
            this.clsidMenuStrip.Name = "clsidMenuStrip";
            this.clsidMenuStrip.ShowImageMargin = false;
            this.toolTip.SetToolTip(this.clsidMenuStrip, resources.GetString("clsidMenuStrip.ToolTip"));
            // 
            // lookupCLSIDToolStripMenuItem
            // 
            resources.ApplyResources(this.lookupCLSIDToolStripMenuItem, "lookupCLSIDToolStripMenuItem");
            this.lookupCLSIDToolStripMenuItem.Name = "lookupCLSIDToolStripMenuItem";
            this.lookupCLSIDToolStripMenuItem.Click += new System.EventHandler(this.lookupCLSIDToolStripMenuItem_Click);
            // 
            // manuallyEnterCLSIDToolStripMenuItem
            // 
            resources.ApplyResources(this.manuallyEnterCLSIDToolStripMenuItem, "manuallyEnterCLSIDToolStripMenuItem");
            this.manuallyEnterCLSIDToolStripMenuItem.Name = "manuallyEnterCLSIDToolStripMenuItem";
            this.manuallyEnterCLSIDToolStripMenuItem.Click += new System.EventHandler(this.manuallyEnterCLSIDToolStripMenuItem_Click);
            // 
            // comDataText
            // 
            resources.ApplyResources(this.comDataText, "comDataText");
            this.errorProvider.SetError(this.comDataText, resources.GetString("comDataText.Error"));
            this.errorProvider.SetIconAlignment(this.comDataText, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comDataText.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.comDataText, ((int)(resources.GetObject("comDataText.IconPadding"))));
            this.comDataText.Name = "comDataText";
            this.toolTip.SetToolTip(this.comDataText, resources.GetString("comDataText.ToolTip"));
            // 
            // comDataLabel
            // 
            resources.ApplyResources(this.comDataLabel, "comDataLabel");
            this.errorProvider.SetError(this.comDataLabel, resources.GetString("comDataLabel.Error"));
            this.errorProvider.SetIconAlignment(this.comDataLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comDataLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.comDataLabel, ((int)(resources.GetObject("comDataLabel.IconPadding"))));
            this.comDataLabel.Name = "comDataLabel";
            this.toolTip.SetToolTip(this.comDataLabel, resources.GetString("comDataLabel.ToolTip"));
            // 
            // comCLSIDText
            // 
            resources.ApplyResources(this.comCLSIDText, "comCLSIDText");
            this.errorProvider.SetError(this.comCLSIDText, resources.GetString("comCLSIDText.Error"));
            this.errorProvider.SetIconAlignment(this.comCLSIDText, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comCLSIDText.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.comCLSIDText, ((int)(resources.GetObject("comCLSIDText.IconPadding"))));
            this.comCLSIDText.Name = "comCLSIDText";
            this.comCLSIDText.ReadOnly = true;
            this.toolTip.SetToolTip(this.comCLSIDText, resources.GetString("comCLSIDText.ToolTip"));
            this.comCLSIDText.Validating += new System.ComponentModel.CancelEventHandler(this.comCLSIDText_Validating);
            // 
            // comCLSIDLabel
            // 
            resources.ApplyResources(this.comCLSIDLabel, "comCLSIDLabel");
            this.errorProvider.SetError(this.comCLSIDLabel, resources.GetString("comCLSIDLabel.Error"));
            this.errorProvider.SetIconAlignment(this.comCLSIDLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comCLSIDLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.comCLSIDLabel, ((int)(resources.GetObject("comCLSIDLabel.IconPadding"))));
            this.comCLSIDLabel.Name = "comCLSIDLabel";
            this.toolTip.SetToolTip(this.comCLSIDLabel, resources.GetString("comCLSIDLabel.ToolTip"));
            // 
            // comIntroLabel
            // 
            resources.ApplyResources(this.comIntroLabel, "comIntroLabel");
            this.errorProvider.SetError(this.comIntroLabel, resources.GetString("comIntroLabel.Error"));
            this.errorProvider.SetIconAlignment(this.comIntroLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comIntroLabel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.comIntroLabel, ((int)(resources.GetObject("comIntroLabel.IconPadding"))));
            this.comIntroLabel.Name = "comIntroLabel";
            this.toolTip.SetToolTip(this.comIntroLabel, resources.GetString("comIntroLabel.ToolTip"));
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // ComHandlerActionUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comDataText);
            this.Controls.Add(this.getCLSIDButton);
            this.Controls.Add(this.comDataLabel);
            this.Controls.Add(this.comIntroLabel);
            this.Controls.Add(this.comCLSIDLabel);
            this.Controls.Add(this.comCLSIDText);
            this.errorProvider.SetError(this, resources.GetString("$this.Error"));
            this.errorProvider.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment"))));
            this.errorProvider.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding"))));
            this.Name = "ComHandlerActionUI";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.clsidMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button getCLSIDButton;
		private System.Windows.Forms.TextBox comDataText;
		private System.Windows.Forms.Label comDataLabel;
		private System.Windows.Forms.TextBox comCLSIDText;
		private System.Windows.Forms.Label comCLSIDLabel;
		private System.Windows.Forms.Label comIntroLabel;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ContextMenuStrip clsidMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem lookupCLSIDToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manuallyEnterCLSIDToolStripMenuItem;
		private System.Windows.Forms.ErrorProvider errorProvider;
	}
}
