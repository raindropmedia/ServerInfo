using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerInfo
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        private void LoadSettings(object sender, EventArgs e)
        {
            showMessageCheckBox.Checked = ServerInfo.Properties.Settings.Default.ShowMessage;
        }

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            // If the user clicked "Save"
            if (this.DialogResult == DialogResult.OK)
            {
                ServerInfo.Properties.Settings.Default.ShowMessage = showMessageCheckBox.Checked;
                ServerInfo.Properties.Settings.Default.Save();
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
