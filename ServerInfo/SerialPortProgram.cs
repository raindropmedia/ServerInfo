using ServerInfo.Properties;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace ServerInfo
{
    class SerialPortProgram
    {

        // Create the serial port with basic settings
        public SerialPort ComPort = new SerialPort();
        //private SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        public List<string> portList = new List<string>();
        public List<string> portnames = new List<string>();

        delegate void SetTextCallback(string text);
        private Queue<byte> recievedData = new Queue<byte>();
        Boolean packetComplete = false;


        public void GetListComPorts()
        {
            portList.Clear();
            portnames.Clear();
            byte i = 0;
            try
            {

                ManagementClass mc = new ManagementClass("Win32_SerialPort");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    var comDeviceID = mo["DeviceID"].ToString();
                    var comName = mo["Name"].ToString();
                    var comDescription = mo["Description"].ToString();
                    var comStatus = mo["Status"].ToString();

                    if (comName.ToString().Contains("USB"))
                    {
                        Console.WriteLine(comName + " is a USB to SERIAL adapter / converter");
                        portList.Add(comName);
                        portnames.Add(comDeviceID);
                        i++;
                    }
                    Console.WriteLine("DeviceID: {0}", comDeviceID);
                    Console.WriteLine("PortName: {0}", comName);
                    Console.WriteLine("Description: {0}", comDescription);
                    Console.WriteLine("Status: {0}", comStatus);

                }
                moc = null;
                mc = null;

            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
        }

        public void StartComPort()
        {
            if (Settings.Default.comPortOpen == false)
            {
                try
                {
                    Settings.Default.comPortOpen = true;
                    ComPort.RtsEnable = false;
                    ComPort.DtrEnable = false;
                    ComPort.PortName = Settings.Default.comPort;
                    ComPort.BaudRate = 9600;
                    ComPort.DataBits = 8;
                    ComPort.StopBits = StopBits.One;
                    ComPort.Handshake = Handshake.None;
                    ComPort.Parity = Parity.None;
                    ComPort.Open();
                    ComPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Port_DataReceived);
                    Console.WriteLine("ComPort open");
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //port.PortName(Settings.Default.comPort)
        }

        public void StopComPort()
        {
            if (Settings.Default.comPortOpen == true)
            {

                Settings.Default.comPortOpen = false;
                ComPort.Close();
            }
        }

        private void SetText(string text)
        {
            //this.rtbIncoming.Text += text;
            Console.WriteLine(text);
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[ComPort.BytesToRead];
            ComPort.Read(data, 0, data.Length);
            data.ToList().ForEach(b => recievedData.Enqueue(b));
            processData();

            /*InputData = ComPort.ReadExisting();
            if (InputData != String.Empty)
            {
                //Console.WriteLine(InputData);
                MessageBox.Show(InputData);
            }  */
        }
        void processData()
        {
            Console.WriteLine("processData");
            byte i = 0;
            byte lastf = 0;
            byte end = 0;
            byte[] dataPacket = { };
            foreach (byte data in recievedData)
            {
                if (data == 255)
                {
                        end++;
                        if (end >= 3)
                        {
                            Console.WriteLine("Packet End");
                            packetComplete = true;
                            //dataPacket = recievedData.ToArray();
                            break;
                        }
                }
                else
                {
                    end = 0;
                }
                i++;
            }
            if (packetComplete)
            {
                if (recievedData.Count > i)
                {
                    Console.WriteLine("Buffer to long!");
                }
                if (recievedData.Peek() == 112)
                {
                    //Text
                    Console.WriteLine("String");
                }
                else if (recievedData.Peek() == 113)
                {
                    //Number
                    Console.WriteLine("Number");
                }
                var packet = Enumerable.Range(1, i - 3).Select(x => recievedData.Dequeue());
                recievedData.Clear();
                packetComplete = false;
            }
        }

    }
}
