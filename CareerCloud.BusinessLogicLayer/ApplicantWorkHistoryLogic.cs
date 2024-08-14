using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : BaseLogic<ApplicantWorkHistoryPoco>(repository)
{
    protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(ApplicantWorkHistoryPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantWorkHistoryPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
