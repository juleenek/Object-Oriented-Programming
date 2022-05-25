using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Frekwencja_znakow
{
    class Program
    {
        static Dictionary<char, int> SortByFreqency(string levels, Dictionary<char, int> inputDictionary)
        {
            switch (levels)
            {
                case "asc":
                    var result1 = from letters in inputDictionary orderby letters.Value ascending select letters;
                    return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                case "desc":
                    var result2 = from letters in inputDictionary orderby letters.Value descending select letters;
                    return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            return inputDictionary;
        }

        static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {
                string text = Console.ReadLine();
                string queryInput = Console.ReadLine();

                List<char> letters = new List<char>();
                //List<string> query = new List<string>();
                var query = queryInput.Split(' ');

                for (int j = 0; j < text.Length; j++)
                {
                    if (char.IsLetter(text[j])) letters.Add(char.ToLower(text[j]));
                }

                var results = letters.GroupBy(c => c)
                         .ToDictionary(g => g.Key, g => g.Count());

                Dictionary<char, int> firstSort = new Dictionary<char, int>();

                switch (query[2])
                {
                    case "byfreq":
                        if (query[3] == "asc") firstSort = SortByFreqency("asc", results);
                        if (query[3] == "desc") firstSort = SortByFreqency("desc", results);
                        break;
                }

                foreach (var item in firstSort)
                {
                    Console.WriteLine(item);
                }

            }
        }
    }
}
