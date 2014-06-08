// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="UsersService.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-04 16:32">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.Services
{
    using System;

    using NPoco;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.ServerServices.AccessTokenProvider;

    public class UsersService : AbstractDatabaseService
    {
        private readonly IAccessTokenProvider tokenProvider;

        public UsersService(IDatabaseProvider provider, IAccessTokenProvider tokenProvider = null)
            : base(provider)
        {
            if (tokenProvider == null) tokenProvider = new AccessTokenProvider();

            this.tokenProvider = tokenProvider;
        }

        public OperationStatus CreateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return OperationStatus.Failed("Please provide username");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return OperationStatus.Failed("Please provide password");
            }

            using (IDatabase db = this.CurrentDatabase)
            {
                var existingUser = db.SingleOrDefault<User>("where username=@0", username);
                if (existingUser != null)
                {
                    return OperationStatus.Failed("User already exists");
                }

                User newUser = new User() { Username = username, Password = password };

                db.Insert(newUser);
                return OperationStatus.Passed("User was created sucessfully");
            }
        }

        public OperationStatus LoginUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return OperationStatus.Failed("Provide valid username and password");
            }

            using (IDatabase db = this.CurrentDatabase)
            {
                var existingUser = db.SingleOrDefault<User>("where username=@0 and password=@1", username, password);

                if (existingUser == null)
                {
                    return OperationStatus.Failed("Provide valid username and password");
                }

                existingUser.AccessToken = tokenProvider.GenerateToken(username, password);

                db.Update(existingUser);

                return OperationStatus.Passed("User logged in", existingUser.AccessToken);
            }
        }

        public OperationStatus Authorize(string accessToken)
        {
            using (IDatabase db = this.CurrentDatabase)
            {
                var existingUser = db.SingleOrDefault<User>("where accessToken=@0", accessToken);

                if (existingUser == null)
                {
                    return OperationStatus.Failed("Token is invalid", false);
                }

                return OperationStatus.Passed("Token is valid", true);
            }
        }
    }
}