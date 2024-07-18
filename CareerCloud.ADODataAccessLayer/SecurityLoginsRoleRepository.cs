using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsRoleRepository : BaseRepositoryImpl<SecurityLoginsRolePoco>
    {
        public SecurityLoginsRoleRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into security_logins_roles(id, login, role) values(@id, @login, @role)",
                "update security_logins_roles set login = @login, role = @role where id = @id",
                "delete from security_logins_roles where id = @id",
                "select id, login, role, time_stamp from security_logins_roles",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<SecurityLoginsRolePoco>
        {
            public void SetValues(DbCommand cmd, SecurityLoginsRolePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                cmd.Parameters.Add(new SqlParameter("@role", item.Role));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<SecurityLoginsRolePoco>
        {
            public void SetValues(DbCommand cmd, SecurityLoginsRolePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<SecurityLoginsRolePoco>
        {
            public SecurityLoginsRolePoco MapRow(DbDataReader reader)
            {
                return new SecurityLoginsRolePoco()
                {
                    Id = reader.GetGuid(0),
                    Login = reader.GetGuid(1),
                    Role = reader.GetGuid(2),
                    TimeStamp = reader.GetValue(3) as byte[] ?? null
                };
            }
        }
    }
}
