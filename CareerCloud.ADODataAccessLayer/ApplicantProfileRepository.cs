using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.Common;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>, IDataRowMapper<ApplicantProfilePoco>
    {
        public void Add(params ApplicantProfilePoco[] items)
        {
            DbHelper.Write("insert into applicant_profiles(id, login, current_salary, current_rate, currency, country_code, state_province_code, street_address, city_town, zip_postal_code) values(@id, @login, @current_salary, @current_rate, @currency, @country_code, @state_province_code, @street_address, @city_town, @zip_postal_code)", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id },
                    { "@login", item.Login },
                    { "@current_salary", item.CurrentSalary },
                    { "@current_rate", item.CurrentRate },
                    { "@currency", item.Currency },
                    { "@country_code", item.Country },
                    { "@state_province_code", item.Province },
                    { "@street_address", item.Street },
                    { "@city_town", item.City },
                    { "@zip_postal_code", item.PostalCode }
                };
                return queryParams;
            }).ToList());
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            return DbHelper.Load("select id, login, current_salary, current_rate, currency, country_code, state_province_code, street_address, city_town, zip_postal_code, time_stamp from applicant_profiles", this);
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantProfilePoco)!;
        }

        public ApplicantProfilePoco MapRow(DbDataReader reader)
        {
            return new ApplicantProfilePoco()
            {
                Id = reader.GetGuid(0),
                Login = reader.GetGuid(1),
                CurrentSalary = reader.GetDecimal(2),
                CurrentRate = reader.GetDecimal(3),
                Currency = reader.GetString(4),
                Country = reader.GetString(5),
                Province = reader.GetString(6),
                Street = reader.GetString(7),
                City = reader.GetString(8),
                PostalCode = reader.GetString(9),
                TimeStamp = reader.GetValue(10) as byte[] ?? []
            };
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            DbHelper.Write("delete from applicant_profiles where id = @id", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id }
                };
                return queryParams;
            }).ToList());
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            DbHelper.Write("update applicant_profiles set login = @login, current_salary = @current_salary, current_rate = @current_rate, currency = @currency, country_code = @country_code, state_province_code = @state_province_code, street_address = @street_address, city_town = @city_town, zip_postal_code = @zip_postal_code where id = @id", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id },
                    { "@login", item.Login },
                    { "@current_salary", item.CurrentSalary },
                    { "@current_rate", item.CurrentRate },
                    { "@currency", item.Currency },
                    { "@country_code", item.Country },
                    { "@state_province_code", item.Province },
                    { "@street_address", item.Street },
                    { "@city_town", item.City },
                    { "@zip_postal_code", item.PostalCode }
                };
                return queryParams;
            }).ToList());
        }
    }
}
