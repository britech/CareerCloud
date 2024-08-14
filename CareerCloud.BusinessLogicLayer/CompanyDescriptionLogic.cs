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
        PocoValidationHelper.Verify(poco =>
        {
            List<ValidationException> errors = new List<ValidationException>();
            if (poco?.CompanyDescription?.Length < 3)
            {
                errors.Add(ValidationException.COMPANY_DESCRIPTION_MIN_LEN);
            }

            if (poco?.CompanyName?.Length < 3)
            {
                errors.Add(ValidationException.COMPANY_NAME_MIN_LEN);
            }

            return errors;
        }, pocos);
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
