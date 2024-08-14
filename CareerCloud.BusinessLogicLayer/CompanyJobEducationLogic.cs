using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : BaseLogic<CompanyJobEducationPoco>(repository)
{
    protected override void Verify(CompanyJobEducationPoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            List<ValidationException> errors = [];

            if(poco?.Major?.Length < 2)
            {
                errors.Add(ValidationException.JOB_REQUIRED_EDUCATION_MAJOR_MIN_LEN);
            }

            if (poco?.Importance < 0)
            {
                errors.Add(ValidationException.JOB_REQUIRED_EDUCATION_IMPORTANCE_MIN_LEVEL);
            }

            return errors;
        }, pocos);
    }

    public override void Add(CompanyJobEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
