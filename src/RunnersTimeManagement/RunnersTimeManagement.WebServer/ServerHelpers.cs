  // -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ServerHelpers.cs" project="RunnersTimeManagement.WebServer" date="2014-06-09 11:30">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WebServer
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    public class ServerHelpers
    {
        public static string GetAccessTokenFromRequest(HttpRequestMessage request)
        {
            IEnumerable<string> headerValues = request.Headers.GetValues("auth-token");
            return  headerValues.FirstOrDefault();
        }
    }
}
