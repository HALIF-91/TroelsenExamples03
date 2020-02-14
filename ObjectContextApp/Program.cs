using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectContextApp
{
    // SportsCar не имеет никаких специальных контекстных потребностей
    // и будет загружаться в стандартный контекст домена приложения
    class SportsCar
    {
        public SportsCar()
        {
            // Получить информацию о контексте и вывести идентификатор контекста
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty itfCtxProp in ctx.ContextProperties)
            {
                Console.WriteLine("-> Ctx Prop: {0}", itfCtxProp.Name);
            }
        }
    }
    // SportsCarTS требует загрузки в синхронизированный контекст
    [Synchronization]
    class SportsCarTS : ContextBoundObject
    {
        public SportsCarTS()
        {
            // Получить информацию о контексте и вывести идентификатор конткеста
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty itfCtxProp in ctx.ContextProperties)
            {
                Console.WriteLine("-> Ctx Prop: {0}", itfCtxProp.Name);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Fun with Object Context *****\n");

            // Объекты при создании будут отображать контекстную информацию
            SportsCar sport = new SportsCar();
            Console.WriteLine();

            SportsCar sport2 = new SportsCar();
            Console.WriteLine();

            SportsCarTS synchroSport = new SportsCarTS();

            Console.ReadLine();
        }
    }
}
