using System;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServerInfo
{
    public class Globalfunc
    {
        public static string ipaddresses;
        public static string subnets;
        public static string gateways;
        public static string mac;
        public static string cpuInfo;
        public static string cpuName;

        private string displayDesc;
        private string displayID;
        private string displayName;
        private UInt32 displayHeight;
        private UInt32 displayWidth;

        PerformanceCounter myCounter;

        public void StartApp(string path)
        {
            Process.Start(path);
        }

        public string ConvertArrayToString(string[] input)
        {
            StringBuilder bdr = new StringBuilder();
            foreach (string value in input)
            {
                bdr.Append(value);
                bdr.Append('.');
            }
            return bdr.ToString();
        }

        public void GetCpuInfo()
        {

            try
            {
                //CPU
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    cpuName = mo["Name"].ToString();
                }
                moc = null;
                mc = null;
                Console.WriteLine("CPU Info:");
                Console.WriteLine(cpuInfo);
                Console.WriteLine("CPU Name:");
                Console.WriteLine(cpuName);

                if (!PerformanceCounterCategory.Exists("Processor"))
                {
                    Console.WriteLine("Object Processor does not exist!");
                    return;
                }

                if (!PerformanceCounterCategory.CounterExists(@"% Processor Time", "Processor"))
                {
                    Console.WriteLine(@"Counter % Processor Time does not exist!");
                    return;
                }

                myCounter = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");

                int i = 0;
                while (i < 10)
                {
                    Console.WriteLine("@");

                    try
                    {
                        Console.WriteLine(@"Current value of Processor, %Processor Time, _Total= " + myCounter.NextValue().ToString());
                    }

                    catch
                    {
                        Console.WriteLine(@"_Total instance does not exist!");
                        return;
                    }

                    Thread.Sleep(100);
                    i++;
                }

            }
            catch
            {
                cpuInfo = "unknow";
                cpuName = "unknow";
            }
            finally
            {
            }

        }

        public void GetDisplayInfo()
        {
            try
            {
                //Display
                ManagementClass dm = new ManagementClass("Win32_DesktopMonitor");
                ManagementClass vc = new ManagementClass("Win32_VideoController");

                ManagementObjectCollection moc = dm.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    displayDesc = mo.Properties["Description"].Value.ToString();
                    displayID = mo.Properties["DeviceID"].Value.ToString();
                    displayName = mo.Properties["Name"].Value.ToString();
                    displayHeight = Convert.ToUInt32(mo.Properties["ScreenHeight"].Value);
                    displayWidth = Convert.ToUInt32(mo.Properties["ScreenWidth"].Value);

                    Console.WriteLine("Display Description: " + displayDesc);
                    Console.WriteLine("Display ID: " + displayID);
                    Console.WriteLine("Display Name: " + displayName);
                    Console.WriteLine("Display Höhe: " + displayHeight);
                    Console.WriteLine("Display Breite: " + displayWidth);
                }
                moc = null;
                dm = null;
                moc = vc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    var videoControllerName = mo.Properties["Name"].Value.ToString();
                    var videoControllerDesc = mo.Properties["Description"].Value.ToString();
                    var videoControllerID = mo.Properties["DeviceID"].Value.ToString();
                    var videoControllerRefresh = Convert.ToUInt32(mo.Properties["CurrentRefreshRate"].Value);
                    var videoControllerWidth = Convert.ToUInt32(mo.Properties["CurrentHorizontalResolution"].Value);
                    var videoControllerHeight = Convert.ToUInt32(mo.Properties["CurrentVerticalResolution"].Value);

                    Console.WriteLine("VideoController Name: " + videoControllerName);
                    Console.WriteLine("VideoController Description: " + videoControllerDesc);
                    Console.WriteLine("VideoController ID: " + videoControllerID);
                    Console.WriteLine("VideoController RefreshRate: " + videoControllerRefresh);
                    Console.WriteLine("VideoController Breite: " + videoControllerWidth);
                    Console.WriteLine("VideoController Höhe: " + videoControllerHeight);
                }
                moc = null;
                dm = null;

            }
            catch
            {
            }
            finally
            {
            }

        }

        public void GetDiskInfo()
        {
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            var freespace = Convert.ToUInt64(disk["FreeSpace"]);
            var size = Convert.ToUInt64(disk["Size"]);
            Console.WriteLine("C: Freespace " + freespace / 1073741824 + " GB");
            Console.WriteLine("C: Size " + size / 1073741824 + " GB");

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

                ipaddresses = ConvertArrayToString((string[])objMO["IPAddress"]);
                subnets = ConvertArrayToString((string[])objMO["IPSubnet"]);
                gateways = ConvertArrayToString((string[])objMO["DefaultIPGateway"]);
                mac = objMO["MacAddress"].ToString();


                Console.WriteLine("SettingID:");
                Console.WriteLine(objMO["SettingID"].ToString());

                Console.WriteLine("Printing IPGateway Info:");
                Console.WriteLine(gateways);

                Console.WriteLine("Printing Ipaddress Info:");

                Console.WriteLine(ipaddresses);

                Console.WriteLine("Printing SubNet Info:");

                Console.WriteLine(subnets);

                Console.WriteLine("Printing Mac Info:");

                Console.WriteLine(mac);
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
        private static IPAddress ConvertStringIP(string ipAddress)
        {
            try
            {
                // Create an instance of IPAddress for the specified address string (in
                // dotted-quad, or colon-hexadecimal notation).
                IPAddress address = IPAddress.Parse(ipAddress);

                // Display the address in standard notation.
                Console.WriteLine("Parsing your input string: " + "\"" + ipAddress + "\"" + " produces this address (shown in its standard notation): " + address.ToString());
                return address;
            }

            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
                return null;
            }

            catch (FormatException e)
            {
                Console.WriteLine("FormatException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
                return null;
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
                return null;
            }
        }

        public void Shutdown(string flag = "shutdownNow", string mode = "WMI")
        {
            switch (flag)
            {
                case "rebootNow":
                    flag = "6";
                    break;
                case "reboot":
                    flag = "2";
                    break;
                case "shutdownNow":
                    flag = "12";
                    break;
                case "shutdown":
                    flag = "8";
                    break;
                default:
                    flag = "12";
                    break;

            }
            if (mode == "WMI")
            {
                ManagementBaseObject mboShutdown = null;
                ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
                mcWin32.Get();

                // Get Security Privilages
                mcWin32.Scope.Options.EnablePrivileges = true;
                ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");

                //Option Flags
                mboShutdownParams["Flags"] = flag;
                mboShutdownParams["Reserved"] = "0";
                foreach (ManagementObject manObj in mcWin32.GetInstances())
                {
                    mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
                }
            }
            else if (mode == "Core")
            {
                Process.Start("shutdown", "/s /t 0");
            }
        }
        public void Reboot()
        {
            Shutdown("WMI", "rebootNow");
        }
    }
}