using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : BaseLogic<ApplicantJobApplicationPoco>(repository)
{
    protected override void Verify(ApplicantJobApplicationPoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<ApplicantJobApplicationPoco>(
                poco => poco?.ApplicationDate <= DateTime.Now,
                ValidationException.JOB_APPLICATION_DATE_GREATER_THAN_TODAY
                )
            ], pocos);
    }

    public override void Add(ApplicantJobApplicationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantJobApplicationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
