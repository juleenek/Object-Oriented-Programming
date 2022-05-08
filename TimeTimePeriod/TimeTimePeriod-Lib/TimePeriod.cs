using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTimePeriod_Lib
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private long periodSeconds;

        /// <summary>
        /// Time period expressed in seconds
        /// </summary>
        public readonly long PeriodSeconds => periodSeconds;

        /// <summary>
        /// Representation of hours in a time period, read-only field
        /// </summary>
        public readonly long Hours => periodSeconds / 3600;

        /// <summary>
        /// Representation of minutes in a time period, read-only field
        /// </summary>
        public readonly long Minutes => (periodSeconds / 60) % 60;

        /// <summary>
        /// Representation of seconds in a time period, read-only field
        /// </summary>
        public readonly long Seconds => periodSeconds % 60;

        /// <summary>
        /// Constructor of TimePeriod struct that takes into account three variants of initializing
        /// Three parameters: hours, minutes, seconds
        /// Two parameters: hours, minutes (default value of seconds is 0)  
        /// One parameter: hours (default value of minutes and seconds is 0)  
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when parameters are negative and when minutes and seconds are greater than 59
        /// The "TimeParamsCheck" method is used to throw this exception when the arguments are invalid
        /// </exception>
        /// <param name="hours"> Representation of hours in a time period </param>
        /// <param name="minutes"> Representation of minutes in a time period </param>
        /// <param name="seconds"> Representation of seconds in a time period </param>
        public TimePeriod(long hours = 0, long minutes = 0, long seconds = 0)
        {
            TimeParamsCheck(hours, minutes, seconds);
            periodSeconds = (hours * 3600) + (minutes * 60) + seconds;
        }

        /// <summary>
        /// A private method that checks if the arguments (hours, minutes, seconds) are valid.
        /// Method was used in constructors. 
        /// </summary>
        /// <param name="hours"> Representation of hours in a time period </param>
        /// <param name="minutes"> Representation of minutes in a time period </param>
        /// <param name="seconds"> Representation of seconds in a time period </param>
        static private void TimeParamsCheck(long hours, long minutes, long seconds)
        {
            if (hours < 0) throw new ArgumentException("Hours was entered incorrectly.");
            if (minutes >= 60 || minutes < 0) throw new ArgumentException("Minutes was entered incorrectly.");
            if (seconds >= 60 || seconds < 0) throw new ArgumentException("Seconds was entered incorrectly.");
        }

        /// <summary>
        /// Constructor of TimePeriod struct, which takes two Time type parameters
        /// Seconds calculated from the absolute value of the time difference of the two parameters
        /// </summary>
        /// <param name="firstTime"> First Time type parameter </param>
        /// <param name="secondTime"> Second Time type parameter </param>
        public TimePeriod(Time firstTime, Time secondTime)
        {
            try
            {
                long firstTimeSeconds = firstTime.Seconds * 3600 + firstTime.Seconds * 60 + firstTime.Seconds;
                long secondTimeSeconds = secondTime.Seconds * 3600 + secondTime.Seconds * 60 + secondTime.Seconds;

                periodSeconds = Math.Abs(firstTimeSeconds - secondTimeSeconds); // Math.Abs - Returns the absolute value of a specified number.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Constructor of TimePeriod struct, which takes a String parameter with the format hh:mm:ss
        /// </summary>
        /// <exception cref="FormatException">
        /// Thrown when the parameter does not match the format hh:mm:ss
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when parameters are negative and when minutes and seconds are greater than 59
        /// The "TimeParamsCheck" method is used to throw this exception when the arguments are invalid
        /// </exception>
        /// <param name="timePeriod"> Representation of a time period as String </param>
        public TimePeriod(string timePeriod)
        {
            if (timePeriod is null || !timePeriod.Contains(":")) throw new FormatException("Invalid format.");

            string[] splittedTime = timePeriod.Split(":");

            if (splittedTime.Length != 3) throw new FormatException("Invalid format.");
            if (splittedTime[0] == "") splittedTime[0] = "0";
            if (splittedTime[1] == "") splittedTime[1] = "0";
            if (splittedTime[2] == "") splittedTime[2] = "0";

            long hours, minutes, seconds;

            try
            {
                hours = long.Parse(splittedTime[0]);
                minutes = long.Parse(splittedTime[1]);
                seconds = long.Parse(splittedTime[2]);
            }
            catch (Exception)
            {
                throw new FormatException("Invalid format, arguments must be a numbers.");
            }

            TimeParamsCheck(hours, minutes, seconds);
            periodSeconds = (hours * 3600) + (minutes * 60) + seconds;
        }

        /// <summary>
        /// Overriding ToString method
        /// </summary>
        /// <returns> Returns the standard text representation of time period in the format hh:mm:ss </returns>
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

        /// <summary>
        /// Implemented IEquatable<TimePeriod> interface
        /// </summary>
        /// <param name="other"> Comparison object of TimePeriod type </param>
        /// <returns> Returns bool if both objects are equal - have the same parameter PeriodSecond </returns>
        public bool Equals(TimePeriod other) => PeriodSeconds == other.PeriodSeconds;

        /// <summary>
        /// Overloaded Equals method
        /// </summary>
        /// <param name="obj"> Comparison object </param>
        /// <returns> Returns bool if both objects are equal - have the same parameter PeriodSecond </returns>
        public override bool Equals(object obj)
        {
            if (obj is TimePeriod) return base.Equals(obj);
            return false;
        }

        /// <summary>
        /// Implemented IComparable<TimePeriod> interface
        /// </summary>
        /// <param name="other"> Comparison object of TimePeriod type </param>
        /// <returns> 
        /// Return the integer:
        /// -1 if the object on which the method is used is shorter time period than the object (param "other") on which the comparison is used
        /// 0 if the object on which the method is used is the same time period as the object (param "other") on which the comparison is used
        /// 1 if the object on which the method is used is longer time period than the object (param "other") on which the comparison is used
        /// </returns>
        public int CompareTo(TimePeriod other)
        {
            if (Equals(other)) return 0;

            if (PeriodSeconds > other.PeriodSeconds)
                return 1;

            return -1;
        }

        /// <summary>
        /// Overriding GetHashCode method
        /// </summary>
        /// <returns> A hash code for the current object. </returns>
        public override int GetHashCode() => (PeriodSeconds).GetHashCode();

        /// <summary>
        /// Overloaded relational operator ==
        /// </summary>
        public static bool operator ==(TimePeriod left, TimePeriod right) => left.Equals(right);

        /// <summary>
        /// Overloaded relational operator !=
        /// </summary>
        public static bool operator !=(TimePeriod left, TimePeriod right) => !(left == right);

        /// <summary>
        /// Overloaded relational operator <
        /// </summary>
        public static bool operator <(TimePeriod left, TimePeriod right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Overloaded relational operator <=
        /// </summary>
        public static bool operator <=(TimePeriod left, TimePeriod right) => left.CompareTo(right) <= 0;

        /// <summary>
        /// Overloaded relational operator >
        /// </summary>
        public static bool operator >(TimePeriod left, TimePeriod right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Overloaded relational operator >=
        /// </summary>
        public static bool operator >=(TimePeriod left, TimePeriod right) => left.CompareTo(right) >= 0;
    }
}
