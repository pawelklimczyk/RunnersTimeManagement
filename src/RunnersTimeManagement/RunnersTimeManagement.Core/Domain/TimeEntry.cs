﻿// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TimeEntry.cs" project="RunnersTimeManagement.Core" date="2014-06-08 13:54">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.Core.Domain
{
    using System;

    public class TimeEntry
    {
        public TimeEntry()
        {
            EntryDate = DateTime.Now;
        }

        public long Id { get; set; }
        public long UserId { get; set; }

        public DateTime EntryDate { get; set; }

        /// <summary>
        ///     In meters
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        ///     In seconds
        /// </summary>
        public double TimeElapsed { get; set; }

        /// <summary>
        /// in km/h
        /// </summary>
        public double AverageSpeed
        {
            get
            {
                if (Distance > 0 && TimeElapsed > 0)
                {
                    return Math.Round(Distance / TimeElapsed * 3.6, 2);
                }

                return 0;
            }
        }
    }
}