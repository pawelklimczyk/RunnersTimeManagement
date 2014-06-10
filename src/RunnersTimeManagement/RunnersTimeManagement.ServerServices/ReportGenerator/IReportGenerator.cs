// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="IReportGenerator.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-10 08:55">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------
namespace RunnersTimeManagement.ServerServices.ReportGenerator
{
    using System.Collections.Generic;

    using RunnersTimeManagement.Core.Domain;

    public interface IReportGenerator
    {
        IList<WeeklyReport> GenerateWeeklyReport(IList<TimeEntry> entries);
    }
}