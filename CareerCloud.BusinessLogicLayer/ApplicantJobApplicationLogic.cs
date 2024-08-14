using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : BaseLogic<ApplicantJobApplicationPoco>(repository)
{
    protected override void Verify(ApplicantJobApplicationPoco[] pocos)
    {
        throw new NotImplementedException();
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
