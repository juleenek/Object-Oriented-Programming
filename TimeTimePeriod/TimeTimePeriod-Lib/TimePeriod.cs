using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTimePeriod_Lib
{
    public struct TimePeriod
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
        /// Constructor of Time struct, which takes a String parameter with the format hh:mm:ss
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
    }
}
