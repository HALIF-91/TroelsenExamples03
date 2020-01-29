using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LastBindingWithDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.Load("CarLibrary");
            AddWithReflection();
            AddWithDynamic();
            CreateUsingLateBinding(asm);
            InvokeMethodWithDynamicKeyword(asm);
        }
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа MiniVan
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                // Создать объект MiniVan на лету
                object obj = Activator.CreateInstance(miniVan);
                // Получить информацию для TurboBoost
                MethodInfo mi = miniVan.GetMethod("TurboBoost");
                // Вызвать иетод (null означает отсутствие параметоров)
                mi.Invoke(obj, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void InvokeMethodWithDynamicKeyword(Assembly asm)
        {
            try
            {
                // Получить метаданные для типа MiniVan
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                // Создать объект MiniVan на лету и вызвать метод
                dynamic obj = Activator.CreateInstance(miniVan);
                obj.TurboBoost();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void AddWithReflection()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Получить метаданные для типа SimpleMath
                Type math = asm.GetType("MathLibrary.SimpleMath");

                // Создать объект SimpleMath на лету
                object obj = Activator.CreateInstance(math);

                // Получить информацию по методу Add
                MethodInfo mi = math.GetMethod("Add");

                // Вызвать метод с параметрами
                object[] args = { 10, 70 };
                Console.WriteLine("Result is: {0}", mi.Invoke(obj, args));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void AddWithDynamic()
        {
            Assembly asm = Assembly.Load("MathLibrary");
            try
            {
                // Получить метаданные для типа SimpleMath
                Type math = asm.GetType("MathLibrary.SimpleMath");

                // Создать объект SimpleMath на лету и вызвать метод
                dynamic obj = Activator.CreateInstance(math);
                Console.WriteLine("Result is: {0}", obj.Add(10, 70));
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
