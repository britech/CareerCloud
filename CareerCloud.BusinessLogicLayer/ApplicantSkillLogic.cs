using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantSkillLogic : BaseLogic<ApplicantSkillPoco>
{
    public ApplicantSkillLogic(IDataRepository<ApplicantSkillPoco> repository) : base(repository)
    {
    }

    protected override void Verify(ApplicantSkillPoco[] pocos)
    {
        throw new NotImplementedException();
    }
}
