using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace ServerInfo
{
    class SerialPortProgram
    {
        // Create the serial port with basic settings
        private SerialPort port = new SerialPort("COM1",9600, Parity.None, 8, StopBits.One);

        [STAThread]
        static void Main(string[] args)
        {
            // Instatiate this class
            new SerialPortProgram();
        }

        private SerialPortProgram()
        {
            Console.WriteLine("Incoming Data:");

            // Attach a method to be called when there
            // is data waiting in the port's buffer
            port.DataReceived += new
              SerialDataReceivedEventHandler(port_DataReceived);

            // Begin communications
            port.Open();

            // Enter an application loop to keep this thread alive
            Application.Run();
        }

        private void port_DataReceived(object sender,
          SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's buffer
            Console.WriteLine(port.ReadExisting());
        }

        // Display Port values and prompt user to enter a port.
        public static string SetPortName(string defaultPortName)
        {
            string portName;

            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter COM port value (Default: {0}): ", defaultPortName);
            portName = Console.ReadLine();

            if (portName == "" || !(portName.ToLower()).StartsWith("com"))
            {
                portName = defaultPortName;
            }
            return portName;
        }
    }
}
