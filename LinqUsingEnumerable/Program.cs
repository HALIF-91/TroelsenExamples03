using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStringWithOperators();
            QueryStringWithEnumerableAndLambdas();
            QueryStringWithEnumerableAndLambdas2();
            QueryStringsWithAnonymousMethods();

            Console.ReadLine();
        }

        #region Построение выражений запросов с использованием операций запросов
        static void QueryStringWithOperators()
        {
            Console.WriteLine("********* Using Query Operators *********");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            var subset = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game
                         select game;

            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
        }
        #endregion

        #region Построение выражений запросов с сипользованием типа Enumerable и лямбда-выражений
        static void QueryStringWithEnumerableAndLambdas()
        {
            Console.WriteLine("\n********* Using Enumerable / Lambda Expressions ***********");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // построить выражение запроса с использованием расширяющих методов
            var subset = currentVideoGames.Where(game => game.Contains(" "))
                .OrderBy(game => game).Select(game => game);

            foreach (string s in subset)
            {
                Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
        }
        
        static void QueryStringWithEnumerableAndLambdas2()
        {
            Console.WriteLine("********* Using Enumerable / Lambda Expressions ***********");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Разделить на фрагменты
            var gamesWithSpaces = currentVideoGames.Where(game => game.Contains(" "));
            var orderedGames = gamesWithSpaces.OrderBy(game => game);
            var subset = orderedGames.Select(game => game);

            foreach (var game in subset)
            {
                Console.WriteLine("Item: {0}", game);
            }
            Console.WriteLine();
        }
        #endregion

        #region Построение выражений запросов с использованием типа Enumerable и анонимных методов
        static void QueryStringsWithAnonymousMethods()
        {
            Console.WriteLine("******* Using Anonymous Methods ***********");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            // Построить необходимые делегаты Func<> с использованием анонимных методов
            Func<string, bool> searchFilter = 
                delegate (string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate (string s) { return s; };

            // Передать делегаты в методы Enumerable
            var subset = currentVideoGames.Where(searchFilter)
                .OrderBy(itemToProcess).Select(itemToProcess);

            foreach (var game in subset)
            {
                Console.WriteLine("Item: {0}", game);
            }
            Console.WriteLine();
        }
        #endregion

        #region Построение выражений запросов с использованием типа Enumerable и низкоуровневых делегатов
        static void QueryStringsWithRawDelegates()
        {
            Console.WriteLine("******* Using Raw delegates *********");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            Func<string, bool> searchFilter = new Func<string, bool>(Filter);
            Func<string, string> itemToProcess = new Func<string, string>(ProcessItem);

            // передать делегаты в методы Enumerable
            var subset = currentVideoGames.Where(searchFilter)
                .OrderBy(itemToProcess).Select(itemToProcess);

            foreach (var game in subset)
            {
                Console.WriteLine("Item: {0}", game);
            }
            Console.WriteLine();
        }

        // цели делегатов
        private static bool Filter(string game)
        {
            return game.Contains(" ");
        }

        private static string ProcessItem(string game)
        {
            return game;
        }
        #endregion

    }
}
