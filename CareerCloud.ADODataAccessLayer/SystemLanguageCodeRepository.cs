using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class SystemLanguageCodeRepository : BaseRepositoryImpl<SystemLanguageCodePoco>
    {
        public SystemLanguageCodeRepository() :
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into system_language_codes(languageid, name, native_name) values(@languageid, @name, @native_name)",
                "update system_language_codes set name = @name, native_name = @native_name where languageid = @languageid",
                "delete from system_language_codes where languageid = @languageid",
                "select languageid, name, native_name from system_language_codes",
                new UpdateCmdParameterSetterImpl(),
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {
        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<SystemLanguageCodePoco>
        {
            public void SetValues(DbCommand cmd, SystemLanguageCodePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@languageid", item.LanguageID));
                cmd.Parameters.Add(new SqlParameter("@name", item.Name));
                cmd.Parameters.Add(new SqlParameter("@native_name", item.NativeName));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<SystemLanguageCodePoco>
        {
            public void SetValues(DbCommand cmd, SystemLanguageCodePoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@languageid", item.LanguageID));
            }
        }

        private class RowMapperImpl : IDbRowMapper<SystemLanguageCodePoco>
        {
            public SystemLanguageCodePoco MapRow(DbDataReader reader)
            {
                return new SystemLanguageCodePoco()
                {
                    LanguageID = reader.GetString(0),
                    Name = reader.GetString(1),
                    NativeName = reader.GetString(2)
                };
            }
        }
    }
}
