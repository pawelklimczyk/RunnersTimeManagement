// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TimeService.cs" project="RunnersTimeManagement.ClientServices" date="2014-06-07 23:25">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using RestSharp;

    using RunnersTimeManagement.Core;
    using RunnersTimeManagement.Core.Domain;

    public class TimeService : BaseService
    {
        public TimeService(string baseUrl) : base(baseUrl) { }

        public Task<OperationStatus> AddTimeEntry(TimeEntry timeEntry)
        {
            var tcs = new TaskCompletionSource<OperationStatus>();

            var client = new RestClient(BaseUrl);
            var request = new RestRequest("api/time/add", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("auth-token", AppConfiguration.Token);
            request.AddBody(timeEntry);
           
            client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<OperationStatus>(response.Content);

                    tcs.SetResult(data);
                }
                else
                {
                    tcs.SetResult(OperationStatus.Failed("Error adding record!"));
                }
            });

            return tcs.Task;

        }

        public Task<OperationStatus> GetTimeEntryList()
        {
            var tcs = new TaskCompletionSource<OperationStatus>();

            var client = new RestClient(BaseUrl);
            var request = new RestRequest("api/time/list", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("auth-token", AppConfiguration.Token);

            client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<OperationStatus>(response.Content);

                    if (data != null && (bool)data)
                    {
                        var list = JsonConvert.DeserializeObject<List<TimeEntry>>(data.Data.ToString());

                        data.Data = list;
                    }

                    tcs.SetResult(data);
                }
                else
                {
                    tcs.SetResult(OperationStatus.Failed("Error getting list"));
                }
            });

            return tcs.Task;

        }
    }
}
