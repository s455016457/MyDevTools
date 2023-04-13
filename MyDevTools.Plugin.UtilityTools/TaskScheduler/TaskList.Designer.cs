namespace MyDevTools.Plugin.UtilityTools.TaskScheduler
{
    partial class TaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripEditButton = new System.Windows.Forms.ToolStripButton();
            this.triggerControl1 = new MyDevTools.Plugin.UtilityTools.TaskScheduler.TriggerControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripEditButton});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripEditButton
            // 
            resources.ApplyResources(this.toolStripEditButton, "toolStripEditButton");
            this.toolStripEditButton.Name = "toolStripEditButton";
            this.toolStripEditButton.Click += new System.EventHandler(this.toolStripEditButton_Click);
            // 
            // triggerControl1
            // 
            resources.ApplyResources(this.triggerControl1, "triggerControl1");
            this.triggerControl1.Name = "triggerControl1";
            // 
            // TaskList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.triggerControl1);
            this.Name = "TaskList";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TriggerControl triggerControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripEditButton;
    }
}