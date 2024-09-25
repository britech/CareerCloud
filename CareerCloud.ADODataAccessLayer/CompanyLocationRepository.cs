using CareerCloud.Configurations;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer;

public class CompanyLocationRepository : IDataRepository<CompanyLocationPoco>
{
    private readonly DbHelper _dbHelper;

    public CompanyLocationRepository()
        : this(new DbHelper(new CareerCloudConfigResolver(DefaultConfigurationLoader.Instance.Configuration)))
    {
        
    }

    public CompanyLocationRepository(DbHelper dbHelper)
    {
        _dbHelper = dbHelper;
    }

    public void Add(params CompanyLocationPoco[] items)
    {
        _dbHelper.Update("insert into dbo.company_locations(id, company, country_code, state_province_code, street_address, city_town, zip_postal_code) values(@id, @company, @country_code, @state_province_code, @street_address, @city_town, @zip_postal_code)",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@country_code", item.CountryCode));
                cmd.Parameters.Add(new SqlParameter("@state_province_code", item.Province));
                cmd.Parameters.Add(new SqlParameter("@street_address", item.Street));
                cmd.Parameters.Add(new SqlParameter("@city_town", item.City));
                cmd.Parameters.Add(new SqlParameter("@zip_postal_code", item.PostalCode));
            }, items);
    }

    public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
    {
        throw new NotImplementedException();
    }

    public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
    {
        return _dbHelper.Query("select id, company, country_code, state_province_code, street_address, city_town, zip_postal_code, time_stamp from dbo.company_locations",
            reader =>
            {
                return new CompanyLocationPoco()
                {
                    Id = reader.GetGuid(0),
                    Company = reader.GetGuid(1),
                    CountryCode = reader.GetString(2),
                    Province = reader.GetValue(3) as string ?? null,
                    Street = reader.GetValue(4) as string ?? null,
                    City = reader.GetValue(5) as string ?? null,
                    PostalCode = reader.GetValue(6) as string ?? null,
                    TimeStamp = reader.GetValue(7) as byte[] ?? []
                };
            });
    }

    public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
    {
        throw new NotImplementedException();
    }

    public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
    {
        return GetAll().AsQueryable().Where(where).FirstOrDefault(null as CompanyLocationPoco)!;
    }

    public void Remove(params CompanyLocationPoco[] items)
    {
        _dbHelper.Update("delete from dbo.company_locations where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
            }, items);
    }

    public void Update(params CompanyLocationPoco[] items)
    {
        _dbHelper.Update("update dbo.company_locations set company = @company, country_code = @country_code, state_province_code = @state_province_code, street_address = @street_address, city_town = @city_town, zip_postal_code = @zip_postal_code where id = @id",
            (cmd, item) =>
            {
                cmd.Parameters.Add(new SqlParameter("@id", item.Id));
                cmd.Parameters.Add(new SqlParameter("@company", item.Company));
                cmd.Parameters.Add(new SqlParameter("@country_code", item.CountryCode));
                cmd.Parameters.Add(new SqlParameter("@state_province_code", item.Province));
                cmd.Parameters.Add(new SqlParameter("@street_address", item.Street));
                cmd.Parameters.Add(new SqlParameter("@city_town", item.City));
                cmd.Parameters.Add(new SqlParameter("@zip_postal_code", item.PostalCode));
            }, items);
    }
}
