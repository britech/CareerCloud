using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
{
    public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyDescriptionPoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(CompanyDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
