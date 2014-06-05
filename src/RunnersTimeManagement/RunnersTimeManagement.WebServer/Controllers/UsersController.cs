// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="UsersController.cs" project="RunnersTimeManagement.WebServer" date="2014-06-04 14:15">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WebServer.Controllers
{
    using System.Net.Http;
    using System.Web.Http;

    using RunnersTimeManagement.Core.Domain;

    public class UsersController : ApiController
    {


        [HttpPost]
        [HttpGet]
        [ActionName("login")]
        public OperationStatus PostLogin(User model)
        {
            return OperationStatus.Failed("Wrong Username or password");
        }

        [HttpPost]
        [ActionName("createAccount")]
        public OperationStatus PostCreateAccount(User model)
        {
            return new OperationStatus();
        }
    }
}