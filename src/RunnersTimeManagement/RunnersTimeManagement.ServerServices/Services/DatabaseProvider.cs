﻿// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="DatabaseProvider.cs" project="RunnersTimeManagement.ServerServices" date="2014-06-05 19:37">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.ServerServices.Services
{
    using System;
    using System.Data.SQLite;
    using System.IO;
    using System.Reflection;

    public abstract class AbstractDatabaseProvider : IDatabaseProvider
    {
        public virtual string ConnectionString
        {
            get
            {
                throw new NotImplementedException("ConnectionString must be implemented in derived class");
            }
        }

        public virtual bool InitDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceName = "RunnersTimeManagement.ServerServices.Scripts.schema.sql";

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
    }

    public interface IDatabaseProvider
    {
        string ConnectionString { get; }

        bool InitDatabase();
    }
}
