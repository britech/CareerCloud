using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SystemCountryCodeLogic : AbstractValidatedPocoCRUDService<SystemCountryCodePoco, string>
{
    public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) : base(repository)
    {
    }

    public override SystemCountryCodePoco Get(string id)
    {
        return Repository.GetSingle(_countryCode => _countryCode.Code == id);
    }

    protected override void Verify(SystemCountryCodePoco[] items)
    {
        PocoValidationHelper.Verify(item =>
        {
            List<ValidationException> errors = [];

            if (string.IsNullOrEmpty(item?.Code))
            {
                errors.Add(ValidationException.SYSTEM_COUNTRY_CODE_REQUIRED);
            }

            if (string.IsNullOrEmpty(item?.Name))
            {
                errors.Add(ValidationException.SYSTEM_COUNTRY_NAME_REQUIRED);
            }

            return errors;
        }, items);
    }
}
