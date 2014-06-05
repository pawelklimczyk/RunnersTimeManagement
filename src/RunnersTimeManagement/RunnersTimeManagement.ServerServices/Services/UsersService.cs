// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="UsersService.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-04 16:32">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.Services
{
    using NPoco;

    using RunnersTimeManagement.Core.Domain;

    public class UsersService : DatabaseService
    {
        public UsersService(IDatabaseProvider provider)
            : base(provider)
        {
        }

        public OperationStatus CreateUser(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return OperationStatus.Failed("Please provide username");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return OperationStatus.Failed("Please provide password");
            }

            using (IDatabase db = CurrentDatabase)
            {
                var existingUser = db.SingleOrDefault<User>("where username=@0", userName);
                if (existingUser != null)
                {
                    return OperationStatus.Failed("User already exists");
                }
            }

            return OperationStatus.Passed("User was created sucessfully");
        }
    }

    public class DatabaseService
    {
        protected IDatabaseProvider _databaseProvider;

        protected IDatabase CurrentDatabase
        {
            get
            {
                return new Database(_databaseProvider.ConnectionString, DatabaseType.SQLite);
            }
        }

        protected DatabaseService(IDatabaseProvider provider)
        {
            _databaseProvider = provider;
        }

        public void InitDatabase()
        {
            _databaseProvider.InitDatabase();
        }
    }
}
