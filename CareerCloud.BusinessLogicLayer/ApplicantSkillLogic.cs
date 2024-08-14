using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : BaseLogic<ApplicantSkillPoco>(repository)
{
    protected override void Verify(ApplicantSkillPoco[] pocos)
    {
        throw new NotImplementedException();
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
