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
            //var time = new Time("::");
            //Console.WriteLine(time);

            //var time1 = new Time("::");
            //var time2 = new Time(0);

            var time1 = new Time("::1");
            var time2 = new Time(0, seconds: 1);
            Console.WriteLine(time1.Equals(time2));

        }
    }
}
