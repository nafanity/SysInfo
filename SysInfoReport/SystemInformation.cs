using System;
using System.Management;

namespace SysInfoReport
{
    class SystemInformation
    {
        static private String path = "root\\CIMV2";

        static private String separator = "; ";


        static public String getCPUInfo()
        {
            var query = "SELECT * FROM Win32_Processor";
            String result = "";

            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(path, query);

            foreach (var queryObj in searcher.Get())
            {
                result += queryObj["Name"].ToString().Trim();
                result += separator;
                result += queryObj["MaxClockSpeed"].ToString();
                result += " MHz";
            }

            return result;
        }

        static public String getRAMInfo()
        {
            var query = "SELECT * FROM Win32_PhysicalMemory";
            String result = "";
            String separator = "; ";

            int Count = 0; //Количество планок
            long TotalMemory = 0;
            String frequency = "";

            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(path, query);

            foreach (var queryObj in searcher.Get())
            {
                Count++;
                TotalMemory += Convert.ToInt64(queryObj["Capacity"]) / 1024 / 1024;
                frequency = queryObj["Speed"].ToString();

            }

            result = TotalMemory.ToString() + " Mb" +
                    separator +
                    frequency + " Mhz" +
                    separator + Count.ToString();

            return result;
        }

        static public String getHDDInfo()
        {
            var query = "SELECT * FROM Win32_DiskPartition  ";
            String result = "Total size: ";
            String partOfDisk = "(";
            double totalSpace = 0;
            

            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(path, query);

            foreach (var queryObj in searcher.Get())
            {
                double sizePartOfDisk = Math.Round(Convert.ToDouble(queryObj["Size"]) / 1024 / 1024 / 1024, 2);
                totalSpace += sizePartOfDisk;
                partOfDisk += sizePartOfDisk.ToString();
                partOfDisk += " GB ";
            }

            partOfDisk += ")";

            result += totalSpace.ToString() + " GB:" + partOfDisk;

            return result;   
        }

        static public String getMotherBoardInfo()
        {
            var query = "SELECT * FROM Win32_BaseBoard ";
            String result = "";


            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(path, query);

            foreach (var queryObj in searcher.Get())
            {
                result += queryObj["Manufacturer"];
                result += queryObj["Product"];
            }


            return result;
        }

        static public String getVideoBoardInfo()
        {
            var query = "SELECT * FROM Win32_VideoController  ";
            String result = "";
            bool flagNewString = false;


            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(path, query);

            foreach (var queryObj in searcher.Get())
            {
                if (flagNewString)
                    result += "\n";
                result += queryObj["Name"];
                result += " ";
                result += Math.Round(Convert.ToDouble(queryObj["AdapterRAM"]) / 1024 / 1024, 2);
                result += " MB ";
                flagNewString = true;
            }

            return result;
        }

        static public String getMonitorInfo()
        {
            var query = "SELECT * FROM Win32_DesktopMonitor   ";
            String result = "";
            bool flagNewString = false;


            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(path, query);

            foreach (var queryObj in searcher.Get())
            {
                if (queryObj["Name"].ToString() == "Универсальный монитор PnP")
                    continue;
                if (flagNewString)
                    result += "\n";
                result += queryObj["Name"];
                result += " ";
                result += Convert.ToInt32(queryObj["ScreenWidth"]).ToString();
                result += "x";
                result += Convert.ToInt32(queryObj["ScreenHeight"]).ToString();
                flagNewString = true;
            }

            return result;
        }
    }
}
