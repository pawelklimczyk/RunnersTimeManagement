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
        [ActionName("login")]
        public HttpResponseMessage PostLogin(User model)
        {
            return new HttpResponseMessage();
        }

        [HttpPost]
        [ActionName("createAccount")]
        public HttpResponseMessage PostCreateAccount(User model)
        {
            return new HttpResponseMessage();
        }
    }
}