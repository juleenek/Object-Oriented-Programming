using System;
using TimeTimePeriod_Lib;

namespace TimeTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            //var time = new Time("1:2:1");
            //var time = new Time("11:2:1");
            //var time = new Time("11::");
            var time = new Time("::");
            Console.WriteLine(time);
        }
    }
}
