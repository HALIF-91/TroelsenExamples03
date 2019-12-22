using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** LINQ Transformations ******");
            IEnumerable<string> subset = GetStringSubset();
            
            foreach (string item in subset)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            foreach (string item in GetStringSubsetAsArray())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static IEnumerable<string> GetStringSubset()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };

            IEnumerable<string> theRedColors = from color in colors
                                               where color.Contains("Red")
                                               select color;
            return theRedColors;
        }
        static string[] GetStringSubsetAsArray()
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };

            var theRedColors = from c in colors where c.Contains("Red") select c;

            return theRedColors.ToArray();
        }
    }
}
