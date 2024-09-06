using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantResumeRepository : IDataRepository<ApplicantResumePoco>
    {
        private readonly DbHelper _dbHelper;

        public ApplicantResumeRepository()
        {
            _dbHelper = new DbHelper(CareerCloudConfigurationLoader.Instance.GetConnectionString());
        }

        public void Add(params ApplicantResumePoco[] items)
        {
            _dbHelper.Update("insert into dbo.applicant_resumes(id, applicant, resume, last_updated) values(@id, @applicant, @resume, @last_updated)",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@applicant", item.Applicant));
                    cmd.Parameters.Add(new SqlParameter("@resume", item.Resume));
                    cmd.Parameters.Add(new SqlParameter("@last_updated", item.LastUpdated));
                }, items);
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            return _dbHelper.Query("select id, applicant, resume, last_updated from dbo.applicant_resumes", (reader) =>
            {
                return new ApplicantResumePoco()
                {
                    Id = reader.GetGuid(0),
                    Applicant = reader.GetGuid(1),
                    Resume = reader.GetString(2),
                    LastUpdated = reader.GetValue(3) as DateTime?
                };
            });
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantResumePoco)!;
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            _dbHelper.Update("delete from dbo.applicant_resumes where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                }, items);
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            _dbHelper.Update("update dbo.applicant_resumes set applicant = @applicant, resume = @resume, last_updated = @last_updated where id = @id",
                (cmd, item) =>
                {
                    cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                    cmd.Parameters.Add(new SqlParameter("@applicant", item.Applicant));
                    cmd.Parameters.Add(new SqlParameter("@resume", item.Resume));
                    cmd.Parameters.Add(new SqlParameter("@last_updated", item.LastUpdated));
                }, items);
        }
    }
}
