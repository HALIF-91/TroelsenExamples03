using System;

namespace FinalizableDisposableClass
{
    internal class MyResourceWrapper : IDisposable
    {
        // Используется для выяснения того, вызывался ли уже метод Dispose()
        private bool disposed = false;
        public string Str { get; set; } = "Hello";
        // Пользователь объекта будет вызывать этот метод
        // для очистки ресурсов как можно быстрее
        public void Dispose()
        {
            // вызвать вспомогательный метод
            // указание true означает, что очистку запустил пользователь объекта
            CleanUp(true);

            // если пользователь вызвал Dispose(), то финализация не нужна
            // подавить финализацию
            GC.SuppressFinalize(this);
        }
        private void CleanUp(bool disposing)
        {
            // удостовериться, не выполнялось ли уже освобождение
            if (!this.disposed)
            {
                // если disposing равно true, освободить все управляемые ресурсы
                if (disposing)
                {
                    // освободить управляемые ресурсы
                    Str = null;
                }
                // очистить неуправляемые ресурсы
            }
            disposed = true;
        }
        // сборщик мусора будет вызывать этот метод, если
        // пользователь объекта забыл вызвать Dispose()
        ~MyResourceWrapper()
        {
            Console.Beep();
            // вызвать вспомогательный метод
            // указание false означает, что очистку запустил сборщик мусора
            CleanUp(false);
        }
    }
}