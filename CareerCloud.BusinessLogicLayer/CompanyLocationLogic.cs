using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : BaseLogic<CompanyLocationPoco>(repository)
{
    protected override void Verify(CompanyLocationPoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            List<ValidationException> errors = new List<ValidationException>();
            if (string.IsNullOrEmpty(poco?.CountryCode))
            {
                errors.Add(ValidationException.COMPANY_LOCATION_COUNTRY_REQUIRED);
            }

            if (string.IsNullOrEmpty(poco?.Province))
            {
                errors.Add(ValidationException.COMPANY_LOCATION_PROVINCE_REQUIRED);
            }

            if (string.IsNullOrEmpty(poco?.City))
            {
                errors.Add(ValidationException.COMPANY_LOCATION_CITY_REQUIRED);
            }

            if (string.IsNullOrEmpty(poco?.Street))
            {
                errors.Add(ValidationException.COMPANY_LOCATION_STREET_REQUIRED);
            }

            if (string.IsNullOrEmpty(poco?.PostalCode))
            {
                errors.Add(ValidationException.COMPANY_LOCATION_POSTALCODE_REQUIRED);
            }

            return errors;
        }, pocos);
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
