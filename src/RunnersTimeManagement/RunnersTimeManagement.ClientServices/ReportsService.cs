// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ReportsService.cs" project="RunnersTimeManagement.ClientServices" date="2014-06-10 09:43">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using RestSharp;

    using RunnersTimeManagement.Core.Domain;

    public class ReportsService : BaseService
    {
        public ReportsService(string baseUrl) : base(baseUrl) { }

        public Task<OperationStatus> GetWeeklyReports()
        {
            var tcs = new TaskCompletionSource<OperationStatus>();

            var client = new RestClient(BaseUrl);
            var request = new RestRequest("api/reports/weeklyReport", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("auth-token", AppConfiguration.Token);

            client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<OperationStatus>(response.Content);
                    if (data != null && (bool)data)
                    {
                        var list = JsonConvert.DeserializeObject<List<WeeklyReport>>(data.Data.ToString());

                        data.Data = list;
                    }
                    tcs.SetResult(data);
                }
                else
                {
                    tcs.SetResult(OperationStatus.Failed("Error fetching reports!"));
                }
            });

            return tcs.Task;
        }
    }
}
