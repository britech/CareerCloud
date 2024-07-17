using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.Common;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantResumeRepository : IDataRepository<ApplicantResumePoco>, IDataRowMapper<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            DbHelper.Write("insert into applicant_resumes(id, applicant, resume, last_updated) values(@id, @applicant, @resume, @last_updated)", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id },
                    { "@applicant", item.Applicant },
                    { "@resume", item.Resume },
                    { "@last_updated", item.LastUpdated }
                };
                return queryParams;
            }).ToList());
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            return DbHelper.Load("select id, applicant, resume, last_updated from applicant_resumes", this);
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantResumePoco)!;
        }

        public ApplicantResumePoco MapRow(DbDataReader reader)
        {
            return new ApplicantResumePoco()
            {
                Id = reader.GetGuid(0),
                Applicant = reader.GetGuid(1),
                Resume = reader.GetString(2),
                LastUpdated = reader.GetValue(3) as DateTime?
            };
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            DbHelper.Write("delete from applicant_resumes where id = @id", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id }
                };
                return queryParams;
            }).ToList());
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            DbHelper.Write("update applicant_resumes set applicant = @applicant, resume = @resume, last_updated = @last_updated where id = @id", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    { "@id", item.Id },
                    { "@applicant", item.Applicant },
                    { "@resume", item.Resume },
                    { "@last_updated", item.LastUpdated }
                };
                return queryParams;
            }).ToList());
        }
    }
}
