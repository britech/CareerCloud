using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : BaseLogic<CompanyJobSkillPoco>(repository)
{
    protected override void Verify(CompanyJobSkillPoco[] pocos)
    {
        throw new NotImplementedException();
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
