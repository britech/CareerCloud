using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
{
    public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyJobDescriptionPoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<CompanyJobDescriptionPoco>(
                poco => !string.IsNullOrEmpty(poco?.JobName),
                ValidationException.JOB_NAME_REQUIRED),
            new PocoValidationRule<CompanyJobDescriptionPoco>(
                poco => !string.IsNullOrEmpty(poco?.JobDescriptions),
                ValidationException.JOB_DESCRIPTION_REQUIRED)
            ], pocos);
    }

    public override void Add(CompanyJobDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
