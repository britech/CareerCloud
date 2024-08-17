using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : BaseLogic<ApplicantWorkHistoryPoco>(repository)
{
    protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
    {
        PocoValidationHelper.Validate([
             new PocoValidationRule<ApplicantWorkHistoryPoco>(
                poco => poco?.CompanyName?.Length >= ValidationConstants.WORK_HISTORY_COMPANY_NAME_MIN_LEN,
                ValidationException.WORK_HISTORY_COMPANY_NAME_REQUIRED)
             ], pocos);
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
