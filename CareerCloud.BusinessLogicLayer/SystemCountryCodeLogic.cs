using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SystemCountryCodeLogic : AbstractValidatedPocoCRUDService<SystemCountryCodePoco, string>
{
    public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) 
        : base(repository, [
        new PocoValidationRule<SystemCountryCodePoco>(
            item => !string.IsNullOrEmpty(item?.Code), 
            ValidationException.SYSTEM_COUNTRY_CODE_REQUIRED),
        new PocoValidationRule<SystemCountryCodePoco>(
            item => !string.IsNullOrEmpty(item?.Name),
            ValidationException.SYSTEM_COUNTRY_NAME_REQUIRED
            )
        ])
    {
    }

    public override SystemCountryCodePoco Get(string id)
    {
        return Repository.GetSingle(_countryCode => _countryCode.Code == id);
    }
}
