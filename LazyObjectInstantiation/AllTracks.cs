using System;

namespace LazyObjectInstantiation
{
    internal class AllTracks
    {
        private Song[] allSongs = new Song[10000];
        public AllTracks()
        {
            // Здесь производится заполнение массива объектов Song
            Console.WriteLine("Filling up the songs");
        }
    }
}