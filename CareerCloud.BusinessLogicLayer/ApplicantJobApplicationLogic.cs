using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
{
    public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
    {
    }

    protected override void Verify(ApplicantJobApplicationPoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}
