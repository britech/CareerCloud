using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : BaseLogic<ApplicantProfilePoco>(repository)
{
    protected override void Verify(ApplicantProfilePoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            List<ValidationException> errors = [];
            if (poco?.CurrentSalary < decimal.Zero)
            {
                errors.Add(ValidationException.CURRENT_SALARY_IS_NEGATIVE);
            }

            if (poco?.CurrentRate < decimal.Zero)
            {
                errors.Add(ValidationException.CURRENT_RATE_IS_NEGATIVE);
            }

            return errors;
        }, pocos);
    }

    public override void Add(ApplicantProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
