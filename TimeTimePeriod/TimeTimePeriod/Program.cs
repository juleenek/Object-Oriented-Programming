﻿using System;
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

        }
    }
}