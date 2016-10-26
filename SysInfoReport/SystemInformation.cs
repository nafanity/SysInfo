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
    }
}
