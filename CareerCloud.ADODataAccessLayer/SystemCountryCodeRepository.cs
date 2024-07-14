using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemCountryCodeRepository : BaseRepository<SystemCountryCodePoco>
    {
        public override void Add(params SystemCountryCodePoco[] items)
        {
           using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
           {
                connection.Open();
                using (SqlTransaction txn = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand("insert into system_country_code(code, name) values(@code, @name)", connection, txn))
                    {
                        cmd.Parameters.Add("@code");
                        cmd.Parameters.Add("@name");
                        try
                        {
                            foreach (var item in items)
                            {
                                cmd.Parameters["@code"].Value = item.Code;
                                cmd.Parameters["@name"].Value = item.Name;
                                cmd.ExecuteNonQuery();
                            }
                            txn.Commit();
                        }
                        catch (Exception) 
                        {
                            txn.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        public override void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IList<SystemCountryCodePoco> items = new List<SystemCountryCodePoco>();
            
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = new SqlCommand("select code, name from system_country_code", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
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

        public override IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public override SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(new SystemCountryCodePoco());
        }

        public override void Remove(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlTransaction txn = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand("delete from system_country_code where code = @code", connection, txn))
                    {
                        cmd.Parameters.Add("@code");
                        try
                        {
                            foreach (var item in items)
                            {
                                cmd.Parameters["@code"].Value = item.Code;
                                cmd.ExecuteNonQuery();
                            }
                            txn.Commit();
                        }
                        catch (Exception) 
                        { 
                            txn.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        public override void Update(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlTransaction txn = connection.BeginTransaction())
                {
                    using (SqlCommand cmd = new SqlCommand("update system_country_code set name = @name where code = @code", connection, txn))
                    {
                        cmd.Parameters.Add("@name");
                        cmd.Parameters.Add("@code");
                        try
                        {
                            foreach (var item in items)
                            {
                                cmd.Parameters["@name"].Value = item.Name;
                                cmd.Parameters["@code"].Value = item.Code;
                                cmd.ExecuteNonQuery();
                            }
                            txn.Commit();
                        }
                        catch (Exception)
                        {
                            txn.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }
}
