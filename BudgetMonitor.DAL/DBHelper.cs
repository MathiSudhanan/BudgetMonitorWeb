using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;

namespace BudgetMonitor.DAL
{
    public static class DBHelper
    {
        private static string ConnectionString;
        static DBHelper()
        {
            ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=password-1;Database=BudMonitor;";

        }


        public static void Init(string connectionString)
        {

        }

        public static List<T> GetList<T>(string commandString, NpgsqlParameterCollection npgsqlParameters, Action<NpgsqlDataReader, T> action)
        {
            var resultList = new List<T>();
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                using (var cmd = new NpgsqlCommand(commandString, connection))
                {
                    foreach (var parameter in npgsqlParameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = Activator.CreateInstance<T>();
                            action(reader, item);
                        }
                    }
                }
            }
            return resultList;
        }

        public static void Insert(string commandString, List<NpgsqlParameter> npgsqlParameters)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                using (var cmd = new NpgsqlCommand(commandString, connection))
                {
                    foreach (var parameter in npgsqlParameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
