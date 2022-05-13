using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTimePeriod_Lib
{
    /// <summary>
    ///  The struct specifies a point in time at 00:00:00… 23:59:59
    /// </summary>
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        private byte hours;
        private byte minutes;
        private byte seconds;

        /// <summary>
        /// Representation of hours over time, read-only field
        /// </summary>
        public readonly byte Hours => hours;

        /// <summary>
        /// Representation of minutes over time, read-only field
        /// </summary>
        public readonly byte Minutes => minutes;

        /// <summary>
        /// Representation of seconds over time, read-only field
        /// </summary>
        public readonly byte Seconds => seconds;

        /// <summary>
        /// Constructor of Time struct that takes into account three variants of initializing
        /// Three parameters: hours, minutes, seconds
        /// Two parameters: hours, minutes (default value of seconds is 0)  
        /// One parameter: hours (default value of minutes and seconds is 0)  
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when parameters are not in range  00:00:00… 23:59:59
        /// The "TimeParamsCheck" method is used to throw this exception when the arguments are invalid
        /// </exception>
        /// <param name="hours"> Representation of hours over time </param>
        /// <param name="minutes"> Representation of minutes over time </param>
        /// <param name="seconds"> Representation of seconds over time </param>
        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            TimeParamsCheck(hours, minutes, seconds);

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        /// <summary>
        /// Constructor of Time struct, which takes a String parameter with the format hh:mm:ss
        /// </summary>
        /// <exception cref="FormatException">
        /// Thrown when the parameter does not match the format hh:mm:ss
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when parameters are not in range  00:00:00… 23:59:59
        /// The "TimeParamsCheck" method is used to throw this exception when the arguments are invalid
        /// </exception>
        /// <param name="time"> Representation of a point in time as String </param>
        public Time(string time)
        {
            if (time is null || !time.Contains(":")) throw new FormatException("Invalid format.");

            string[] splittedTime = time.Split(":");

            if (splittedTime.Length != 3) throw new FormatException("Invalid format.");
            if (splittedTime[0] == "") splittedTime[0] = "0";
            if (splittedTime[1] == "") splittedTime[1] = "0";
            if (splittedTime[2] == "") splittedTime[2] = "0";

            byte hours, minutes, seconds;

            try
            {
                hours = byte.Parse(splittedTime[0]);
                minutes = byte.Parse(splittedTime[1]);
                seconds = byte.Parse(splittedTime[2]);  
            }
            catch (Exception)
            {
                throw new FormatException("Invalid format, arguments must be a numbers.");
            }

            TimeParamsCheck(hours, minutes, seconds);

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        /// <summary>
        /// A private method that checks if the arguments (hours, minutes, seconds) are valid.
        /// Method was used in constructors. 
        /// </summary>
        /// <param name="hours"> Representation of hours over time </param>
        /// <param name="minutes"> Representation of minutes over time </param>
        /// <param name="seconds"> Representation of seconds over time </param>
        static private void TimeParamsCheck(byte hours, byte minutes, byte seconds)
        {
            if (hours >= 24 || hours < 0) throw new ArgumentException("Hours was entered incorrectly.");
            if (minutes >= 60 || minutes < 0) throw new ArgumentException("Minutes was entered incorrectly.");
            if (seconds >= 60 || seconds < 0) throw new ArgumentException("Seconds was entered incorrectly.");
        }

        /// <summary>
        /// Overriding ToString method
        /// </summary>
        /// <returns> Returns the standard text representation of time in the format hh:mm:ss </returns>
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        /// <summary>
        /// Implemented IEquatable<Time> interface
        /// </summary>
        /// <param name="other"> Comparison object of Time type </param>
        /// <returns> Returns bool if both objects are equal - have the same parameters (hours, minutes and seconds) </returns>
        public bool Equals(Time other) => (Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds);

        /// <summary>
        /// Overloaded Equals method
        /// </summary>
        /// <param name="obj"> Comparison object </param>
        /// <returns> Returns bool if both objects are equal - have the same parameters (hours, minutes and seconds) </returns>
        public override bool Equals(object obj)
        {
            if(obj is Time) return base.Equals(obj);
            return false;
        }

        /// <summary>
        /// Implemented IComparable<Time> interface
        /// </summary>
        /// <param name="other"> Comparison object of Time type </param>
        /// <returns> 
        /// Return the integer:
        /// -1 if the object on which the method is used is an earlier point in time than the object (param "other") on which the comparison is being used
        /// 0 if the object on which the method is used is the same point in time as the object (param "other") on which the comparison is used
        /// 1 if the object on which the method is used is a later point in time than the object (param "other") on which the comparison is used
        /// </returns>
        public int CompareTo(Time other)
        {
            if(Equals(other)) return 0;

            if (Hours > other.Hours)
                return 1;

            if (Hours < other.Hours)
                return -1;

            if (Minutes > other.Minutes)
                return 1;

            if (Minutes == other.Minutes)
                if (Seconds > other.Seconds)
                    return 1;

            return -1;
        }

        /// <summary>
        /// Overriding GetHashCode method
        /// </summary>
        /// <returns> A hash code for the current object. </returns>
        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();

        /// <summary>
        /// Overloaded relational operator ==
        /// </summary>
        public static bool operator ==(Time left, Time right) => left.Equals(right);

        /// <summary>
        /// Overloaded relational operator !=
        /// </summary>
        public static bool operator !=(Time left, Time right) => !(left == right);

        /// <summary>
        /// Overloaded relational operator <
        /// </summary>
        public static bool operator <(Time left, Time right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Overloaded relational operator <=
        /// </summary>
        public static bool operator <=(Time left, Time right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Overloaded relational operator >
        /// </summary>
        public static bool operator >(Time left, Time right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Overloaded relational operator >=
        /// </summary>
        public static bool operator >=(Time left, Time right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Overloaded operator +, adds a period of time (timePeriod) to a point in time (time)
        /// </summary>
        /// <param name="time"> The point in time to which it will be added time period </param>
        /// <param name="timePeriod"> Time period that will be added to the time </param>
        /// <returns> Returns point in time with an added time period </returns>
        public static Time operator +(Time time, TimePeriod timePeriod)
        {
            long secondsTime = (time.Hours * 3600) + (time.Minutes * 60) + time.Seconds;
            long secondsSum = secondsTime + timePeriod.PeriodSeconds;

            long seconds = secondsSum % 60;
            long minutes = (secondsSum / 60) % 60;
            long hours = (secondsSum);

            if (time.Seconds + timePeriod.Seconds > 60) minutes++;
            if (time.Minutes + timePeriod.Seconds > 60) hours += 60;

            hours /= 3600;
            hours %= 24;

            return new Time((byte)hours, (byte)minutes, (byte)seconds);

        }

        /// <summary>
        /// Adds a period of time (timePeriod) to a point in time (time)
        /// </summary>
        /// <param name="time"> The point in time to which it will be added time period </param>
        /// <param name="timePeriod"> Time period that will be added to the time </param>
        /// <returns> Returns point in time with an added time period </returns>
        public static Time Plus(Time time, TimePeriod timePeriod) => time + timePeriod;

        /// <summary>
        /// Adds a period of time (timePeriod) to a point in time
        /// </summary>
        /// <param name="timePeriod"> Time period that will be added to the time </param>
        /// <returns> Returns point in time with an added time period </returns>
        public Time Plus(TimePeriod timePeriod) => this + timePeriod;

        /// <summary>
        /// Overloaded operator -, subtracts a period (timePeriod) from a point in time (time)
        /// </summary>
        /// <param name="time"> The point in time from which the period will be subtracted </param>
        /// <param name="timePeriod"> Time period that will be subtracted from time </param>
        /// <returns> Returns point in time with an subtracted time period </returns>
        public static Time operator -(Time time, TimePeriod timePeriod)
        {
            long secondsTime = (time.Hours * 3600) + (time.Minutes * 60) + time.Seconds;
            long secondsSum = Math.Abs(secondsTime - timePeriod.PeriodSeconds);

            long secunds = secondsSum % 60;
            long minutes = (secondsSum / 60) % 60;
            long hours = (secondsSum);

            if (time.Seconds + timePeriod.Seconds > 60) minutes++;
            if (time.Minutes + timePeriod.Minutes > 60) hours += 60;

            hours /= 3600;
            hours %= 24;

            return new Time((byte)hours, (byte)minutes, (byte)secunds);

        }

        /// <summary>
        /// Subtracts a period (timePeriod) from a point in time (time)
        /// </summary>
        /// <param name="time"> The point in time from which the period will be subtracted </param>
        /// <param name="timePeriod"> Time period that will be subtracted from time </param>
        /// <returns> Returns point in time with an subtracted time period </returns>
        public static Time Minus(Time time, TimePeriod timePeriod) => time - timePeriod;

        /// <summary>
        /// Subtracts a period (timePeriod) from a point in time
        /// </summary>
        /// <param name="timePeriod"> Time period that will be subtracted from time </param>
        /// <returns> Returns point in time with an subtracted time period </returns>
        public Time Minus(TimePeriod timePeriod) => this - timePeriod;
    }
}

