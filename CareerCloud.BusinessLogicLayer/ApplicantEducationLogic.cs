using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : BaseLogic<ApplicantEducationPoco>(repository)
{
    protected override void Verify(ApplicantEducationPoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(ApplicantEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
