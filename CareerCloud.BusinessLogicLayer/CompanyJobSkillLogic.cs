using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobSkillLogic : BaseLogic<CompanyJobSkillPoco>
{
    public CompanyJobSkillLogic(IDataRepository<CompanyJobSkillPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyJobSkillPoco item, List<ValidationException> validationErrors)
    {
        throw new NotImplementedException();
    }
}
