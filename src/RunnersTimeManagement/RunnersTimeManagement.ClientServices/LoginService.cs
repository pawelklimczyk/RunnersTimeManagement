// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="LoginService.cs" project="RunnersTimeManagement.ClientServices" date="2014-06-04 08:42">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ClientServices
{
    using System;

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

        public bool LoginUser(string username, string password)
        {
            //TODO
            //connect to server via REST
            //read token and save locally
            return true;
        }

        public bool TryRunWithCachecCredentials()
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
    }
}
