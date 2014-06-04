// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="HomeController.cs" project="RunnersTimeManagement.WebServer" date="2014-06-04 14:12">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WebServer.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}