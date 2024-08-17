using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : BaseLogic<CompanyProfilePoco>(repository)
{
    protected override void Verify(CompanyProfilePoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<CompanyProfilePoco>(
                poco => ValidationConstants.VALID_DOMAINS.AsEnumerable().Where(domain => poco?.CompanyWebsite?.Contains(domain) ?? false).Count() > 0,
                ValidationException.COMPANY_WEBSITE_INVALID_DOMAIN),
            new PocoValidationRule<CompanyProfilePoco>(
                poco => !string.IsNullOrEmpty(poco?.ContactPhone) && Regex.IsMatch(poco?.ContactPhone ?? "", ValidationConstants.COMPANY_PHONE_REGEX_PATTERN),
                ValidationException.COMPANY_PHONE_INVALID_PATTERN
                )
            ], pocos);
    }

    public override void Add(CompanyProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
