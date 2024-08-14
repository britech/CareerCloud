using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : BaseLogic<ApplicantSkillPoco>(repository)
{
    protected override void Verify(ApplicantSkillPoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            List<ValidationException> errors = [];
            if (poco?.StartMonth > 12)
            {
                errors.Add(ValidationException.SKILL_STARTMONTH_INVALID);
            }

            if (poco?.StartYear < 1900)
            {
                errors.Add(ValidationException.SKILL_STARTYEAR_INVALID);
            }

            if (poco?.EndMonth > 12)
            {
                errors.Add(ValidationException.SKILL_ENDMONTH_INVALID);
            }

            if (poco?.EndYear < poco?.StartYear)
            {
                errors.Add(ValidationException.SKILL_ENDYEAR_LESSTHAN_STARTYEAR);
            }

            return errors;
        }, pocos);
    }

    public override void Add(ApplicantSkillPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantSkillPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
