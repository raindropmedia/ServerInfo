using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace ServerInfo
{
    public partial class Configuration : Form
    {

        Globalfunc globalfunc = new Globalfunc();

        public Configuration()
        {
            InitializeComponent();
        }

        private void LoadSettings(object sender, EventArgs e)
        {
            showMessageCheckBox.Checked = ServerInfo.Properties.Settings.Default.ShowMessage;
            lblHelloWorld.Text = ServerInfo.Properties.Settings.Default.Application;
        }

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            // If the user clicked "Save"
            //if (this.DialogResult == DialogResult.OK)
            //{
            ServerInfo.Properties.Settings.Default.ShowMessage = showMessageCheckBox.Checked;
            ServerInfo.Properties.Settings.Default.Save();
            //}
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void selectapplicationButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // path in the Variable "Application".
            if (selectApplication.ShowDialog() == DialogResult.OK)
            {
                ServerInfo.Properties.Settings.Default.Application = selectApplication.FileName;
                lblHelloWorld.Text = ServerInfo.Properties.Settings.Default.Application;
            }
        }
        private void listipButton_Click(object sender, EventArgs e)
        {
            globalfunc.ListIP();
            
        }



    }
}
