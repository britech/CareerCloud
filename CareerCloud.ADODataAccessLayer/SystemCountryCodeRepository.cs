using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Linq.Expressions;
using System.Transactions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    foreach (var item in items)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "insert into system_country_codes(code, name) values(@code, @name)";
                            cmd.Parameters.Add(new SqlParameter()
                            {
                                ParameterName = "@code",
                                Value = item.Code
                            });
                            cmd.Parameters.Add(new SqlParameter()
                            {
                                ParameterName = "@name",
                                Value = item.Name
                            });
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IList<SystemCountryCodePoco> items = new List<SystemCountryCodePoco>();

            using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select code, name from system_country_codes";

                    connection.Open();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new SystemCountryCodePoco();
                            item.Code = reader.GetString(0);
                            item.Name = reader.GetString(1);
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as SystemCountryCodePoco)!;
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    foreach (var item in items)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "delete from system_country_codes where code = @code";
                            cmd.Parameters.Add(new SqlParameter()
                            {
                                ParameterName = "@code",
                                Value = item.Code
                            });
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    foreach (var item in items)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "update system_country_codes set name = @name where code = @code";
                            cmd.Parameters.Add(new SqlParameter()
                            {
                                ParameterName = "@name",
                                Value = item.Name
                            });
                            cmd.Parameters.Add(new SqlParameter()
                            {
                                ParameterName = "@code",
                                Value = item.Code
                            });
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }
    }
}
