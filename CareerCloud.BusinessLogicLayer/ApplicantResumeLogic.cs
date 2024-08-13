using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
{
    public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : base(repository)
    {
    }

    protected override void Verify(ApplicantResumePoco[] pocos)
    {
        throw new NotImplementedException();
    }
}
