using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Никакого размещения объекта AllTracks здесь не происходит
            // из-за ленивого создания объектов
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Play();

            // Размещение объекта AllTracks происходит
            // только в случае вызова метода GetAllTracks()
            MediaPlayer yourPlayer = new MediaPlayer();
            AllTracks yourMusic = yourPlayer.GetAllTracks();

            Console.ReadLine();
        }
    }
}
