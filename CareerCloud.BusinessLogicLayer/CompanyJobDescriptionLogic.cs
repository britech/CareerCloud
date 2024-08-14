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
        PocoValidationHelper.Verify(poco =>
        {
            List<ValidationException> errors = [];
            if (string.IsNullOrEmpty(poco?.JobName))
            {
                errors.Add(ValidationException.JOB_NAME_REQUIRED);
            }

            if (string.IsNullOrEmpty(poco?.JobDescriptions))
            {
                errors.Add(ValidationException.JOB_DESCRIPTION_REQUIRED);
            }

            return errors;
        }, pocos);
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
