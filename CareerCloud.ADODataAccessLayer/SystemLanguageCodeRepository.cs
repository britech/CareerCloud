using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemLanguageCodeRepository : IDataRepository<SystemLanguageCodePoco>
    {
        private readonly DbHelper _dbHelper;

        public SystemLanguageCodeRepository()
        {
            _dbHelper = new DbHelper(CareerCloudConfigurationLoader.Instance.GetConnectionString());
        }

        public void Add(params SystemLanguageCodePoco[] items)
        {
            _dbHelper.Update("insert into system_language_codes(languageid, name, native_name) values(@languageid, @name, @native_name)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@languageid", item.LanguageID));
                    cmd.Parameters.Add(new SqlParameter("@name", item.Name));
                    cmd.Parameters.Add(new SqlParameter("@native_name", item.NativeName));
                }, items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select languageid, name, native_name from system_language_codes",
                reader =>
                {
                    return new SystemLanguageCodePoco()
                    {
                        LanguageID = reader.GetString(0),
                        Name = reader.GetString(1),
                        NativeName = reader.GetString(2)
                    };
                });
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as SystemLanguageCodePoco)!;
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            _dbHelper.Update("delete from system_language_codes where languageid = @languageid",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@languageid", item.LanguageID));
                }, items);
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            _dbHelper.Update("update system_language_codes set name = @name, native_name = @native_name where languageid = @languageid",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@languageid", item.LanguageID));
                    cmd.Parameters.Add(new SqlParameter("@name", item.Name));
                    cmd.Parameters.Add(new SqlParameter("@native_name", item.NativeName));
                }, items);
        }
    }
}
