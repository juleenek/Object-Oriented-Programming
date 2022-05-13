using System;
using TimeTimePeriod_Lib;

namespace TimeTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ogólne

            //var time = new Time("1:2:1");
            //var time = new Time("11:2:1");
            //var time = new Time("11::");
            //var time = new Time("::");
            //Console.WriteLine(time);

            // Equals

            //var time1 = new Time("::");
            //var time2 = new Time(0);

            //var time1 = new Time("::1");
            //var time2 = new Time(0, seconds: 1);
            //Console.WriteLine(time1.Equals(time2));

            // CompareTo

            //var time1 = new Time("1::");
            //var time2 = new Time(1, seconds: 1);

            //var time1 = new Time("::1");
            //var time2 = new Time(1, seconds: 1);

            //var time1 = new Time("::1");
            //var time2 = new Time(seconds: 1);

            //var time1 = new Time("19::59");
            //var time2 = new Time(19, 1);

            //Console.WriteLine(time1.CompareTo(time2));

            // Operators

            //var time1 = new Time("19:1:");
            //var time2 = new Time(19, 1);
            //var time1 = new Time("19:1:");
            //var time2 = new Time(19, 0, 59);

            //Console.WriteLine(time1 == time2);
            //Console.WriteLine(time1 != time2);
            //Console.WriteLine(time1 > time2);
            //Console.WriteLine(time1 >= time2);
            //Console.WriteLine(time1 < time2);
            //Console.WriteLine(time1 <= time2);

            ///////////////////////////////////////////////////////////////////////////////

            // TimePeriod

            //var timeP = new TimePeriod(27, 2);
            //var timeP = new TimePeriod("20939:23:");
            //var timeP = new TimePeriod("20939::");
            //Console.WriteLine(timeP);

            // Time + TimePeriod

            //var time = new Time(23, 40, 6);
            //var timePeriod = new TimePeriod(2, 30, 20);
            //Console.WriteLine(time + timePeriod);

            //var time = new Time(23, 40, 6);
            //var timePeriod = new TimePeriod(30, 59, 59);
            //Console.WriteLine(time + timePeriod); ;

            //var time = new Time(23, 40, 6);
            //var timePeriod = new TimePeriod(90, 59, 59);
            //Console.WriteLine(time + timePeriod);
            //Console.WriteLine(time.Plus(timePeriod));
            //Console.WriteLine(Time.Plus(time, timePeriod));

            //var time = new Time(23, 40, 6);
            //var timePeriod = new TimePeriod(90, 59, 59);
            //Console.WriteLine(time - timePeriod);
            //Console.WriteLine(time.Minus(timePeriod));
            //Console.WriteLine(Time.Minus(time, timePeriod));

            //var timeP1 = new TimePeriod(27, 2);
            //var timeP2 = new TimePeriod("432000:10:00");
            //var timeP3 = new TimePeriod("220:59:00");
            //Console.WriteLine($"{timeP2} {timeP3} {timeP2 - timeP3}");


            var timeP3 = new TimePeriod(periodSeconds: 0);
            Console.WriteLine(timeP3);
        }
    }
}
