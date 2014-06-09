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

    public class UsersController : ApiController
    {
        private UsersService usersService;
        public UsersService _usersService
        {
            get
            {
                return usersService ?? (usersService = new UsersService());
            }
        }

        [HttpPost]
        [ActionName("login")]
        public OperationStatus PostLogin(User model)
        {
            return _usersService.LoginUser(model.Username, model.Password);
        }

        [HttpPost]
        [ActionName("createAccount")]
        public OperationStatus PostCreateAccount(User model)
        {
            return _usersService.CreateUser(model.Username, model.Password);
        }
    }
}