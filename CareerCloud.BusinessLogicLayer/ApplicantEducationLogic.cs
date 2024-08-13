using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
{
    public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
    {
    
    }
    
    protected override void Verify(ApplicantEducationPoco[] pocos)
    {
        throw new NotImplementedException();
    }
}
