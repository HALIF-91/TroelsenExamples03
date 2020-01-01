using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemGC
{
    /*
     public enum GCCollectionMode
    {
        Default,    // является текущим стандартным значением
        Forced,     // указывает исполняющей среде начать сборку мусора немедленно
        Optimized,  // позволяет исполняющей среде выяснить, оптимален ли текущий момент для сборки
    }
         */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Fun with System.GC *******");
            // вывести приблизительное кол-во байтов в куче
            Console.WriteLine("Estimates bytes on heap: {0}", GC.GetTotalMemory(false));

            // MaxGeneration основано на 0, поэтому при выводе добавить 1
            Console.WriteLine("This OS has {0} object generations.\n", GC.MaxGeneration + 1);

            Car refToMyCar = new Car("Zippy", 100);
            Console.WriteLine(refToMyCar.ToString());

            // вывести поколение объекта refToMyCar
            Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));

            object[] tonsOFObjects = new object[50000];
            for (int i = 0; i < 50000; i++)
            {
                tonsOFObjects[i] = new object();
            }

            // если принудительный запуск сборщика мусора может оказаться полезным
            // можно инициировать процесс сборки мусора явно
            // GC.Collect();

            // необходимо исследовать только объекты поколения 0, немедленно
            GC.Collect(0, GCCollectionMode.Forced);
            // ожидаем финализации каждого из объектов
            GC.WaitForPendingFinalizers();

            // вывести поколение объекта refToMyCar
            Console.WriteLine("Generation of refToMyCar is: {0}", GC.GetGeneration(refToMyCar));

            // посмотреть, существует ли еще tonsOfObjects[9000]
            if (tonsOFObjects[9000] != null)
            {
                Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}\n",
                    GC.GetGeneration(tonsOFObjects[9000]));
            }
            else
                Console.WriteLine("tonsOfObjects[9000] is no longer alive.\n");

            // вывести кол-во проведеных сборок мусора для разных поколений
            Console.WriteLine("Gen 0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Gen 1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Gen 2 has been swept {0} times", GC.CollectionCount(2));

            Console.ReadLine();
        }
    }
}
