using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer;

public abstract class AbstractBaseLogic<TPoco, TPocoId>(IDataRepository<TPoco> repository)
{
    protected IDataRepository<TPoco> Repository { get; init; } = repository;

    protected virtual void Verify(TPoco[] items)
    {
        List<ValidationException> validationErrors = new List<ValidationException>();
        foreach(TPoco item in items)
        {
            Verify(item, validationErrors);
        }

        if (validationErrors.Count > 0)
        {
            throw new AggregateException(validationErrors);
        }
    }

    protected abstract void Verify(TPoco item, List<ValidationException> validationErrors);

    public abstract TPoco Get(TPocoId id);

    public virtual List<TPoco> GetAll()
    {
        return Repository.GetAll().ToList();
    }

    public virtual void Add(TPoco[] items)
    {
        Verify(items);
        Repository.Add(items);
    }

    public virtual void Update(TPoco[] items)
    {
        Verify(items);
        Repository.Update(items);
    }

    public virtual void Delete(TPoco[] items)
    {
        Repository.Remove(items);
    }
}
