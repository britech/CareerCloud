using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : BaseLogic<ApplicantSkillPoco>(repository)
{
    protected override void Verify(ApplicantSkillPoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<ApplicantSkillPoco>(
                poco => poco?.StartMonth <= ValidationConstants.MAX_MONTHS, 
                ValidationException.SKILL_START_MONTH_INVALID),
            new PocoValidationRule<ApplicantSkillPoco>(
                poco => poco?.StartYear >= ValidationConstants.MIN_YEAR,
                ValidationException.SKILL_START_YEAR_INVALID),
            new PocoValidationRule<ApplicantSkillPoco>(
                poco => poco?.EndMonth <= ValidationConstants.MAX_MONTHS,
                ValidationException.SKILL_END_MONTH_INVALID),
            new PocoValidationRule<ApplicantSkillPoco>(
                poco => poco?.EndYear >= poco?.StartYear,
                ValidationException.SKILL_END_YEAR_LESS_THAN_START_YEAR)
            ], pocos);
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
