using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : BaseLogic<ApplicantEducationPoco>(repository)
{
    protected override void Verify(ApplicantEducationPoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<ApplicantEducationPoco>(
                poco => !string.IsNullOrEmpty(poco?.Major) && poco?.Major?.Length >= ValidationConstants.EDUCATION_MAJOR_MIN_LEN,
                ValidationException.EDUCATION_MAJOR_REQUIRED),
            new PocoValidationRule<ApplicantEducationPoco>(
                poco => poco?.StartDate <= DateTime.Now,
                ValidationException.EDUCATION_START_DATE_GREATER_THAN_TODAY),
            new PocoValidationRule<ApplicantEducationPoco>(
                poco => poco?.CompletionDate >= poco?.StartDate,
                ValidationException.EDUCATION_COMPLETION_DATE_LESS_THAN_STARTDATE
                )
            ], pocos);
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
