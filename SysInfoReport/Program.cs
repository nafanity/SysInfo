using System;
using System.Management;

namespace SysInfoReport
{
    class Program
    {
        static void Main(string[] args)
        {
            String ProccessorName = getStringParametrs(1, "Name");
            String RAM = (Convert.ToDouble(getStringParametrs(2, "Capacity")) / 1024 / 1024 ).ToString();
            String HD = getStringParametrs(3, "Capacity");
            String OS = getStringParametrs(4, "Name");
            
            Console.WriteLine(OS);
            Console.ReadLine();

        }

        static String getStringParametrs(int key,String ParamName)
        {
            int index = 0;
            String result = "";
            String path = "root\\CIMV2";
            String query = "";
            Double tmpResDouble = 0;
            String tmpResString = "";

            switch (key)
            {
                case 1: query = "SELECT * FROM Win32_Processor"; break; // ProccessorName
                case 2: query = "SELECT * FROM Win32_PhysicalMemory"; break; //RAM
                case 3: query = "SELECT * FROM Win32_Volume"; break; //HardDisks
                case 4: query = "SELECT * FROM Win32_OperatingSystem"; break; //OS
                default: break;
            }

           ManagementObjectSearcher searcher =
                new ManagementObjectSearcher(path, query);

            foreach (var queryObj in searcher.Get())
            {
                if (queryObj[ParamName] == null) break;
                result = queryObj[ParamName].ToString();
                if (key == 2)
                    tmpResDouble += Convert.ToDouble(result);
                if (key == 3)
                {
                    tmpResDouble += Math.Round(Convert.ToDouble(result) / 1024 / 1024 / 1024,2);
                    tmpResString += "\"" + tmpResDouble + " GB \"  ";
                }
            }
             
            if (key == 2)
                result = tmpResDouble.ToString();
            if (key == 3)
                result = tmpResDouble.ToString() + "GB (" + tmpResString + ")";
            if (key == 4)
            {
                var tmp = result.Split('|');
                result = tmp[0];
            }

            return result;
        }
    }
}
