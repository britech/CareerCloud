using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : BaseLogic<ApplicantJobApplicationPoco>(repository)
{
    protected override void Verify(ApplicantJobApplicationPoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            if (poco?.ApplicationDate > DateTime.Now)
            {
                return [ValidationException.JOB_APPLICATION_DATE_GREATER_THAN_TODAY];
            }
            return null!;
        }, pocos);
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
