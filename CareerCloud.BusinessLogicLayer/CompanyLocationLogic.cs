using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : BaseLogic<CompanyLocationPoco>(repository)
{
    protected override void Verify(CompanyLocationPoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<CompanyLocationPoco>(
                poco => !string.IsNullOrEmpty(poco?.CountryCode),
                ValidationException.COMPANY_LOCATION_COUNTRY_REQUIRED),
            new PocoValidationRule<CompanyLocationPoco>(
                poco => !string.IsNullOrEmpty(poco?.Province),
                ValidationException.COMPANY_LOCATION_PROVINCE_REQUIRED),
            new PocoValidationRule<CompanyLocationPoco>(
                poco => !string.IsNullOrEmpty(poco?.City),
                ValidationException.COMPANY_LOCATION_CITY_REQUIRED),
            new PocoValidationRule<CompanyLocationPoco>(
                poco => !string.IsNullOrEmpty(poco?.Street),
                ValidationException.COMPANY_LOCATION_STREET_REQUIRED),
            new PocoValidationRule<CompanyLocationPoco>(
                poco => !string.IsNullOrEmpty(poco?.PostalCode),
                ValidationException.COMPANY_LOCATION_POSTALCODE_REQUIRED)
            ], pocos);
    }

    public override void Add(CompanyLocationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyLocationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
