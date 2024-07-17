using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Transactions;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        public void Add(params ApplicantEducationPoco[] items)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    foreach (var item in items)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "insert into applicant_educations(id, applicant, major, certificate_diploma, start_date, completion_date, completion_percent) values(@id, @applicant, @major, @certificateDiploma, @startDate, @completionDate, @completionPercent)";
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@applicant", value: item.Applicant));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@major", value: item.Major));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@certificateDiploma", value: item.CertificateDiploma));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@startDate", value: item.StartDate));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@completionDate", value: item.CompletionDate));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@completionPercent", value: item.CompletionPercent));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IList<ApplicantEducationPoco> items = new List<ApplicantEducationPoco>();
            using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
            {
                using (DbCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select id, applicant, major, certificate_diploma, start_date, completion_date, completion_percent, time_stamp from applicant_educations";

                    connection.Open();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new ApplicantEducationPoco
                            {
                                Id = reader.GetGuid(0),
                                Applicant = reader.GetGuid(1),
                                Major = reader.GetString(2),
                                CertificateDiploma = reader.GetString(3),
                                StartDate = reader.GetDateTime(4),
                                CompletionDate = reader.GetDateTime(5),
                                CompletionPercent = reader.GetByte(6),
                                TimeStamp = reader.GetValue(7) as byte[] ?? Array.Empty<byte>()
                            });
                        }
                    }
                }
            }
            return items;
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            return GetAll().AsQueryable().Where(where).FirstOrDefault(null as ApplicantEducationPoco)!;
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    foreach (var item in items)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "delete from applicant_educations where id = @id";
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (DbConnection connection = new SqlConnection(ApplicationConstants.CONNECTION_STRING))
                {
                    connection.Open();
                    foreach (var item in items)
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "update applicant_educations set applicant = @applicant, major = @major, certificate_diploma = @certificateDiploma, start_date = @startDate, completion_date = @completionDate, completion_percent = @completionPercent where id = @id";
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@id", value: item.Id));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@applicant", value: item.Applicant));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@major", value: item.Major));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@certificateDiploma", value: item.CertificateDiploma));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@startDate", value: item.StartDate));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@completionDate", value: item.CompletionDate));
                            cmd.Parameters.Add(new SqlParameter(parameterName: "@completionPercent", value: item.CompletionPercent));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    scope.Complete();
                }
            }
        }
    }
}
