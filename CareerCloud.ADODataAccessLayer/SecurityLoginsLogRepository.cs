using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsLogRepository : BaseRepositoryImpl<SecurityLoginsLogPoco>
    {
        public SecurityLoginsLogRepository() : 
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into security_logins_log(id, login, source_ip, logon_date, is_succesful) values(@id, @login, @source_ip, @logon_date, @is_succesful)",
                "update security_logins_log set login = @login, source_ip = @source_ip, logon_date = @logon_date, is_succesful = @is_succesful where id = @id",
                "delete from security_logins_log where id = @id",
                "select id, login, source_ip, logon_date, is_succesful from security_logins_log",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<SecurityLoginsLogPoco>
        {
            public void SetValues(DbCommand cmd, SecurityLoginsLogPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                cmd.Parameters.Add(new SqlParameter("@source_ip", item.SourceIP));
                cmd.Parameters.Add(new SqlParameter("@logon_date", item.LogonDate));
                cmd.Parameters.Add(new SqlParameter("@is_succesful", item.IsSuccesful));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<SecurityLoginsLogPoco>
        {
            public void SetValues(DbCommand cmd, SecurityLoginsLogPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<SecurityLoginsLogPoco>
        {
            public SecurityLoginsLogPoco MapRow(DbDataReader reader)
            {
                return new SecurityLoginsLogPoco()
                {
                    Id = reader.GetGuid(0),
                    Login = reader.GetGuid(1),
                    SourceIP = reader.GetString(2),
                    LogonDate = reader.GetDateTime(3),
                    IsSuccesful = reader.GetBoolean(4)
                };
            }
        }
    }
}
