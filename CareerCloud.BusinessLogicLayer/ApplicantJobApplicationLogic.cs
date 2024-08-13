using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
{
    public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
    {
    }

    protected override void Verify(ApplicantJobApplicationPoco[] pocos)
    {
        throw new NotImplementedException();
    }
}
