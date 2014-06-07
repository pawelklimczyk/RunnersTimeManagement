// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TimeService.cs" project="RunnersTimeManagement.ClientServices" date="2014-06-07 23:25">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices
{
    using System.Threading.Tasks;

    using RestSharp;

    using RunnersTimeManagement.Core;
    using RunnersTimeManagement.Core.Domain;

    public class TimeService : BaseService
    {
        public TimeService(string baseUrl) : base(baseUrl) { }

        public async Task<OperationStatus> AddTimeEntry(TimeEntry timeEntry)
        {
            var client = new RestClient("http://api.toodledo.com/2");
            var request = new RestRequest("account/lookup.php", Method.GET);
            client.ExecuteAsync(request, resp =>
            {
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {

                }
            });
            return null;
        }
    }
}
