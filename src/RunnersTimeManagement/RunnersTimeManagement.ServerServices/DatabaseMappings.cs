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
                    x.Column(y => y.UserName).WithName("username");
                    x.Column(y => y.Id).WithName("id");
                });
        }
    }
}