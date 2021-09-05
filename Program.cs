using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace RydOp_Opgave
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BootDevice, UserOrgOS
            Console.WriteLine("---------------------------------------------------");
            MethodManager.GetBootDevice();
            Console.WriteLine("---------------------------------------------------");
            MethodManager.GetUserOrgOS();
            Console.WriteLine("---------------------------------------------------");
            #endregion

            #region Hard disk information
            Console.WriteLine("Press 'ENTER' for info on hard disks");
            Console.ReadKey();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Hard disk serial number:");
            MethodManager.GetHardDiskSerialNumber();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Hard disk meta data:");
            MethodManager.GetDiskMetaData();
            #endregion

            #region CPU information
            Console.WriteLine("Press 'ENTER' to list individual core usage");
            Console.ReadKey();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("CPU data:");
            MethodManager.GetProcessorData();
            #endregion

            #region Memory information
            Console.WriteLine("Press 'ENTER' to list memory data");
            Console.ReadKey();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Memory data:");
            MethodManager.GetMemoryData();
            Console.WriteLine("---------------------------------------------------");
            #endregion

            #region Windows services
            Console.WriteLine("Press 'ENTER' to list all Windows services");
            Console.ReadKey();
            Console.WriteLine("---------------------------------------------------");
            MethodManager.ListAllServices();
            Console.ReadKey();
            #endregion
        }
    }
}
