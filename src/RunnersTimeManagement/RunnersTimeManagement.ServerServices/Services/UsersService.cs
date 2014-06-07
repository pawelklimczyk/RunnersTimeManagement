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
        public UsersService(IDatabaseProvider provider)
            : base(provider)
        {
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

                IAccessTokenProvider tokenProvider = new AccessTokenProvider();

                existingUser.AccessToken = tokenProvider.GenerateToken();

                db.Update(existingUser);

                return OperationStatus.Passed("User logged in", existingUser.AccessToken);
            }
        }

        public OperationStatus Authorize(string accesToken)
        {
            throw new NotImplementedException();
        }
    }
}