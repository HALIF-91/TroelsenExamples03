using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomAppDomains
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вывести все сборки, загруженные в стандартный домен приложения
            AppDomain defaultAD = AppDomain.CurrentDomain;

            // это сботые сработает, при выгрузке из процесса стандартного домена приложения
            // что очевидно влечет за собой завершение самого процесса
            defaultAD.ProcessExit += (o, s) =>
            {
                Console.WriteLine("Default AD unloaded!");
            };

            ListAllAssembliesInAppDomain(defaultAD);

            // Создать новый домен приложения в текущем процессе
            // и вывести список загруженных сборок
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");

            // Это событие сработает, если при выгрузке дополнительно созданного домена
            newAD.DomainUnload += (o, s) =>
            {
                Console.WriteLine("Created domain is unloaded");
            };
            LoadDllInNewAppDomain(newAD);
            Console.ReadLine();
        }
        static void LoadDllInNewAppDomain(AppDomain newAD)
        {
            try
            {
                // Загрузить CarLibrary.dll в этот новый домен
                newAD.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Вывести список всех сборок
            ListAllAssembliesInAppDomain(newAD);
            // Уничтожить этот домен приложения
            AppDomain.Unload(newAD);

        }
        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            // Получить все сборки, загруженные в стандартный домен приложения
            var loadedAssemblies = from a in ad.GetAssemblies()
                                   orderby a.GetName().Name
                                   select a;

            Console.WriteLine("***** Here are the assemblies loaded in {0} ******\n", ad.FriendlyName);

            foreach (var a in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", a.GetName().Name);
                Console.WriteLine("-> Version: {0}\n", a.GetName().Version);
            }
        }
    }
}
