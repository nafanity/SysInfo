using System;

namespace SysInfoReport
{
    class Program
    {
        static void Main(string[] args)
        {
            //get parametrs in string format
            String ProccessorName = SystemInformation.getCPUInfo();

            Console.WriteLine(ProccessorName);
            Console.ReadLine();
            

        }

    }
}
