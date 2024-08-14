using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobDescriptionLogic : BaseLogic<CompanyJobDescriptionPoco>
{
    public CompanyJobDescriptionLogic(IDataRepository<CompanyJobDescriptionPoco> repository) : base(repository)
    {
    }

    protected override void Verify(CompanyJobDescriptionPoco[] pocos)
    {
        throw new NotImplementedException();
    }

    public override void Add(CompanyJobDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobDescriptionPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
