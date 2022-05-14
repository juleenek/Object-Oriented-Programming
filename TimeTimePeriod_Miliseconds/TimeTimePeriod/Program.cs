using System;
using TimeTimePeriod_Lib;

namespace TimeTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            TimePeriod timePeriod = new TimePeriod(periodMilliseconds: 12233456);
            Console.WriteLine(timePeriod);
        }
    }
}
