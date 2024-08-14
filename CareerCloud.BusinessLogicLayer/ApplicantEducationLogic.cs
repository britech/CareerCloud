using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : BaseLogic<ApplicantEducationPoco>(repository)
{
    protected override void Verify(ApplicantEducationPoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            List<ValidationException> errors = [];
            if (string.IsNullOrEmpty(poco?.Major) || poco?.Major?.Length < 3)
            {
                errors.Add(ValidationException.EDUCATION_MAJOR_REQUIRED);
            }

            if (poco?.StartDate > DateTime.Now)
            {
                errors.Add(ValidationException.EDUCATION_START_DATE_GREATER_THAN_TODAY);
            }

            if (poco?.CompletionDate < poco?.StartDate)
            {
                errors.Add(ValidationException.EDUCATION_COMPLETION_DATE_LESS_THAN_STARTDATE);
            }

            return errors;
        }, pocos);
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
