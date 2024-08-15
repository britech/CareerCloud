using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : BaseLogic<CompanyProfilePoco>(repository)
{
    private static readonly List<string> VALID_DOMAINS = new List<string>([".ca", ".com", ".biz"]);

    protected override void Verify(CompanyProfilePoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            List<ValidationException> errors = [];

            if (VALID_DOMAINS.AsEnumerable().Where(domain => poco?.CompanyWebsite?.Contains(domain) ?? false).Count() == 0)
            {
                errors.Add(ValidationException.COMPANY_WEBSITE_INVALID_DOMAIN);
            }

            if (string.IsNullOrEmpty(poco?.ContactPhone) || !Regex.IsMatch(poco?.ContactPhone ?? "", "\\d{1}\\d{2}-\\d{3}-\\d{4}"))
            {
                errors.Add(ValidationException.COMPANY_PHONE_INVALID_PATTERN);
            }

            return errors;
        }, pocos);
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
