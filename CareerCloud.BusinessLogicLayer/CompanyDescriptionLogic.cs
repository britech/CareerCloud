using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
{
    public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyDescriptionPoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<CompanyDescriptionPoco>(
                poco => poco?.CompanyDescription?.Length >= ValidationConstants.COMPANY_DESCRIPTION_MIN_LEN,
                ValidationException.COMPANY_DESCRIPTION_MIN_LEN
                ),
            new PocoValidationRule<CompanyDescriptionPoco>(
                poco => poco?.CompanyName?.Length >= ValidationConstants.COMPANY_NAME_MIN_LEN,
                ValidationException.COMPANY_NAME_MIN_LEN)
            ], pocos);
    }

    public override void Add(CompanyDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
