using CareerCloud.DataAccessLayer;

namespace CareerCloud.BusinessLogicLayer;

public abstract class AbstractValidatedPocoCRUDService<TPoco, TPocoId>(IDataRepository<TPoco> repository, PocoValidationRule<TPoco>[] rules)
{
    protected IDataRepository<TPoco> Repository { get; init; } = repository;
    protected PocoValidationRule<TPoco>[] Rules { get; init; } = rules;

    protected virtual void Verify(TPoco[] items)
    {
        PocoValidationHelper.Validate(Rules, items);
    }

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
