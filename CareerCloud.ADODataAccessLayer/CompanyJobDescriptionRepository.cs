using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobDescriptionRepository : IDataRepository<CompanyJobDescriptionPoco>
    {
        private readonly DbHelper _dbHelper;

        public CompanyJobDescriptionRepository()
        {
            _dbHelper = new DbHelper(CareerCloudConfigurationLoader.Instance.GetConnectionString());
        }

        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            _dbHelper.Update("insert into dbo.company_jobs_descriptions(id, job, job_name, job_descriptions) values(@id, @job, @job_name, @job_descriptions)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                    cmd.Parameters.Add(new SqlParameter("@job_name", item.JobName));
                    cmd.Parameters.Add(new SqlParameter("@job_descriptions", item.JobDescriptions));
                }, items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select id, job, job_name, job_descriptions, time_stamp from dbo.company_jobs_descriptions",
                reader =>
                {
                    return new CompanyJobDescriptionPoco()
                    {
                        Id = reader.GetGuid(0),
                        Job = reader.GetGuid(1),
                        JobName = reader.GetString(2),
                        JobDescriptions = reader.GetString(3),
                        TimeStamp = reader.GetValue(4) as byte[] ?? []
                    };
                });
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as CompanyJobDescriptionPoco)!;
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            _dbHelper.Update("delete from dbo.company_jobs_descriptions where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                }, items);
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            _dbHelper.Update("update dbo.company_jobs_descriptions set id = @id, job = @job, job_name = @job_name, job_descriptions = @job_descriptions where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@job", item.Job));
                    cmd.Parameters.Add(new SqlParameter("@job_name", item.JobName));
                    cmd.Parameters.Add(new SqlParameter("@job_descriptions", item.JobDescriptions));
                }, items);
        }
    }
}
