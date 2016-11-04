using System;

namespace SysInfoReport
{
    class Program
    {
        static void Main(string[] args)
        {
            //get parametrs in string format
            String ProccessorName = SystemInformation.getCPUInfo();
            String RAM = SystemInformation.getRAMInfo();
            String HDD = SystemInformation.getHDDInfo();
            String Motherboard = SystemInformation.getMotherBoardInfo();
            String VideoCard = SystemInformation.getVideoBoardInfo();
            String Monitor = SystemInformation.getMonitorInfo();

            Console.WriteLine(Monitor);
            Console.ReadLine();
            

        }

    }
}
