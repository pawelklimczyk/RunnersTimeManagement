// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="UsersController.cs" project="RunnersTimeManagement.WebServer" date="2014-06-04 14:15">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WebServer.Controllers
{
    using System.Web.Http;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.ServerServices.Services;

    public class TimeController : ApiController
    {
        private TimeService timeService;
        public TimeService _timeService
        {
            get
            {
                return this.timeService ?? (this.timeService = new TimeService());
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
        [ActionName("add")]
        public OperationStatus PostAddTimeEntry(TimeEntry timeEntry)
        {
            string token = ServerHelpers.GetAccessTokenFromRequest(this.Request);
            if ((bool)_usersService.Authorize(token))
            {
                return _timeService.InsertTimeEntry(timeEntry, token);
            }
            else
            {
                return OperationStatus.Failed("Token is invalid");
            }
        }

        [HttpPost]
        [ActionName("list")]
        public OperationStatus PostGetTimeEntries()
        {
            string token = ServerHelpers.GetAccessTokenFromRequest(this.Request);
            if ((bool)_usersService.Authorize(token))
            {
                return _timeService.GetTimeEntryList(token);
            }
            else
            {
                return OperationStatus.Failed("Token is invalid");
            }
        }
    }
}