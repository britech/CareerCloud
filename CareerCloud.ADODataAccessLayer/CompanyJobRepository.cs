using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobRepository : BaseRepositoryImpl<CompanyJobPoco>
    {
        public CompanyJobRepository():
            base(new DbHelper(ApplicationConstants.CONNECTION_STRING),
                "insert into company_jobs(id, company, profile_created, is_inactive, is_company_hidden) values(@id, @company, @profile_created, @is_inactive, @is_company_hidden)", 
                "update company_jobs set company = @company, profile_created = @profile_created, is_inactive = @is_inactive, is_company_hidden = @is_company_hidden where id = @id", 
                "delete from company_jobs where id = @id", 
                "select id, company, profile_created, is_inactive, is_company_hidden, time_stamp from company_jobs", 
                new UpdateCmdParameterSetterImpl(), 
                new DeleteCmdParameterSetterImpl(), 
                new RowMapperImpl())
        {
            
        }

        private class UpdateCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyJobPoco>
        {
            public void SetValues(DbCommand cmd, CompanyJobPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@profile_created", item.ProfileCreated));
                cmd.Parameters.Add(new SqlParameter("@is_inactive", item.IsInactive));
                cmd.Parameters.Add(new SqlParameter("@is_company_hidden", item.IsCompanyHidden));
            }
        }

        private class DeleteCmdParameterSetterImpl : IDbCommandParameterSetter<CompanyJobPoco>
        {
            public void SetValues(DbCommand cmd, CompanyJobPoco item)
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }
        }

        private class RowMapperImpl : IDbRowMapper<CompanyJobPoco>
        {
            public CompanyJobPoco MapRow(DbDataReader reader)
            {
                return new CompanyJobPoco()
                {
                    Id = reader.GetGuid(0),
                    Company = reader.GetGuid(1),
                    ProfileCreated = reader.GetDateTime(2),
                    IsInactive = reader.GetBoolean(3),
                    IsCompanyHidden = reader.GetBoolean(4),
                    TimeStamp = reader.GetValue(5) as byte[] ?? []
                };
            }
        }
    }
}
