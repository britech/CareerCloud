using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public abstract class BaseLogic<TPoco> : AbstractBaseLogic<TPoco, Guid>
    where TPoco : IPoco
{
    protected IDataRepository<TPoco> _repository;
    public BaseLogic(IDataRepository<TPoco> repository) : base(repository)
    {
        _repository = repository;
    }

    public override TPoco Get(Guid id)
    {
        return _repository.GetSingle(c => c.Id == id);
    }

    public override void Add(TPoco[] pocos)
    {
        foreach (TPoco poco in pocos)
        {
            if (poco.Id == Guid.Empty)
            {
                poco.Id = Guid.NewGuid();
            }
        }

        base.Add(pocos);
    }
}