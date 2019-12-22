using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryOverStrings();
            QueryOverStringsLongHand();
            QueryOverInts();

            Console.ReadLine();
        }
        static void QueryOverStrings()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Выражение запроса для нахождения элементов массива, включающих пробелы
            IEnumerable<string> subset = from game in currentVideoGames
                                         where game.Contains(" ")
                                         orderby game
                                         select game;

            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
            ReflectOverQueryResults(subset);
        }
        static void QueryOverStringsLongHand()
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            List<string> gameWithSpaces = new List<string>();
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gameWithSpaces.Add(currentVideoGames[i]);
            }

            gameWithSpaces.Sort();

            foreach (string s in gameWithSpaces)
            {
                Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
        }
        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            
            // рекомендуется использовать неявную типизацию
            var subset = from i in numbers where i < 10 select i;

            // запрос LINQ не выполняется до тех пор, пока не будет начата итерация
            // Оператор LINQ выполняется здесь
            foreach (var i in subset)
            {
                Console.WriteLine("Item: {0} < 10", i);
            }
            Console.WriteLine();

            numbers[0] = 4;

            // отложенное выполнение, нет необходимости заново делать запрос
            // Оператор LINQ снова выполняется
            foreach (var i in subset)
            {
                Console.WriteLine("Item: {0} < 10", i);
            }

            ReflectOverQueryResults(subset);
        }
        static void ReflectOverQueryResults(object resultSet)
        {
            Console.WriteLine("\n********* Info about your query ******");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}\n", 
                resultSet.GetType().Assembly.GetName().Name);
        }
        static void ImmediateExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // запрос LINQ выполняется незамедлительно, не ожидая итерации
            // получить данные НЕМЕДЛЕННО как int[]
            int[] subsetAsIntArray =
                (from i in numbers where i < 10 select i).ToArray<int>(); // == ToArray()

            // запрос LINQ выполняется незамедлительно, не ожидая итерации
            // получить данные НЕМЕДЛЕННО как List<int>
            List<int> subsetAsListOfInts =
                (from i in numbers where i < 10 select i).ToList<int>(); // == ToList()
        }
    }
}
