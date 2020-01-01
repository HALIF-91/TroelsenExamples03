using System;

namespace SimpleDispose
{
    internal class MyResourceWrapper : IDisposable
    {
        public void Dispose()
        {
            // Очистить неуправляемые ресурсы
            // Освободить другие содержащиеся внутри освобождаемые объекты
            // Только для целей тестирования
            Console.WriteLine("******** In Dispose! *******");
        }
    }
}