using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>, IDataRowMapper<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            DbHelper.Write("insert into applicant_educations(id, applicant, major, certificate_diploma, start_date, completion_date, completion_percent) values(@id, @applicant, @major, @certificateDiploma, @startDate, @completionDate, @completionPercent)", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    {"@id", item.Id},
                    {"@applicant", item.Applicant },
                    {"@major", item.Major },
                    {"@certificateDiploma", item.CertificateDiploma },
                    {"@startDate", item.StartDate },
                    {"@completionDate", item.CompletionDate },
                    {"@completionPercent", item.CompletionPercent }
                };
                return queryParams;
            }).ToList());
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            return DbHelper.Load<ApplicantEducationPoco>("select id, applicant, major, certificate_diploma, start_date, completion_date, completion_percent, time_stamp from applicant_educations", this);
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantEducationPoco)!;
        }

        public ApplicantEducationPoco MapRow(DbDataReader reader)
        {
            return new ApplicantEducationPoco
            {
                Id = reader.GetGuid(0),
                Applicant = reader.GetGuid(1),
                Major = reader.GetString(2),
                CertificateDiploma = reader.GetString(3),
                StartDate = reader.GetDateTime(4),
                CompletionDate = reader.GetDateTime(5),
                CompletionPercent = reader.GetByte(6),
                TimeStamp = reader.GetValue(7) as byte[] ?? []
            };
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            DbHelper.Write("delete from applicant_educations where id = @id", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    {"@id", item.Id}
                };
                return queryParams;
            }).ToList());
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            DbHelper.Write("update applicant_educations set applicant = @applicant, major = @major, certificate_diploma = @certificateDiploma, start_date = @startDate, completion_date = @completionDate, completion_percent = @completionPercent where id = @id", items.AsEnumerable().Select(item =>
            {
                IDictionary<string, object?> queryParams = new Dictionary<string, object?>()
                {
                    {"@id", item.Id},
                    {"@applicant", item.Applicant },
                    {"@major", item.Major },
                    {"@certificateDiploma", item.CertificateDiploma },
                    {"@startDate", item.StartDate },
                    {"@completionDate", item.CompletionDate },
                    {"@completionPercent", item.CompletionPercent }
                };
                return queryParams;
            }).ToList());
        }
    }
}
