using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDevTools.Plugin.UtilityTools.TaskScheduler
{
    public partial class TriggerControl : UserControl
    {
        public TriggerControl()
        {
            InitializeComponent();
        }

        private void triggerTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != triggerTypeComboBox.SelectedIndex)
            {
                tabControl1.SelectedIndex = triggerTypeComboBox.SelectedIndex;
            }
        }
    }
}
