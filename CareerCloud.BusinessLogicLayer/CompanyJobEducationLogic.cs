using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : BaseLogic<CompanyJobEducationPoco>(repository)
{
    protected override void Verify(CompanyJobEducationPoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<CompanyJobEducationPoco>(
                poco => poco?.Major?.Length >= ValidationConstants.JOB_REQUIRED_EDUCATION_MAJOR_MIN_LEN,
                ValidationException.JOB_REQUIRED_EDUCATION_MAJOR_MIN_LEN),
            new PocoValidationRule<CompanyJobEducationPoco>(
                poco => poco?.Importance >= ValidationConstants.JOB_REQUIRED_EDUCATION_IMPORTANCE_MIN_LEVEL,
                ValidationException.JOB_REQUIRED_EDUCATION_IMPORTANCE_MIN_LEVEL)
        ], pocos);
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
