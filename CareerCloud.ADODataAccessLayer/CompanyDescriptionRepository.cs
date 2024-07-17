using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyDescriptionRepository : BaseRepositoryImpl<CompanyDescriptionPoco>
    {
        public CompanyDescriptionRepository() :
            base("insert into company_descriptions(id, company, languageid, company_name, company_description) values(@id, @company, @languageId, @company_name, @company_description)",
                "update company_descriptions set company = @company, languageid = @languageId, company_name = @company_name, company_description = @company_description where id = @id",
                "delete from company_descriptions where id = @id",
                "select id, company, languageid, company_name, company_description, time_stamp from company_descriptions", 
                new UpdateCmdParameterSetterImpl(), 
                new DeleteCmdParameterSetterImpl(),
                new RowMapperImpl())
        {

        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyDescriptionPoco>
        {
            public void SetValues(DbCommand cmd, CompanyDescriptionPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@languageId", item.LanguageId));
                cmd.Parameters.Add(new SqlParameter("@company_name", item.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@company_description", item.CompanyDescription));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyDescriptionPoco>
        {
            public void SetValues(DbCommand cmd, CompanyDescriptionPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<CompanyDescriptionPoco>
        {
            public CompanyDescriptionPoco MapRow(DbDataReader reader)
            {
                return new CompanyDescriptionPoco()
                {
                    Id = reader.GetGuid(0),
                    Company = reader.GetGuid(1),
                    LanguageId = reader.GetString(2),
                    CompanyName = reader.GetString(3),
                    CompanyDescription = reader.GetString(4),
                    TimeStamp = reader.GetValue(5) as byte[] ?? []
                };
            }
        }
    }
}
