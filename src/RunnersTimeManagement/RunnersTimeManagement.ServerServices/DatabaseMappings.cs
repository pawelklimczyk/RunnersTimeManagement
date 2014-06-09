// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="DatabaseMappings.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-06 08:51">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices
{
    using NPoco;
    using NPoco.FluentMappings;

    using RunnersTimeManagement.Core.Domain;

    public class DatabaseMappings
    {
        private readonly string connectionString;

        public DatabaseMappings(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static DatabaseFactory DbFactory { get; private set; }

        public void Setup()
        {
            var config = FluentMappingConfiguration.Configure(new ServerDomainDBMapping());

            DbFactory = DatabaseFactory.Config(x =>
                {
                    x.UsingDatabase(() => new Database(this.connectionString, DatabaseType.SQLite));
                    x.WithFluentConfig(config);
                });
        }
    }

    public class ServerDomainDBMapping : Mappings
    {
        public ServerDomainDBMapping()
        {
            this.For<User>().Columns(x =>
                {
                    x.Column(y => y.Username).WithName("username");
                    x.Column(y => y.Id).WithName("id");
                    x.Column(y => y.Password).WithName("password");
                    x.Column(y => y.AccessToken).WithName("accesstoken");
                }); 
            
            this.For<TimeEntry>().Columns(x =>
                {
                    x.Column(y => y.UserId).WithName("userId");
                    x.Column(y => y.Id).WithName("id");
                    x.Column(y => y.EntryDate).WithName("entryDate");
                    x.Column(y => y.Distance).WithName("distance");
                    x.Column(y => y.TimeElapsed).WithName("timeElapsed");
                    x.Column(y => y.AverageSpeed).Ignore();
                });
        }
    }
}