using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>
    {
        private readonly DbHelper _dbHelper;

        public ApplicantProfileRepository()
        {
            _dbHelper = new DbHelper(ApplicationConstants.CONNECTION_STRING);
        }

        public void Add(params ApplicantProfilePoco[] items)
        {
            _dbHelper.Update("insert into applicant_profiles(id, login, current_salary, current_rate, currency, country_code, state_province_code, street_address, city_town, zip_postal_code) values(@id, @login, @current_salary, @current_rate, @currency, @country_code, @state_province_code, @street_address, @city_town, @zip_postal_code)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                    cmd.Parameters.Add(new SqlParameter("@current_salary", item.CurrentSalary));
                    cmd.Parameters.Add(new SqlParameter("@current_rate", item.CurrentRate));
                    cmd.Parameters.Add(new SqlParameter("@currency", item.Currency));
                    cmd.Parameters.Add(new SqlParameter("@country_code", item.Country));
                    cmd.Parameters.Add(new SqlParameter("@state_province_code", item.Province));
                    cmd.Parameters.Add(new SqlParameter("@street_address", item.Street));
                    cmd.Parameters.Add(new SqlParameter("@city_town", item.City));
                    cmd.Parameters.Add(new SqlParameter("@zip_postal_code", item.PostalCode));
                }, items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select id, login, current_salary, current_rate, currency, country_code, state_province_code, street_address, city_town, zip_postal_code, time_stamp from applicant_profiles",
                (reader) =>
                {
                    return new ApplicantProfilePoco()
                    {
                        Id = reader.GetGuid(0),
                        Login = reader.GetGuid(1),
                        CurrentSalary = reader.GetValue(2) as Decimal?,
                        CurrentRate = reader.GetValue(3) as Decimal?,
                        Currency = reader.GetValue(4) as string ?? null,
                        Country = reader.GetValue(5) as string ?? null,
                        Province = reader.GetValue(6) as string ?? null,
                        Street = reader.GetValue(7) as string ?? null,
                        City = reader.GetValue(8) as string ?? null,
                        PostalCode = reader.GetValue(9) as string ?? null,
                        TimeStamp = reader.GetValue(10) as byte[] ?? []
                    };
                });
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantProfilePoco)!;
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            _dbHelper.Update("delete from applicant_profiles where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                }, items);
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            _dbHelper.Update("update applicant_profiles set login = @login, current_salary = @current_salary, current_rate = @current_rate, currency = @currency, country_code = @country_code, state_province_code = @state_province_code, street_address = @street_address, city_town = @city_town, zip_postal_code = @zip_postal_code where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                    cmd.Parameters.Add(new SqlParameter("@current_salary", item.CurrentSalary));
                    cmd.Parameters.Add(new SqlParameter("@current_rate", item.CurrentRate));
                    cmd.Parameters.Add(new SqlParameter("@currency", item.Currency));
                    cmd.Parameters.Add(new SqlParameter("@country_code", item.Country));
                    cmd.Parameters.Add(new SqlParameter("@state_province_code", item.Province));
                    cmd.Parameters.Add(new SqlParameter("@street_address", item.Street));
                    cmd.Parameters.Add(new SqlParameter("@city_town", item.City));
                    cmd.Parameters.Add(new SqlParameter("@zip_postal_code", item.PostalCode));
                }, items);
        }
    }
}
