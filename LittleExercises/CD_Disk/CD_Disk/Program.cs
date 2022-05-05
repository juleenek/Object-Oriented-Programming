using System;
using System.Collections.Generic;
using System.Linq;

namespace CD
{
    class Program
    {
        public static void SongsMethod(string input)
        {
            var songs = input.Split(',');
            List<TimeSpan> timeSongs = new List<TimeSpan>();

            for (int i = 0; i < songs.Length; i++)
            {
                timeSongs.Add(TimeSpan.Parse("0:" + songs[i]));
            }
            foreach (var song in timeSongs)
            {
                if (song.Hours > 0) throw new Exception("Piosenki nie mogą trwać więcej niż godzinę");
            }

            TimeSpan songsSum = timeSongs.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
            string songSumStr = songsSum.ToString(@"m\:ss");

            var average = songsSum / timeSongs.Count;

            if (songsSum.Hours > 0) songSumStr = songsSum.ToString(@"h\:mm\:ss");

            Console.WriteLine($"{timeSongs.Count} " +
                $"{TimeSpan.FromSeconds(Math.Round(average.TotalSeconds)).ToString(@"m\:ss")} " +
                $"{songSumStr}");
        }
        static void Main(string[] args)
        {           
           SongsMethod(Console.ReadLine());                
        }
    }
}