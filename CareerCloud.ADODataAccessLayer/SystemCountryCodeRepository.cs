using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.Common;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
    {
        public void Add(params SystemCountryCodePoco[] items)
        {
            DbHelper.WriteToDB("insert into system_country_codes(code, name) values(@code, @name)", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>
                {
                    { "@code", item.Code },
                    { "@name", item.Name}
                };
                return queryParams;
            }).ToList());
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            return DbHelper.LoadFromDB<SystemCountryCodePoco>("select code, name from system_country_codes", new DbMapperImpl()); ;
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
            DbHelper.WriteToDB("delete from system_country_codes where code = @code", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>
                {
                    { "@code", item.Code }
                };
                return queryParams;
            }).ToList());
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            DbHelper.WriteToDB("update system_country_codes set name = @name where code = @code", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>
                {
                    { "@code", item.Code },
                    { "@name", item.Name }
                };
                return queryParams;
            }).ToList());
        }

        private class DbMapperImpl : IDbRowMapper<SystemCountryCodePoco>
        {
            public SystemCountryCodePoco MapRow(DbDataReader reader)
            {
                var item = new SystemCountryCodePoco();
                item.Code = reader.GetString(0);
                item.Name = reader.GetString(1);
                return item;
            }
        }
    }
}
