using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityRoleRepository : BaseRepositoryImpl<SecurityRolePoco>
    {
        public SecurityRoleRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into security_roles(id, role, is_inactive) values(@id, @role, @is_inactive)",
                "update security_roles set role = @role, is_inactive = @is_inactive where id = @id",
                "delete from security_roles where id = @id",
                "select id, role, is_inactive from security_roles",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<SecurityRolePoco>
        {
            public void SetValues(DbCommand cmd, SecurityRolePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@role", item.Role));
                cmd.Parameters.Add(new SqlParameter("@is_inactive", item.IsInactive));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<SecurityRolePoco>
        {
            public void SetValues(DbCommand cmd, SecurityRolePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<SecurityRolePoco>
        {
            public SecurityRolePoco MapRow(DbDataReader reader)
            {
                return new SecurityRolePoco()
                {
                    Id = reader.GetGuid(0),
                    Role = reader.GetString(1),
                    IsInactive = reader.GetBoolean(2)
                };
            }
        }
    }
}
