// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="TestsDatabaseProvider.cs" project="RunnersTimeManagement.ServerServices.UnitTests" date="2014-06-05 19:48">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.UnitTests
{
    using System;
    using System.Data.SQLite;
    using System.IO;
    using System.Reflection;

    using RunnersTimeManagement.ServerServices.Services;

    public class TestsDatabaseProvider : AbstractDatabaseProvider
    {
        public override string ConnectionString
        {
            get
            {
                return "Data Source=testDb.db";
            }
        }

        public override bool InitDatabase()
        {
            bool status = base.InitDatabase();

            if (status)
            {
                try
                {
                    using (var connection = new SQLiteConnection(ConnectionString))
                    {
                        connection.Open();

                        var assembly = Assembly.GetExecutingAssembly();
                        var resourceName = "RunnersTimeManagement.ServerServices.UnitTests.test_data.sql";

                        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                        {
                            using (StreamReader sr = new StreamReader(stream))
                            {
                                String sql = sr.ReadToEnd();

                                SQLiteCommand command = new SQLiteCommand(sql, connection);
                                command.ExecuteNonQuery();
                            }
                        }

                        connection.Clone();
                    }

                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return status;
        }

        public static IDatabaseProvider ReturnInitializedDatabase()
        {
            var databaseProvider = new TestsDatabaseProvider();
            databaseProvider.InitDatabase();
            return databaseProvider;
        }
    }
}
