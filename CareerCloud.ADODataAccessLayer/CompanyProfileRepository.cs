using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyProfileRepository : BaseRepositoryImpl<CompanyProfilePoco>
    {
        public CompanyProfileRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into company_profiles(id, registration_date, company_website, contact_phone, contact_name, company_logo) values(@id, @registration_date, @company_website, @contact_phone, @contact_name, @company_logo)",
                "update company_profiles set registration_date = @registration_date, company_website = @company_website, contact_phone = @contact_phone, contact_name = @contact_name, company_logo = @company_logo where id = @id",
                "delete from company_profiles where id = @id",
                "select id, registration_date, company_website, contact_phone, contact_name, company_logo, time_stamp from company_profiles",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyProfilePoco>
        {
            public void SetValues(DbCommand cmd, CompanyProfilePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@registration_date", item.RegistrationDate));
                cmd.Parameters.Add(new SqlParameter("@company_website", item.CompanyWebsite));
                cmd.Parameters.Add(new SqlParameter("@contact_phone", item.ContactPhone));
                cmd.Parameters.Add(new SqlParameter("@contact_name", item.ContactName));
                cmd.Parameters.Add(new SqlParameter("@company_logo", item.CompanyLogo));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyProfilePoco>
        {
            public void SetValues(DbCommand cmd, CompanyProfilePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<CompanyProfilePoco>
        {
            public CompanyProfilePoco MapRow(DbDataReader reader)
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
            }
        }
    }
}
