using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Dispose() / Destructor Combo Platter *****");

            // вызвать метод Dispose() вручную. Это не приведет к вызову финализатора
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();
            
            // не вызывать метод Dispose(). Это приведет к вызову финализатора
            // и выдаче звукового сигнала
            MyResourceWrapper rw2 = new MyResourceWrapper();
            Console.ReadLine();
        }
    }
}
