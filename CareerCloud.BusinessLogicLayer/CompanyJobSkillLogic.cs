using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : BaseLogic<CompanyJobSkillPoco>(repository)
{
    protected override void Verify(CompanyJobSkillPoco[] pocos)
    {
        PocoValidationHelper.Verify(poco =>
        {
            if (poco?.Importance < 0)
            {
                return [ValidationException.JOB_REQUIRED_SKILL_IMPORTANCE_LEVEL_MIN_LEVEL];
            }
            return null!;
        }, pocos);
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
