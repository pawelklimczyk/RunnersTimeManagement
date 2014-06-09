// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="UsersController.cs" project="RunnersTimeManagement.WebServer" date="2014-06-04 14:15">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WebServer.Controllers
{
    using System;
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

        [HttpPost]
        [ActionName("add")]
        public OperationStatus PostLogin(User model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ActionName("list")]
        public OperationStatus PostCreateAccount(User model)
        {
            throw new NotImplementedException();
        }
    }
}