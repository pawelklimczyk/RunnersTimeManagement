// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ReportGenerator.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-10 08:55">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.ReportGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using RunnersTimeManagement.Core.Domain;

    public class ReportGenerator : IReportGenerator
    {
        //fixme:assuming that all entries are in the same, current year
        public IList<WeeklyReport> GenerateWeeklyReport(IList<TimeEntry> entries)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;


            int weeksCount = GetWeeksInYear(DateTime.Now.Year);
            List<WeeklyReport> list = new List<WeeklyReport>(weeksCount);

            for (int i = 1; i <= weeksCount; i++)
            {
                var entriesForCurrentWeek = entries.Where(entry => cal.GetWeekOfYear(entry.EntryDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek) == i).ToList();
                WeeklyReport report = new WeeklyReport
                                          {
                                              Week = i
                                          };

                if (entriesForCurrentWeek.Count > 0)
                {
                    report.AverageDistance = entriesForCurrentWeek.Average(entry => entry.Distance);
                    report.AverageSpeed = entriesForCurrentWeek.Average(entry => entry.AverageSpeed);
                }

                list.Add(report);
            }


            return list;
        }
        private int GetWeeksInYear(int year)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime dateTime = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(dateTime, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }
    }
}
