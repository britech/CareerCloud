using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantProfileRepository : BaseRepositoryImpl<ApplicantProfilePoco>
    {
        public ApplicantProfileRepository():
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into applicant_profiles(id, login, current_salary, current_rate, currency, country_code, state_province_code, street_address, city_town, zip_postal_code) values(@id, @login, @current_salary, @current_rate, @currency, @country_code, @state_province_code, @street_address, @city_town, @zip_postal_code)",
                "update applicant_profiles set login = @login, current_salary = @current_salary, current_rate = @current_rate, currency = @currency, country_code = @country_code, state_province_code = @state_province_code, street_address = @street_address, city_town = @city_town, zip_postal_code = @zip_postal_code where id = @id",
                "delete from applicant_profiles where id = @id",
                "select id, login, current_salary, current_rate, currency, country_code, state_province_code, street_address, city_town, zip_postal_code, time_stamp from applicant_profiles",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantProfilePoco>
        {
            public void SetValues(DbCommand cmd, ApplicantProfilePoco item)
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
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<ApplicantProfilePoco>
        {
            public void SetValues(DbCommand cmd, ApplicantProfilePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<ApplicantProfilePoco>
        {
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
        }
    }
}
