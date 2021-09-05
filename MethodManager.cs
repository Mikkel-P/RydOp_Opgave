using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace RydOp_Opgave
{
    static class MethodManager
    {
        #region Public methods
        /// <summary>
        /// Displays boot device
        /// </summary>
        public static void GetBootDevice()
        {
            ManagementScope scope = new ManagementScope(@"\\.\ROOT\cimv2");

            // Create object query
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            // Create object searcher
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            // Get a collection of WMI objects
            ManagementObjectCollection queryCollection = searcher.Get();

            // Enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // Access properties of the WMI object
                Console.WriteLine("BootDevice : {0}", m["BootDevice"]);
            }
        }
        /// <summary>
        /// Finds the name of the user, organisation and operating system
        /// </summary>
        public static void GetUserOrgOS()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                Console.WriteLine("User:\t{0}", result["RegisteredUser"]);
                Console.WriteLine("Org.:\t{0}", result["Organization"]);
                Console.WriteLine("O/S :\t{0}", result["Name"]);
            }
        }
        /// <summary>
        /// Displays disk name, size and free space
        /// </summary>
        public static void GetDiskMetaData()
        {
            ManagementScope managementScope = new ManagementScope();

            ObjectQuery objectQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);

            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            foreach (ManagementObject managementObject in managementObjectCollection)
            {
                Console.WriteLine("Disk Name : " + managementObject["Name"].ToString());
                Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"].ToString());
                Console.WriteLine("Disk Size: " + managementObject["Size"].ToString());
                Console.WriteLine("---------------------------------------------------");
            }
        }
        /// <summary>
        /// Finds and displays the hard disk serial number
        /// </summary>
        public static string GetHardDiskSerialNumber(string drive = "C")
        {
            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");

            managementObject.Get();
            Console.WriteLine(managementObject["VolumeSerialNumber"].ToString());

            return managementObject["VolumeSerialNumber"].ToString();
        }
        /// <summary>
        /// Shows total and free physical and virtual memory
        /// </summary>
        public static void GetMemoryData()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
            }
        }        
        /// <summary>
        /// Shows the current use of each core in %
        /// </summary>
        public static void GetProcessorData()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                Console.WriteLine("Core : Usage");
                Console.WriteLine(name + "    :     " + usage);
            }
        }
        /// <summary>
        /// Writes all of windows services to the console
        /// </summary>
        public static void ListAllServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            Console.WriteLine("There are {0} Windows services: ", objectCollection.Count);

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------------------");
            }
        }
        #endregion
    }
}
