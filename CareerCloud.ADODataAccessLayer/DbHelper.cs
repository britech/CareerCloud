using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Transactions;

namespace CareerCloud.ADODataAccessLayer
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Update<T>(string query, IDbCommandParameterSetter<T> setter, T[] items) where T : class
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    foreach (var item in items)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = query;
                            setter.SetValues(cmd, item);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }

        public IList<T> Query<T>(string query, IDbRowMapper<T> mapper) where T : class
        {
            IList<T> items = new List<T>();
            using(DbConnection connection = new SqlConnection(_connectionString))
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = query;
                    connection.Open();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
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
