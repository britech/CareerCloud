using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginRepository : BaseRepositoryImpl<SecurityLoginPoco>
    {
        public SecurityLoginRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into security_logins(id, login, password, created_date, password_update_date, agreement_accepted_date, is_locked, is_inactive, email_address, phone_number, full_name, force_change_password, prefferred_language) values(@id, @login, @password, @created_date, @password_update_date, @agreement_accepted_date, @is_locked, @is_inactive, @email_address, @phone_number, @full_name, @force_change_password, @prefferred_language)",
                "update security_logins set login = @login, password = @password, created_date = @created_date, password_update_date = @password_update_date, agreement_accepted_date = @agreement_accepted_date, is_locked = @is_locked, is_inactive = @is_inactive, email_address = @email_address, phone_number = @phone_number, full_name = @full_name, force_change_password = @force_change_password, prefferred_language = @prefferred_language where id = @id",
                "delete from security_logins where id = @id",
                "select id, login, password, created_date, password_update_date, agreement_accepted_date, is_locked, is_inactive, email_address, phone_number, full_name, force_change_password, prefferred_language, time_stamp from security_logins",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<SecurityLoginPoco>
        {
            public void SetValues(DbCommand cmd, SecurityLoginPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@login", item.Login));
                cmd.Parameters.Add(new SqlParameter("@password", item.Password));
                cmd.Parameters.Add(new SqlParameter("@created_date", item.Created));
                cmd.Parameters.Add(new SqlParameter("@password_update_date", item.PasswordUpdate));
                cmd.Parameters.Add(new SqlParameter("@agreement_accepted_date", item.AgreementAccepted));
                cmd.Parameters.Add(new SqlParameter("@is_locked", item.IsLocked));
                cmd.Parameters.Add(new SqlParameter("@is_inactive", item.IsInactive));
                cmd.Parameters.Add(new SqlParameter("@email_address", item.EmailAddress));
                cmd.Parameters.Add(new SqlParameter("@phone_number", item.PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@full_name", item.FullName));
                cmd.Parameters.Add(new SqlParameter("@force_change_password", item.ForceChangePassword));
                cmd.Parameters.Add(new SqlParameter("@prefferred_language", item.PrefferredLanguage));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<SecurityLoginPoco>
        {
            public void SetValues(DbCommand cmd, SecurityLoginPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<SecurityLoginPoco>
        {
            public SecurityLoginPoco MapRow(DbDataReader reader)
            {
                return new SecurityLoginPoco()
                {
                    Id = reader.GetGuid(0),
                    Login = reader.GetString(1),
                    Password = reader.GetString(2),
                    Created = reader.GetDateTime(3),
                    PasswordUpdate = reader.GetValue(4) as DateTime?,
                    AgreementAccepted = reader.GetValue(5) as DateTime?,
                    IsLocked = reader.GetBoolean(6),
                    IsInactive = reader.GetBoolean(7),
                    EmailAddress = reader.GetString(8),
                    PhoneNumber = reader.GetValue(9) as string ?? null,
                    FullName = reader.GetValue(10) as string ?? null,
                    ForceChangePassword = reader.GetBoolean(11),
                    PrefferredLanguage = reader.GetValue(12) as string ?? null!,
                    TimeStamp = reader.GetValue(13) as byte[] ?? []
                };
            }
        }
    }
}
