using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttributedCarLibrary;

namespace VehicleDescriptionAttributeReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *******\n");
            ReflectOnAttributesUsingEarlyBinding();
            Console.ReadLine();
        }
        static void ReflectOnAttributesUsingEarlyBinding()
        {
            Type t = typeof(Winnebago);

            // Получить все атрибуты Winnebago
            // false - указывает, должен ли поиск продолжаться вверх по цепочке наследования
            object[] customAtts = t.GetCustomAttributes(false);

            // Вывести описание
            foreach (VehicleDescriptionAttribute v in customAtts)
            {
                Console.WriteLine("->{0}\n", v.Description);
            }
        }
    }
}
