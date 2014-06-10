// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ReportsController.cs" project="RunnersTimeManagement.WebServer" date="2014-06-10 08:58">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WebServer.Controllers
{
    using System.Web.Http;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.ServerServices.Services;

    public class ReportsController : ApiController
    {
        private ReportService reportService;
        public ReportService _reportService
        {
            get
            {
                return this.reportService ?? (this.reportService = new ReportService());
            }
        }

        private UsersService usersService;
        public UsersService _usersService
        {
            get
            {
                return usersService ?? (usersService = new UsersService());
            }
        }

        [HttpPost]
        [ActionName("weeklyReport")]
        public OperationStatus PostGetWeeklyReport()
        {
            string token = ServerHelpers.GetAccessTokenFromRequest(this.Request);
            if ((bool)_usersService.Authorize(token))
            {
                return this._reportService.GetWeeklyReports(token);
            }
            else
            {
                return OperationStatus.Failed("Token is invalid");
            }
        }
    }
}
