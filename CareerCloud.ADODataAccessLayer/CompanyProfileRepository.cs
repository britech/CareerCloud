using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyProfileRepository : IDataRepository<CompanyProfilePoco>
    {
        private readonly DbHelper _dbHelper;

        public CompanyProfileRepository()
        {
            _dbHelper = new DbHelper(CareerCloudConfigurationLoader.Instance.GetConnectionString());
        }

        public void Add(params CompanyProfilePoco[] items)
        {
            _dbHelper.Update("insert into company_profiles(id, registration_date, company_website, contact_phone, contact_name, company_logo) values(@id, @registration_date, @company_website, @contact_phone, @contact_name, @company_logo)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@registration_date", item.RegistrationDate));
                    cmd.Parameters.Add(new SqlParameter("@company_website", item.CompanyWebsite));
                    cmd.Parameters.Add(new SqlParameter("@contact_phone", item.ContactPhone));
                    cmd.Parameters.Add(new SqlParameter("@contact_name", item.ContactName));
                    cmd.Parameters.Add(new SqlParameter("@company_logo", item.CompanyLogo));
                },
                items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select id, registration_date, company_website, contact_phone, contact_name, company_logo, time_stamp from company_profiles",
                reader =>
                {
                    return new CompanyProfilePoco()
                    {
                        Id = reader.GetGuid(0),
                        RegistrationDate = reader.GetDateTime(1),
                        CompanyWebsite = reader.GetValue(2) as string ?? null,
                        ContactPhone = reader.GetString(3),
                        ContactName = reader.GetValue(4) as string ?? null,
                        CompanyLogo = reader.GetValue(5) as byte[] ?? null,
                        TimeStamp = reader.GetValue(6) as byte[] ?? null
                    };
                });
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as CompanyProfilePoco)!;
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            _dbHelper.Update("delete from company_profiles where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                }, items);
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            _dbHelper.Update("update company_profiles set registration_date = @registration_date, company_website = @company_website, contact_phone = @contact_phone, contact_name = @contact_name, company_logo = @company_logo where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@registration_date", item.RegistrationDate));
                    cmd.Parameters.Add(new SqlParameter("@company_website", item.CompanyWebsite));
                    cmd.Parameters.Add(new SqlParameter("@contact_phone", item.ContactPhone));
                    cmd.Parameters.Add(new SqlParameter("@contact_name", item.ContactName));
                    cmd.Parameters.Add(new SqlParameter("@company_logo", item.CompanyLogo));
                },
                items);
        }
    }
}
