using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : BaseLogic<ApplicantWorkHistoryPoco>(repository)
{
    protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            if (poco?.CompanyName?.Length < 3)
            {
                return [ValidationException.WORK_HISTORY_COMPANY_NAME_REQUIRED];
            }
            return null!;
        }, pocos);
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
