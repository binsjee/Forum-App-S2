using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Forum_App.Contexts
{
    public abstract class SQLBaseContext
    {
        private readonly string _ConnectionString;
        public SQLBaseContext(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public DataSet ExecuteSql(string sql, List<KeyValuePair<string, string>> parameters)
        {
            DataSet data = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection(_ConnectionString);
                SqlDataAdapter Adapter = new SqlDataAdapter();
                SqlCommand command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                Adapter.SelectCommand = command;

                connection.Open();
                Adapter.Fill(data);
                connection.Close();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int ExecuteInsert(string sql, List<KeyValuePair<string, string>> parameters)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_ConnectionString);
                SqlCommand command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private SqlParameter[] GetParameters(List<KeyValuePair<string, string>> parameters)
        {
            SqlParameter[] retVal = new SqlParameter[parameters.Count];
            foreach (KeyValuePair<string, string> kvp in parameters)
            {
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@" + kvp.Key,
                    Value = kvp.Value
                };
                retVal[parameters.IndexOf(kvp)] = param;
            }
            return retVal;
        }

    }
}
