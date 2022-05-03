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
    public struct Time 
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
        /// Two parameters: hours, minutes, 0 
        /// One parameter: hours, 0, 0
        /// </summary>
        /// <param name="hours"> Representation of hours over time </param>
        /// <param name="minutes"> Representation of minutes over time </param>
        /// <param name="seconds"> Representation of seconds over time </param>
        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            if (hours >= 24 || hours < 0) throw new ArgumentException("Hours was entered incorrectly.");
            if (minutes >= 60 || minutes < 0) throw new ArgumentException("Minutes was entered incorrectly.");
            if (seconds >= 60 || seconds < 0) throw new ArgumentException("Seconds was entered incorrectly.");

            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
    }
}
