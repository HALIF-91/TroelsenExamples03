using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n********** Types in Assembly **********");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine("Type: {0}", t);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("****** External Assemble Viewer *******");
            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                Console.Write("or enter Q to quit: ");
                // Необходимо скопировать двоичный файл .dll
                // передается дружественное имя сборки, например CarLibrary
                asmName = Console.ReadLine();

                // Если пользователь желает завершить программу?
                if (asmName.ToUpper() == "Q")
                {
                    break;
                }
                // Попробовать загрузить сборку
                try
                {
                    // Можно вводить абсолютный путь к интересующей сборке
                    // asm = Assembly.LoadFrom(asmName);
                    asm = Assembly.Load(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch
                {
                    Console.WriteLine("Sorry, can't find assembly.");
                }
            } while (true);
        }
    }
}
