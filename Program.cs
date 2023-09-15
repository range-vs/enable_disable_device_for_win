using System;
using System.Management;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Arguments are missing!");
                return;
            }

            string deviceGuid = args[0];

            // Get the ManagementClass for working with WMI
            ManagementClass managementClass = new ManagementClass("Win32_PnPEntity");

            // Get the instances of the Win32_PnPEntity class
            ManagementObjectCollection managementObjects = managementClass.GetInstances();

            // Iterate over the objects to find the device with the specified GUID
            foreach (ManagementObject managementObject in managementObjects)
            {
                object classGuid = managementObject.GetPropertyValue("ClassGuid");
                if (classGuid != null)
                {
                    string deviceId = classGuid.ToString();

                    if (deviceId.Contains(deviceGuid))
                    {
                        string status = args[1];

                        if (status == "1")
                        {
                            // Enable the device
                            managementObject.InvokeMethod("Enable", null);
                            Console.WriteLine("Device enabled");
                        }
                        else if (status == "0")
                        {
                            // Disable the device
                            managementObject.InvokeMethod("Disable", null);
                            Console.WriteLine("Device disabled");
                        }
                        break;
                    }
                }
            }
        }
        catch 
        {
               
        }
    }

}