using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : BaseLogic<ApplicantProfilePoco>(repository)
{
    protected override void Verify(ApplicantProfilePoco[] pocos)
    {
        throw new NotImplementedException();
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
