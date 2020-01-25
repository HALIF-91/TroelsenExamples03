using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VehicleDescriptionAttributeReaderLateBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Value of VehicleDescriptionAttribute *******\n");
            ReflectAttributesUsingLateBinding();
            Console.ReadLine();
        }
        static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                // Загрузить локальную копию AttributedCarLibrary
                Assembly asm = Assembly.Load("AttributedCarLibrary");

                // Получить информацию о типе для VehicleDescriptionAttribute
                Type vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");

                // Получить информацию о типе для свойства Description
                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");

                // Получить все типы в сборке
                Type[] types = asm.GetTypes();

                // Пройти по всем типам и получить любые VehicleDescriptionAttribute
                foreach (Type t in types)
                {
                    object[] objs = t.GetCustomAttributes(vehicleDesc, false);

                    // Пройти по каждому VehicleDescriptionAttribute и вывести
                    // описание с использованием позднего связывания
                    foreach (object o in objs)
                    {
                        Console.WriteLine("-> {0}: {1}\n", t.Name, propDesc.GetValue(o, null));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
