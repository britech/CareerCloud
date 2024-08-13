using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer;

public abstract class AbstractBaseLogic<TPoco, TPocoId>(IDataRepository<TPoco> repository)
{
    private readonly IDataRepository<TPoco> _repository = repository;

    protected abstract void Verify(TPoco[] items);

    public abstract TPoco Get(TPocoId id);

    public virtual List<TPoco> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public virtual void Add(TPoco[] items)
    {
        Verify(items);
        _repository.Add(items);
    }

    public virtual void Update(TPoco[] items)
    {
        Verify(items);
        _repository.Update(items);
    }

    public virtual void Delete(TPoco[] items)
    {
        _repository.Remove(items);
    }
}
