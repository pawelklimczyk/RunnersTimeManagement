// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="BaseService.cs" project="RunnersTimeManagement.ClientServices" date="2014-06-04 08:42">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices
{
    public class BaseService
    {
        public string BaseUrl;

        public BaseService(string baseUrl)
        {
            this.BaseUrl = baseUrl;
        }
    }
}