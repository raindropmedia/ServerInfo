using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;

namespace ServerInfo
{
    public class Globalfunc
    {
        public void StartApp(string path)
        {
            Process.Start(path);
        }

        public void ListIP()
        {
            ManagementClass objMC = new ManagementClass(
               "Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if (!(bool)objMO["ipEnabled"])
                    continue;



                Console.WriteLine(objMO["Caption"] + "," +
                  objMO["ServiceName"] + "," + objMO["MACAddress"]);
                string[] ipaddresses = (string[])objMO["IPAddress"];
                string[] subnets = (string[])objMO["IPSubnet"];
                string[] gateways = (string[])objMO["DefaultIPGateway"];


                Console.WriteLine("Printing Default Gateway Info:");
                Console.WriteLine(objMO["DefaultIPGateway"].ToString());

                Console.WriteLine("Printing IPGateway Info:");
                foreach (string sGate in gateways)
                    Console.WriteLine(sGate);


                Console.WriteLine("Printing Ipaddress Info:");

                foreach (string sIP in ipaddresses)
                    Console.WriteLine(sIP);

                Console.WriteLine("Printing SubNet Info:");

                foreach (string sNet in subnets)
                    Console.WriteLine(sNet);
            }
        }
        public void setIP(string IPAddress, string SubnetMask, string Gateway)
        {

            ManagementClass objMC = new ManagementClass(
                "Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();


            foreach (ManagementObject objMO in objMOC)
            {

                if (!(bool)objMO["IPEnabled"])
                    continue;



                try
                {
                    ManagementBaseObject objNewIP = null;
                    ManagementBaseObject objSetIP = null;
                    ManagementBaseObject objNewGate = null;


                    objNewIP = objMO.GetMethodParameters("EnableStatic");
                    objNewGate = objMO.GetMethodParameters("SetGateways");



                    //Set DefaultGateway
                    objNewGate["DefaultIPGateway"] = new string[] { Gateway };
                    objNewGate["GatewayCostMetric"] = new int[] { 1 };


                    //Set IPAddress and Subnet Mask
                    objNewIP["IPAddress"] = new string[] { IPAddress };
                    objNewIP["SubnetMask"] = new string[] { SubnetMask };

                    objSetIP = objMO.InvokeMethod("EnableStatic", objNewIP, null);
                    objSetIP = objMO.InvokeMethod("SetGateways", objNewGate, null);



                    Console.WriteLine(
                       "Updated IPAddress, SubnetMask and Default Gateway!");



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Set IP : " + ex.Message);
                }
            }
        }
    }
}