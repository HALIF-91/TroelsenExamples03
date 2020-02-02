using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDAD();
            Console.WriteLine("********** Fun with the default AppDomain *********\n");
            DisplayDADStats();
            ListAllAssembliesInAppDomain();

            Console.ReadLine();
        }
        static void DisplayDADStats()
        {
            // Получить доступ к домену приложения для текущего потока
            AppDomain defaultAD = AppDomain.CurrentDomain;
            // Вывести различные статистические данные об этом домене
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default doamin?: {0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
        }
        static void ListAllAssembliesInAppDomain()
        {
            // Получить доступ к домену приложения для текущего потока
            AppDomain defaultAD = AppDomain.CurrentDomain;
            // Извлечь все сборки, загруженные в стандартный домен приложения
            // Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            var loadedAssemblies = from a in defaultAD.GetAssemblies() 
                                   orderby a.GetName().Name select a;
            Console.WriteLine("****** Here are the assemblies loaded in {0} *******\n", defaultAD.FriendlyName);

            foreach (Assembly a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }
        static void InitDAD()
        {
            // Эта логика будет выводить имя любой сбоки,
            // загруженной в домен приложения посел его создания
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }
    }
}
