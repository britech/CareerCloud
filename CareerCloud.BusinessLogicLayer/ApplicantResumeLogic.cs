using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantResumeLogic(IDataRepository<ApplicantResumePoco> repository) : BaseLogic<ApplicantResumePoco>(repository)
{
    protected override void Verify(ApplicantResumePoco[] pocos)
    {
       PocoValidationHelper.Validate([
           new PocoValidationRule<ApplicantResumePoco>(
               poco => !string.IsNullOrEmpty(poco?.Resume), 
               ValidationException.RESUME_REQUIRED)
           ], pocos);
    }

    public override void Add(ApplicantResumePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantResumePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
