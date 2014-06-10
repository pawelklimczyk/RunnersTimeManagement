// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ReportService.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-10 08:51">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.Services
{
    using System;

    using NPoco;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.ServerServices.ReportGenerator;

    public class ReportService : AbstractDatabaseService
    {
        private readonly IReportGenerator _reportGenerator;

        public ReportService(IDatabaseProvider provider = null, IReportGenerator reportGenerator = null)
            : base(provider)
        {
            if (reportGenerator == null)
            {
                reportGenerator = new ReportGenerator();
            }
            this._reportGenerator = reportGenerator;
        }

        public OperationStatus GetWeeklyReports(object token)
        {
            try
            {
                using (IDatabase db = this.CurrentDatabase)
                {
                    var existingUser = db.SingleOrDefault<User>("where accesstoken=@0", token);

                    if (existingUser == null)
                    {
                        return OperationStatus.Failed("Token is invalid");
                    }

                    var entries = db.Fetch<TimeEntry>("where userId=@0", existingUser.Id);

                    var report = this._reportGenerator.GenerateWeeklyReport(entries);

                    return OperationStatus.Passed("Report generated", report);
                }
            }
            catch (Exception exc)
            {
                Logger.LogException(exc);

                return OperationStatus.Failed("Error generating report");
            }
        }
    }
}
