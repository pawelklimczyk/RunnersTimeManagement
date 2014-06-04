// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="RouteConfig.cs" project="RunnersTimeManagement.WebServer" date="2014-06-04 14:12">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WebServer
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}