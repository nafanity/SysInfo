using System;
using System.IO;
using System.Collections.Generic;

namespace SysInfoReport
{
    class Program
    {
        static void Main(string[] args)
        {
            //get parametrs in string format
            List<String> record = new List<string>();
            List<String> head = new List<string>();

            head.Add("Процессор");  record.Add(SystemInformation.getCPUInfo());
            head.Add("ОЗУ"); record.Add(SystemInformation.getRAMInfo());
            head.Add("Жесткий диск"); record.Add(SystemInformation.getHDDInfo());
            head.Add("Материнская плата"); record.Add(SystemInformation.getMotherBoardInfo());
            head.Add("Видеоадаптер"); record.Add(SystemInformation.getVideoBoardInfo());
            head.Add("Монитор"); record.Add(SystemInformation.getMonitorInfo());
            head.Add("Привод"); record.Add(SystemInformation.getDiskInfo());
            head.Add("Сетевая карта"); record.Add(SystemInformation.getNetworkAdapterInfo());
            head.Add("ОС"); record.Add(SystemInformation.getOSInfo());
            head.Add("Сетевое имя"); record.Add(SystemInformation.getNetworkName());
            head.Add("Имя пользователя"); record.Add(SystemInformation.getUserName());
            head.Add("IP"); record.Add(SystemInformation.getIPs());


            var sw = new StreamWriter(Directory.GetCurrentDirectory() + "/report.txt");
                for(int i = 0; i < head.Count - 1; i++)
                    sw.WriteLine(head[i] + ":  " + record[i]);

            sw.Close();
            Console.ReadLine();
            

        }

    }
}
