using ServerInfo.Properties;
using System;
using System.Windows.Forms;

namespace ServerInfo
{
    public partial class Configuration : Form
    {

        Globalfunc globalfunc = new Globalfunc();
        SerialPortProgram serialPortProgram = new SerialPortProgram();
        byte counter1 = 0;

        public Configuration()
        {
            InitializeComponent();
            comPortSelect.Items.Add(Settings.Default.comName);
            comPortSelect.SelectedIndex = 0;
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

        private void startAppButton_Click(object sender, EventArgs e)
        {
            globalfunc.StartApp(Settings.Default.Application);
        }

        private void getCpuInfoButton_Click(object sender, EventArgs e)
        {
            globalfunc.GetCpuInfo();
        }

        private void getDiskInfoButton_Click(object sender, EventArgs e)
        {
            globalfunc.GetDiskInfo();
        }

        private void getDisplayInfoButton_Click(object sender, EventArgs e)
        {
            globalfunc.GetDisplayInfo();
        }

        private void readComPortsButton_Click(object sender, EventArgs e)
        {
            serialPortProgram.GetListComPorts();
            //serialPortProgram.portList;
            String[] comPorts = serialPortProgram.portList.ToArray();
            comPortSelect.Items.Clear();
            comPortSelect.Items.AddRange(comPorts);
        }

        public void connectComButton_Click(object sender, EventArgs e)
        {
            //Settings.Default.comName = comPortSelect.SelectedItem.ToString();
            //Settings.Default.comPort = serialPortProgram.portnames[comPortSelect.SelectedIndex].ToString();
            connectCom();
            MessageBox.Show(Settings.Default.comName);
            //MessageBox.Show(serialPortProgram.portnames[comPortSelect.SelectedIndex]);
        }

        public void connectCom()
        {
            serialPortProgram.StartComPort();
            MessageBox.Show(Settings.Default.comName);
        }

        private void ChangedComIndex(object sender, EventArgs e)
        {
            if (comPortSelect.SelectedItem.ToString() != Settings.Default.comName)
            {
                Settings.Default.comName = comPortSelect.SelectedItem.ToString();
                Settings.Default.comPort = serialPortProgram.portnames[comPortSelect.SelectedIndex].ToString();
                MessageBox.Show(Settings.Default.comName + Settings.Default.comPort);
            }
        }
        public void sendHelloButton_Click(object sender, EventArgs e)
        {
            byte[] terminator = { 0xff, 0xff, 0xff };
            counter1++;
            string command = "t1.txt=" + '\u0022' + "Hello world " + counter1 + '\u0022';
            serialPortProgram.ComPort.Write(command);
            serialPortProgram.ComPort.Write(terminator, 0, terminator.Length);
            //Console.WriteLine(command + terminator);

            command = "n1.val=" + counter1;
            serialPortProgram.ComPort.Write(command);
            serialPortProgram.ComPort.Write(terminator, 0, terminator.Length);
            //Console.WriteLine(command + terminator);
        }
    }
}
