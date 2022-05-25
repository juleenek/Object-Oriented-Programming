using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Frekwencja_znakow
{
    class Program
    {
        static Dictionary<char, int> SortByFreqency(string levels, Dictionary<char, int> inputDictionary, string secondSort = "", string secondLevels = "")
        {
            if(secondSort == "byfreq" || secondSort == "byletter")
            {
                if(secondSort == "byfreq")
                {
                    switch (levels)
                    {
                        case "asc":
                            if(secondLevels == "asc")
                            {
                                var result1 = from letters in inputDictionary orderby letters.Value ascending, letters.Value ascending select letters;
                                return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            if (secondLevels == "desc")
                            {
                                var result1 = from letters in inputDictionary orderby letters.Value ascending, letters.Value descending select letters;
                                return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            break;
                        case "desc":
                            if (secondLevels == "asc")
                            {
                                var result2 = from letters in inputDictionary orderby letters.Value descending, letters.Value ascending select letters;
                                return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            if (secondLevels == "desc")
                            {
                                var result2 = from letters in inputDictionary orderby letters.Value descending, letters.Value descending select letters;
                                return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            break;
                    }
                }
                if (secondSort == "byletter")
                {
                    switch (levels)
                    {
                        case "asc":
                            if (secondLevels == "asc")
                            {
                                var result1 = from letters in inputDictionary orderby letters.Value ascending, letters.Key ascending select letters;
                                return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            if (secondLevels == "desc")
                            {
                                var result1 = from letters in inputDictionary orderby letters.Value ascending, letters.Key descending select letters;
                                return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            break;
                        case "desc":
                            if (secondLevels == "asc")
                            {
                                var result2 = from letters in inputDictionary orderby letters.Value descending, letters.Key ascending select letters;
                                return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            if (secondLevels == "desc")
                            {
                                var result2 = from letters in inputDictionary orderby letters.Value descending, letters.Key descending select letters;
                                return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            break;
                    }
                }
            }
            if (secondSort == "" && secondSort == "")
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
            }


            return inputDictionary;
        }
        static Dictionary<char, int> SortByLetter(string levels, Dictionary<char, int> inputDictionary, string secondSort = "", string secondLevels = "")
        {
            if (secondSort == "byfreq" || secondSort == "byletter")
            {
                if (secondSort == "byfreq")
                {
                    switch (levels)
                    {
                        case "asc":
                            if(secondLevels == "asc")
                            {
                                var result1 = from letters in inputDictionary orderby letters.Key ascending, letters.Value ascending select letters;
                                return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            if(secondLevels == "desc")
                            {
                                var result1 = from letters in inputDictionary orderby letters.Key ascending, letters.Value descending select letters;
                                return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            break;
                        case "desc":
                            if (secondLevels == "asc")
                            {
                                var result2 = from letters in inputDictionary orderby letters.Key descending, letters.Value ascending select letters;
                                return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            if (secondLevels == "desc")
                            {
                                var result2 = from letters in inputDictionary orderby letters.Key descending, letters.Value descending select letters;
                                return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            break;                         
                    }
                }
                if(secondSort == "byletter")
                {
                    switch (levels)
                    {
                        case "asc":
                            if (secondLevels == "asc")
                            {
                                var result1 = from letters in inputDictionary orderby letters.Key ascending, letters.Key ascending select letters;
                                return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            if (secondLevels == "desc")
                            {
                                var result1 = from letters in inputDictionary orderby letters.Key ascending, letters.Key descending select letters;
                                return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            break;
                        case "desc":
                            if (secondLevels == "asc")
                            {
                                var result2 = from letters in inputDictionary orderby letters.Key descending, letters.Key ascending select letters;
                                return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            if (secondLevels == "desc")
                            {
                                var result2 = from letters in inputDictionary orderby letters.Key descending, letters.Key descending select letters;
                                return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                            }
                            break;
                    }
                }
            }

            if (secondSort == "" && secondSort == "")
            {
                switch (levels)
                {
                    case "asc":
                        var result1 = from letters in inputDictionary orderby letters.Key ascending select letters;
                        return result1.ToDictionary(pair => pair.Key, pair => pair.Value);
                    case "desc":
                        var result2 = from letters in inputDictionary orderby letters.Key descending select letters;
                        return result2.ToDictionary(pair => pair.Key, pair => pair.Value);
                }
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
                        if (4 < query.Length && 5 < query.Length)
                        {
                            if (query[3] == "asc") firstSort = SortByFreqency("asc", results, query[4], query[5]);
                            if (query[3] == "desc") firstSort = SortByFreqency("desc", results, query[4], query[5]);
                            break;
                        }
                        if (query[3] == "asc") firstSort = SortByFreqency("asc", results);
                        if (query[3] == "desc") firstSort = SortByFreqency("desc", results);
                        break;

                    case "byletter":
                        if (4 < query.Length && 5 < query.Length)
                        {
                            if (query[3] == "asc") firstSort = SortByLetter("asc", results, query[4], query[5]);
                            if (query[3] == "desc") firstSort = SortByLetter("desc", results, query[4], query[5]);
                            break;
                        }
                        if (query[3] == "asc") firstSort = SortByLetter("asc", results);
                        if (query[3] == "desc") firstSort = SortByLetter("desc", results);
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
