using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : BaseLogic<CompanyJobSkillPoco>(repository)
{
    protected override void Verify(CompanyJobSkillPoco[] pocos)
    {
        PocoValidationHelper.Validate([
            new PocoValidationRule<CompanyJobSkillPoco>(
                poco => poco?.Importance >= ValidationConstants.JOB_REQUIRED_SKILL_IMPORTANCE_LEVEL_MIN_LEVEL,
                ValidationException.JOB_REQUIRED_SKILL_IMPORTANCE_LEVEL_MIN_LEVEL)
            ], pocos);
    }

    public override void Add(CompanyJobSkillPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobSkillPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
