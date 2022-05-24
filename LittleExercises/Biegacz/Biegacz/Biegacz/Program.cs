using System;
using System.Collections.Generic;
using System.Linq;

namespace Biegacz
{
    class Program
    {
        static int Count(string input)
        {
            var runners = input.Split(',');
            List<TimeSpan> timeRunners = new List<TimeSpan>();

            List<TimeSpan> timeResults = new List<TimeSpan>();

            for (int i = 0; i < runners.Length; i++)
            {
                timeRunners.Add(TimeSpan.Parse("0:" + runners[i]));
            }

            for (int i = 0; i < timeRunners.Count; i++)
            {
                if (i == 0) timeResults.Add(timeRunners[i]);
                else timeResults.Add(timeRunners[i] - timeRunners[i - 1]);
            }

            TimeSpan sequenceSum = timeResults.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
            if (sequenceSum >= new TimeSpan(1, 0, 0)) throw new Exception();

            return timeRunners.Count;
        }

        static string Sequence(string input)
        {
            var runners = input.Split(',');
            List<TimeSpan> timeRunners = new List<TimeSpan>();
            string result = "";
            List<TimeSpan> timeResults = new List<TimeSpan>();;

            for (int i = 0; i < runners.Length; i++)
            {
                timeRunners.Add(TimeSpan.Parse("0:" + runners[i]));
            }

            for (int i = 0; i < timeRunners.Count; i++)
            {
                if (i == 0) timeResults.Add(timeRunners[i]);
                else timeResults.Add(timeRunners[i] - timeRunners[i - 1]);
            }

            TimeSpan sequenceSum = timeResults.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
            if (sequenceSum >= new TimeSpan(1, 0, 0)) throw new Exception();

            for (int i = 0; i < timeRunners.Count; i++)
            {
                if (i == 0) result += timeRunners[i].ToString(@"mm\:ss");
                else result += (timeRunners[i] - timeRunners[i - 1]).ToString(@"mm\:ss");
                if (i != timeRunners.Count) result += " ";
            }

            return result;
        }

        static string Slowest(string input)
        {
            var runners = input.Split(',');
            List<TimeSpan> timeRunners = new List<TimeSpan>();
            List<TimeSpan> timeResults = new List<TimeSpan>();
            TimeSpan timeResult = new TimeSpan();

            for (int i = 0; i < runners.Length; i++)
            {
                timeRunners.Add(TimeSpan.Parse("0:" + runners[i]));
            }

            for (int i = 0; i < timeRunners.Count; i++)
            {
                if (i == 0) timeResults.Add(timeRunners[i]);
                else timeResults.Add(timeRunners[i] - timeRunners[i - 1]);
            }
            TimeSpan sequenceSum = timeResults.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
            if (sequenceSum >= new TimeSpan(1, 0, 0)) throw new Exception();

            for (int i = 0; i < timeResults.Count; i++)
            {
                if (i == 0) timeResult = timeResults[i];
                if (i != 0 && timeResults[i] < timeResults[i - 1]) timeResult = timeResults[i];
            }
            var index = timeResults.Find(i => i == timeResult);
            string indexesResult = "";

            for (int i = 0; i < timeResults.Count; i++)
            {
                if (timeResults[i] == index)
                {
                    indexesResult += " " + (i + 1);
                }
            }

            return $"{timeResult:mm\\:ss}{indexesResult}";
        }

        static string Fastest(string input)
        {
            var runners = input.Split(',');
            List<TimeSpan> timeRunners = new List<TimeSpan>();
            List<TimeSpan> timeResults = new List<TimeSpan>();
            TimeSpan timeResult = new TimeSpan();

            for (int i = 0; i < runners.Length; i++)
            {
                timeRunners.Add(TimeSpan.Parse("0:" + runners[i]));
            }

            for (int i = 0; i < timeRunners.Count; i++)
            {
                if (i == 0) timeResults.Add(timeRunners[i]);
                else timeResults.Add(timeRunners[i] - timeRunners[i - 1]);
            }
            TimeSpan sequenceSum = timeResults.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
            if (sequenceSum >= new TimeSpan(1, 0, 0)) throw new Exception();

            for (int i = 0; i < timeResults.Count; i++)
            {
                if (i == 0) timeResult = timeResults[i];
                if (i != 0 && timeResults[i] > timeResults[i - 1]) timeResult = timeResults[i];
            }
            var index = timeResults.Find(i => i == timeResult);
            string indexesResult = "";

            for (int i = 0; i < timeResults.Count; i++)
            {
                if (timeResults[i] == index)
                {
                    indexesResult += " " + (i + 1);
                }
            }       

            return $"{timeResult:mm\\:ss}{indexesResult}";
        }

        static string Average(string input)
        {
            var runners = input.Split(',');
            List<TimeSpan> timeRunners = new List<TimeSpan>();
            List<TimeSpan> timeResults = new List<TimeSpan>();

            for (int i = 0; i < runners.Length; i++)
            {
                timeRunners.Add(TimeSpan.Parse("0:" + runners[i]));
            }

            for (int i = 0; i < timeRunners.Count; i++)
            {
                if (i == 0) timeResults.Add(timeRunners[i]);
                else timeResults.Add(timeRunners[i] - timeRunners[i - 1]);
            }
            TimeSpan sequenceSum = timeResults.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t));
            if (sequenceSum >= new TimeSpan(1, 0, 0)) throw new Exception();

            TimeSpan average = sequenceSum / timeResults.Count;

            return $"{TimeSpan.FromSeconds(Math.Ceiling(average.TotalSeconds)):mm\\:ss}";

        }

        static void Main(string[] args)
        {
            string testCase = Console.ReadLine();
            string data = Console.ReadLine();

            switch (testCase)
            {
                case "test1":
                    Console.WriteLine(Count(data));
                    break;
                case "test2":
                    Console.WriteLine(Sequence(data));
                    break;
                case "test3":
                    Console.WriteLine(Slowest(data));
                    break;
                case "test4":
                    Console.WriteLine(Fastest(data));
                    break;
                case "test5":
                    Console.WriteLine(Average(data));
                    break;
            }
        }
    }
}
