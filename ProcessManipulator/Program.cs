using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******** Fun with Processes **********");
            ListAllRunningProcesses();

            // Запросить у пользователя PID и вывести набор активных потоков
            Console.WriteLine("******* Enter PID of process to investigate *********");
            Console.Write("PID: ");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);
            GetSpecificProcess();
            EnumThreadForPid(theProcID);

            Console.WriteLine("******* Enter PID of process to investigate *********");
            Console.Write("PID: ");
            pID = Console.ReadLine();
            theProcID = int.Parse(pID);
            EnumModsForPid(theProcID);

            StartAndKillProcess();

            Console.ReadLine();
        }
        static void ListAllRunningProcesses()
        {
            // Получить все процессы на локальной машине, упорядоченные по PID
            // используемая здесь нотация в виде точки обозначает локальный компьютер
            var runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;

            // вывести для каждого процесса PID и имя
            foreach (var p in runningProcs)
            {
                string info = string.Format("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("***************************************\n");
        }
        // Если процесс с PID, равным 12388, не существует, сгенерируется исключение
        static void GetSpecificProcess()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(12388);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void EnumThreadForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            // Вывести статические данные по каждому потоку в указанном процессе
            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);
            ProcessThreadCollection theThreads = theProc.Threads;

            foreach (ProcessThread pt in theThreads)
            {
                string info = string.Format("-> Thread ID: {0}\tStart time: {1}\tPriority: {2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("******************************************\n");
        }

        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the loaded modules for: {0}", theProc.ProcessName);
            ProcessModuleCollection theMods = theProc.Modules;

            foreach (ProcessModule pm in theMods)
            {
                string info = string.Format("-> Mod Name: {0}", pm.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("***********************************\n");
        }

        static void StartAndKillProcess()
        {
            Process ieProc = null;

            // Запустить Internet Explorer и перейти на сайт facebook.com
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe", "www.facebook.com");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                ieProc = Process.Start(startInfo);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("-> Hit Enter to kill {0} ...", ieProc.ProcessName);
            Console.ReadLine();

            // Уничтожить процесс iexplore.exe
            try
            {
                ieProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
