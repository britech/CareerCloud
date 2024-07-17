using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Transactions;

namespace CareerCloud.ADODataAccessLayer
{
    public static class DbHelper
    {
        public static void Write(string query, IList<IDictionary<string, object?>> queryParams)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    foreach(var item in queryParams)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = query;
                            foreach (KeyValuePair<string,object?> queryParam in item) {
                                cmd.Parameters.Add(new SqlParameter(parameterName: queryParam.Key, value: queryParam.Value));
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }

        public static IList<T> Load<T>(string query, IDataRowMapper<T> mapper) where T : class
        {
            IList<T> items = new List<T>();
            using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = query;
                    connection.Open();

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            items.Add(mapper.MapRow(reader));
                        }
                    }
                }
            }
            return items;
        }
    }
}
