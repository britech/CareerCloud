using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : BaseLogic<ApplicantProfilePoco>(repository)
{
    protected override void Verify(ApplicantProfilePoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<ApplicantProfilePoco>(
                poco => poco?.CurrentSalary >= ValidationConstants.CURRENT_SALARY_MIN_VALUE, 
                ValidationException.CURRENT_SALARY_IS_NEGATIVE),
            new PocoValidationRule<ApplicantProfilePoco>(
                poco => poco?.CurrentRate >= ValidationConstants.CURRENT_RATE_MIN_VALUE, 
                ValidationException.CURRENT_RATE_IS_NEGATIVE)
            ], pocos);
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
