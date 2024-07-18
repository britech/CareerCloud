using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyLocationRepository : BaseRepositoryImpl<CompanyLocationPoco>
    {
        public CompanyLocationRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into company_locations(id, company, country_code, state_province_code, street_address, city_town, zip_postal_code) values(@id, @company, @country_code, @state_province_code, @street_address, @city_town, @zip_postal_code)",
                "update company_locations set company = @company, country_code = @country_code, state_province_code = @state_province_code, street_address = @street_address, city_town = @city_town, zip_postal_code = @zip_postal_code where id = @id",
                "delete from company_locations where id = @id",
                "select id, company, country_code, state_province_code, street_address, city_town, zip_postal_code, time_stamp from company_locations",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyLocationPoco>
        {
            public void SetValues(DbCommand cmd, CompanyLocationPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@country_code", item.CountryCode));
                cmd.Parameters.Add(new SqlParameter("@state_province_code", item.Province));
                cmd.Parameters.Add(new SqlParameter("@street_address", item.Street));
                cmd.Parameters.Add(new SqlParameter("@city_town", item.City));
                cmd.Parameters.Add(new SqlParameter("@zip_postal_code", item.PostalCode));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyLocationPoco>
        {
            public void SetValues(DbCommand cmd, CompanyLocationPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<CompanyLocationPoco>
        {
            public CompanyLocationPoco MapRow(DbDataReader reader)
            {
                return new CompanyLocationPoco()
                {
                    Id = reader.GetGuid(0),
                    Company = reader.GetGuid(1),
                    CountryCode = reader.GetString(2),
                    Province = reader.GetValue(3) as string ?? null,
                    Street = reader.GetValue(4) as string ?? null,
                    City = reader.GetValue(5) as string ?? null,
                    PostalCode = reader.GetValue(6) as string ?? null,
                    TimeStamp = reader.GetValue(7) as byte[] ?? []
                };
            }
        }
    }
}
