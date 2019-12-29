using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductInfo[] itemsInStock = new ProductInfo[]
            {
                new ProductInfo { Name = "Mac's Coffee",
                                  Description = "Coffee with TEETH",
                                  NumberInStock = 24 },
                new ProductInfo { Name = "Milk Maid Milk",
                                  Description = "Milk cow's love",
                                  NumberInStock = 100 },
                new ProductInfo { Name = "Pure Silk Tofu",
                                  Description = "Bland is Possible",
                                  NumberInStock = 120 },
                new ProductInfo { Name = "Cruchy Pops",
                                  Description = "Cheezy, peppery goodness",
                                  NumberInStock = 2 },
                new ProductInfo { Name = "RipOfWater",
                                  Description = "From the tap to your wallet",
                                  NumberInStock = 100 },
                new ProductInfo { Name = "Classic Valpo Pizza",
                                  Description = "Everyone loves pizza",
                                  NumberInStock = 73 }
            };

            SelectEverything(itemsInStock);
            ListProductNames(itemsInStock);
            GetOverStock(itemsInStock);
            GetNamesAndDescriptions(itemsInStock);

            Array objs = GetProjectedSubset(itemsInStock);
            foreach (object o in objs)
            {
                Console.WriteLine(o);
            }

            AlphabetizeProductNames(itemsInStock);
            DisplayDiff();
            DisplayIntersection();
            DisplayUnion();
            DisplayConcat();
            DisplayConcatNoDups();
            AggregateOps();

            Console.ReadLine();
        }
        static void SelectEverything(ProductInfo[] products)
        {
            // Получить все!
            var allProducts = from p in products select p;
            foreach (var p in allProducts)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }
        static void ListProductNames(ProductInfo[] products)
        {
            // Теперь получить только наименование товаров
            var names = from product in products select product.Name;
            foreach (var p in names)
            {
                Console.WriteLine("Name: {0}", p);
            }
            Console.WriteLine();
        }
        static void GetOverStock(ProductInfo[] products)
        {
            // Получить только те товары, которых на складе более 25
            var overstock = from p in products where p.NumberInStock > 25 select p;

            foreach (ProductInfo p in overstock)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }
        static void GetNamesAndDescriptions(ProductInfo[] products)
        {
            // получаем результирующий набор, содержащий только имя и описание
            // оператор select динамически выдаст новый анонимный тип
            var nameDesc = from p in products select new { p.Name, p.Description };
            foreach (var item in nameDesc)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        static Array GetProjectedSubset(ProductInfo[] products)
        {
            var nameDesc = from p in products select new { p.Name, p.Description };
            // отобразить набор анонимных объектов как объект Array
            return nameDesc.ToArray();
        }
        static void AlphabetizeProductNames(ProductInfo[] products)
        {
            var subset = from p in products orderby p.Name select p;

            // порядок по возрастанию принят по умолчанию, но можно прояснить намерения
            var subset2 = from p in products orderby p.Name ascending select p;
            // получение элементов в порядке убывания служит операция descending
            var subset3 = from p in products orderby p.Name descending select p;

            Console.WriteLine("\nOrdered by Name:");
            foreach (var p in subset)
            {
                Console.WriteLine(p);
            }
        }
        static void DisplayDiff()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carDiff = (from c in myCars select c)
                .Except(from c2 in yourCars select c2);

            Console.WriteLine("\nHere is what you don't have, but I do:");
            foreach (string s in carDiff)
            {
                Console.WriteLine(s); // выводит Yugo
            }
        }
        static void DisplayIntersection()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            // Получить общие члены
            var carIntersect = (from c in myCars select c)
                .Intersect(from c2 in yourCars select c2);

            Console.WriteLine("\nHere is what we have in common:");
            foreach (string s in carIntersect)
            {
                Console.WriteLine(s); // выводит Aztec и BMW
            }
        }
        static void DisplayUnion()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            // Получить объединение двух контейнеров
            var carUnion = (from c in myCars select c)
                .Union(from c2 in yourCars select c2);

            Console.WriteLine("\nHere is everything without duplicate:");
            foreach (string s in carUnion)
            {
                // выводит все, повторящиеся члены в нем встречаются только однажды
                Console.WriteLine(s);
            }
        }
        static void DisplayConcat()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

            var carConcat = (from c in myCars select c)
                .Concat(from c2 in yourCars select c2);

            Console.WriteLine("\nHere is everything:");
            foreach (string s in carConcat)
            {
                // прямая конкатенация, выводит все члены двух списков
                Console.WriteLine(s);
            }
        }
        static void DisplayConcatNoDups()
        {
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            
            var carConcat = (from c in myCars select c)
                .Concat(from c2 in yourCars select c2);
            
            Console.WriteLine("\nHere is everything without duplicate:");
            foreach (string s in carConcat.Distinct())
            {
                // выводит все, повторящиеся члены в нем встречаются только однажды
                Console.WriteLine(s);
            }
        }
        static void AggregateOps()
        {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };

            Console.WriteLine("\nAggregate operations of LINQ:");
            Console.WriteLine("Max temp: {0}",
                (from t in winterTemps select t).Max());

            Console.WriteLine("Min temp: {0}",
                (from t in winterTemps select t).Min());

            Console.WriteLine("Average temp: {0}",
                (from t in winterTemps select t).Average());

            Console.WriteLine("Sum of all temps: {0}",
                (from t in winterTemps select t).Sum());
        }
    }
}
