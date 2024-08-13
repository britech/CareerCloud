using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantResumeLogic : BaseLogic<ApplicantResumePoco>
{
    public ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : base(repository)
    {
    }

    protected override void Verify(ApplicantResumePoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}
