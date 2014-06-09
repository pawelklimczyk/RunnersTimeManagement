// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="LoginService.cs" project="RunnersTimeManagement.ClientServices" date="2014-06-04 08:42">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices
{
    using System;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using RestSharp;

    using RunnersTimeManagement.Core.Domain;

    public class LoginService : BaseService
    {
        private const string _userJsonFile = "user.json";

        private readonly IFileService _fileService;

        public LoginService(IFileService fileService, string baseUrl)
            : base(baseUrl)
        {
            _fileService = fileService;
        }


        public Task<OperationStatus> LoginUser(string username, string password)
        {
            var tcs = new TaskCompletionSource<OperationStatus>();

            var client = new RestClient(BaseUrl);
            var request = new RestRequest("api/users/login", Method.POST);
            request.RequestFormat = DataFormat.Json;
            
            request.AddBody(new User() { Username = username, Password = password });
            //request.AddHeader("header", "value");

            client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<OperationStatus>(response.Content);

                    //TODO check status and if true-> read token and save locally
                    
                    tcs.SetResult(data);
                }
                else
                {
                    tcs.SetResult(OperationStatus.Failed("Error login in!"));
                }
            });

            return tcs.Task;
        }

        public bool TryRunWithCachedCredentials()
        {
            User cachedUser = this.GetUserFromCache();

            return cachedUser != null && !string.IsNullOrEmpty(cachedUser.Password) && !string.IsNullOrEmpty(cachedUser.Username) && !string.IsNullOrEmpty(cachedUser.AccessToken);
        }

        private User GetUserFromCache()
        {
            try
            {
                string jsonUser;
                bool status = _fileService.TryReadTextFile(_userJsonFile, out jsonUser);

                return status ? JsonHelpers.ConvertFromJson<User>(jsonUser) : null;
            }
            catch (Exception e)
            {
                LoggingService.LogException(e);
                return null;
            }
        }

        private bool SaveUserToCache(User user)
        {
            try
            {
                string jsonUser = JsonHelpers.ConvertToJson(user);
                bool status = _fileService.TryWriteTextFile(_userJsonFile, jsonUser);

                return status;
            }
            catch (Exception e)
            {
                LoggingService.LogException(e);
                return false;
            }
        }

        public Task<OperationStatus> CreateUser(string username, string password)
        {
            var tcs = new TaskCompletionSource<OperationStatus>();

            var client = new RestClient(BaseUrl);
            var request = new RestRequest("api/users/createAccount", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddBody(new User() { Username = username, Password = password });
            //request.AddHeader("header", "value");

            client.ExecuteAsync(request, response =>
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<OperationStatus>(response.Content);

                    //TODO check status and if true-> read token and save locally

                    tcs.SetResult(data);
                }
                else
                {
                    tcs.SetResult(OperationStatus.Failed("Error login in!"));
                }
            });

            return tcs.Task;
        }
    }
}
