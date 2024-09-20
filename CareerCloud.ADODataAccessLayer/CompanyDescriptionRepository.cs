using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class CompanyDescriptionRepository : IDataRepository<CompanyDescriptionPoco>
{
    private readonly DbHelper _dbHelper;

    public CompanyDescriptionRepository()
        : this(new DbHelper(new CareerCloudConfigResolver(CareerCloudIniLoader.LoadConfiguration())))
    {
        
    }

    public CompanyDescriptionRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Add(params CompanyDescriptionPoco[] items)
    {
        _dbHelper.Update("insert into dbo.company_descriptions(id, company, languageid, company_name, company_description) values(@id, @company, @languageId, @company_name, @company_description)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@languageId", item.LanguageId));
                cmd.Parameters.Add(new SqlParameter("@company_name", item.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@company_description", item.CompanyDescription));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select id, company, languageid, company_name, company_description, time_stamp from dbo.company_descriptions",
            (reader) =>
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
            });
    }

    public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as CompanyDescriptionPoco)!;
    }

    public void Remove(params CompanyDescriptionPoco[] items)
    {
        _dbHelper.Update("delete from dbo.company_descriptions where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }, items);
    }

    public void Update(params CompanyDescriptionPoco[] items)
    {
        _dbHelper.Update("update dbo.company_descriptions set company = @company, languageid = @languageId, company_name = @company_name, company_description = @company_description where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@languageId", item.LanguageId));
                cmd.Parameters.Add(new SqlParameter("@company_name", item.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@company_description", item.CompanyDescription));
            }, items);
    }
}
