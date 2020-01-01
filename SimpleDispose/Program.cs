using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Fun with Dispose *****\n");

            MyResourceWrapper rw = new MyResourceWrapper();
            if(rw is IDisposable)
                rw.Dispose();

            DisposeFileSystem();

            // метод Dispose() вызывается автоматически при выходе за пределы области действий
            // допускается объявлять несколько объектов одного и того же типа
            // при попытке применить using к объекту, не реализующему интерфейс IDisposable
            // возникнет ошибка на этапе компиляции
            using (MyResourceWrapper wrapper = new MyResourceWrapper(),
                                    wrapper2 = new MyResourceWrapper())
            {
                // использовать объект wrapper и wrapper2
            }

            Console.ReadLine();
        }
        static void DisposeFileSystem()
        {
            FileStream fs = new FileStream("file.txt", FileMode.OpenOrCreate);

            // вызовы этих методов делают одно и тоже
            fs.Close();
            fs.Dispose();
        }
    }
}
