using System;

namespace LazyObjectInstantiation
{
    internal class MediaPlayer
    {
        public void Play() { Console.WriteLine("Воспроизведение композиции"); }
        public void Pause() { Console.WriteLine("Пауза в воспроизведении"); }
        public void Stop() { Console.WriteLine("Остановка воспроизведения"); }

        private Lazy<AllTracks> allSongs = new Lazy<AllTracks>();

        // использовать лямбда выражение для добавления
        // дополнительного кода при создании объекта AllTracks
        private Lazy<AllTracks> allSongs2 = new Lazy<AllTracks>(() =>
            {
                Console.WriteLine("Creating AllTracks object!");
                return new AllTracks();
            });
        public AllTracks GetAllTracks()
        {
            // возвратить все композиции
            return allSongs.Value;
        }
    }
}