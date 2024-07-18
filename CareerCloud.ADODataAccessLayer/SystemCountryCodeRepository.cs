using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemCountryCodeRepository : BaseRepositoryImpl<SystemCountryCodePoco>
    {
        public SystemCountryCodeRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into system_country_codes(code, name) values(@code, @name)",
                "update system_country_codes set name = @name where code = @code",
                "delete from system_country_codes where code = @code",
                "select code, name from system_country_codes",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        public class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<SystemCountryCodePoco>
        {
            public void SetValues(DbCommand cmd, SystemCountryCodePoco item)
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@code", value: item.Code));
                cmd.Parameters.Add(new SqlParameter(parameterName: "@name", value: item.Name));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<SystemCountryCodePoco>
        {
            public void SetValues(DbCommand cmd, SystemCountryCodePoco item)
            {
                cmd.Parameters.Add(new SqlParameter(parameterName: "@code", value: item.Code));
            }
        }

        private class RowMapperImpl : IDbRowMapper<SystemCountryCodePoco>
        {
            public SystemCountryCodePoco MapRow(DbDataReader reader)
            {
                return new SystemCountryCodePoco()
                {
                    Code = reader.GetString(0),
                    Name = reader.GetString(1)
                };
            }
        }
    }
}
