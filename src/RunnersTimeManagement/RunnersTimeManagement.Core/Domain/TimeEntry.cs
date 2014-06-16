// -------------------------------------------------------------------------------------------------------------------
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

    public class TimeEntryFilter
    {

        private DateTime? _startDate;
        private DateTime? _endDate;

        public DateTime? StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    if (_startDate.HasValue)
                    {
                        _startDate = _startDate.Value.Date;
                    }
                }
            }
        }
        public DateTime? EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    if (_endDate.HasValue)
                    {
                        _endDate = _endDate.Value.Date.AddDays(1).AddMilliseconds(-1);
                    }
                }
            }
        }

        public bool HasFilter
        {
            get
            {
                return (StartDate != null && EndDate != null && (bool)this.Validate());
            }
        }

        public OperationStatus Validate()
        {
            if (StartDate == null && EndDate == null)
            {
                return OperationStatus.Passed("No filter specified");
            }

            if (StartDate <= EndDate)
            {
                return OperationStatus.Passed("Valid filter");
            }

            if (StartDate == null)
            {
                return OperationStatus.Failed("Please provide start date");
            }

            if (EndDate == null)
            {
                return OperationStatus.Failed("Please provide end date");
            }

            return OperationStatus.Failed("Start date must be lesser or equal");
        }
    }
}