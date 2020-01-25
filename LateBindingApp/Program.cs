using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LateBindingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Fun with Late Binding *******");
            // Попробовать загрузить локальную копию CarLibrary
            Assembly a = null;
            try
            {
                // Перед запуском необходимо вручную скопировать CarLibrary.dll в bin\Debug
                // так как CLR среда будет зондировать только папку клиента
                a = Assembly.Load("CarLibrary");

                // для метода LoadFrom() нет необходимости копировать .dll
                //a = Assembly.LoadFrom("полный путь");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if (a != null)
            {
                CreateUsingLateBinding(a);
                InvokeMethodWithArgsUsingLateBinding(a);
            }

            Console.ReadLine();
        }
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа MiniVan
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                // Создать объект MiniVan на лету, явное приведение не допускается
                // Ошибка -> object obj = (MiniVan)Activator.CreateInstance(miniVan);
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Created a {0} using late binding!", obj);

                // Получить информацию для TurboBoost
                MethodInfo mi = miniVan.GetMethod("TurboBoost");

                // Вызвать метод для обьекта obj (null обозначает отсуствие параметров)
                mi.Invoke(obj, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа SportsCar
                Type sport = asm.GetType("CarLibrary.SportsCar");

                // Создать объект SportsCar на лету, явное приведение не допускается
                // Ошибка -> object obj = (SportsCar)Activator.CreateInstance(sport);
                object obj = Activator.CreateInstance(sport);
                Console.WriteLine("Created a {0} using late binding!", obj);

                // Получить информацию для TurboBoost
                MethodInfo mi = sport.GetMethod("TurnOnRadio");

                // Вызвать метод для обьекта obj (null обозначает отсуствие параметров)
                mi.Invoke(obj, new object[] { true, 2 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
