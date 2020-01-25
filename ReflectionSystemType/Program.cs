using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSystemType
{
    class Program
    {
        static void Main(string[] args)
        {
            // При получении информации о типе с помощью System.Object.GetType()
            // требуется создания экземпляра объекта
            SportsCar sc = new SportsCar();
            Type t = sc.GetType();

            // При получении информации о типе с помощью typeof()
            // не требуется
            Type t2 = typeof(SportsCar);

            // Получить информацию о типе с помощью статисческого метода Type.GetType()
            // true - генерировать исключение, если SportsCar не может быть найден
            // true - игнорировать регистр
            // "CarLibrary.Sportscar" - если тип оперделен внутри сборки
            // "CarLibrary.Sportscar, CarLibrary" - если тип оперделен во внешней сборке
            Type t3 = Type.GetType("CarLibrary.SportsCar, CarLibrary", true, true);

            // Поучить информацию о типе перчисления, вложенного в текущую сборку
            // знак плюс для обозначения вложенного типа
            Type t4 = Type.GetType("CarLibrary.JamesBondCar+SpyOptions", false, true);

            Console.ReadLine();
        }
    }
}
