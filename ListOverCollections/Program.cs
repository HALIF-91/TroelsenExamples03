using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOverCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> myCars = new List<Car>()
            {
                new Car { PetName = "Henry", Color = "Silver", Make = "BMW", Speed = 100 },
                new Car { PetName = "Daisy", Color = "Tan", Make = "BMW", Speed = 90 },
                new Car { PetName = "Mary", Color = "Black", Make = "VW", Speed = 55},
                new Car { PetName = "Clunker", Color = "Rust", Make = "Yugo", Speed = 5},
                new Car { PetName = "Melvin", Color = "White", Make = "Ford", Speed = 43}
            };
            
            GetFastCars(myCars);
            GetFastBMWs(myCars);
            LINQOverArrayList();
            OfTypeAsFilter();

            Console.ReadLine();
        }
        static void GetFastCars(List<Car> myCars)
        {
            var fastCars = from car in myCars where car.Speed > 55 select car;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
            Console.WriteLine();
        }
        static void GetFastBMWs(List<Car> myCars)
        {
            var fastCars = from car in myCars where car.Speed > 90 && car.Make == "BMW" select car;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
            Console.WriteLine();
        }
        static void LINQOverArrayList()
        {
            ArrayList cars = new ArrayList()
            {
                new Car { PetName = "Henry", Color = "Silver", Make = "BMW", Speed = 100 },
                new Car { PetName = "Daisy", Color = "Tan", Make = "BMW", Speed = 90 },
                new Car { PetName = "Mary", Color = "Black", Make = "VW", Speed = 55 },
                new Car { PetName = "Clunker", Color = "Rust", Make = "Yugo", Speed = 5 },
                new Car { PetName = "Melvin", Color = "White", Make = "Ford", Speed = 43 }
            };

            var myCars = cars.OfType<Car>();

            var fastCars = from car in myCars where car.Speed > 55 select car;

            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
            Console.WriteLine();
        }
        static void OfTypeAsFilter()
        {
            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
            var myInts = myStuff.OfType<int>();

            // выведет на консоль 10, 400, 8
            foreach (int i in myInts)
            {
                Console.WriteLine("Int value: {0}", i);
            }
        }
    }
}
