using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.Common;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : IDataRepository<ApplicantJobApplicationPoco>, IDbRowMapper<ApplicantJobApplicationPoco>
    {
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            DbHelper.WriteToDB("insert into applicant_job_applications(id, applicant, job, application_date) values(@id, @applicant, @job, @applicationDate)", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id },
                    { "@applicant", item.Applicant },
                    { "@job", item.Job },
                    { "@applicationDate", item.ApplicationDate }
                };
                return queryParams;
            }).ToList());
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            return DbHelper.LoadFromDB<ApplicantJobApplicationPoco>("select id, applicant, job, application_date, time_stamp from applicant_job_applications", this);
        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantJobApplicationPoco)!;
        }

        public ApplicantJobApplicationPoco MapRow(DbDataReader reader)
        {
            return new ApplicantJobApplicationPoco()
            {
                Id = reader.GetGuid(0),
                Applicant = reader.GetGuid(1),
                Job = reader.GetGuid(2),
                ApplicationDate = reader.GetDateTime(3),
                TimeStamp = reader.GetValue(4) as byte[] ?? []
            };
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            DbHelper.WriteToDB("delete from applicant_job_applications where id = @id", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id }
                };
                return queryParams;
            }).ToList());
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            DbHelper.WriteToDB("update applicant_job_applications set applicant = @applicant, job = @job, application_date = @applicationDate where id = @id", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id },
                    { "@applicant", item.Applicant },
                    { "@job", item.Job },
                    { "@applicationDate", item.ApplicationDate }
                };
                return queryParams;
            }).ToList());
        }
    }
}
