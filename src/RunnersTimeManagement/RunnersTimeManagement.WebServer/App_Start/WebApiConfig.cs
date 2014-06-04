// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="WebApiConfig.cs" project="RunnersTimeManagement.WebServer" date="2014-06-04 14:12">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WebServer
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("ActionApi",
              "api/{controller}/{action}",
              null,
              new { action = @"[a-zA-Z]+" });

            config.Routes.MapHttpRoute("DefaultApi",
              "api/{controller}/{id}",
              new { id = RouteParameter.Optional });
            
            
            
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            //remove all formatters except json
            var jqueryFormatter = config.Formatters.FirstOrDefault(x => x.GetType() == typeof(JQueryMvcFormUrlEncodedFormatter));
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Remove(config.Formatters.FormUrlEncodedFormatter);
            config.Formatters.Remove(jqueryFormatter);
        }
    }
}