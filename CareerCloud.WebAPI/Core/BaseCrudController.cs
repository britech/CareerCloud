using CareerCloud.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Core;

public abstract class BaseCrudController<T, I>(AbstractValidatedPocoCRUDService<T, I> service) : AbstractCrudController<T, I>
    where T : class
{
    public AbstractValidatedPocoCRUDService<T, I> Service { get; init; } = service;

    protected override ActionResult Add(T[] items)
    {
        return Save(Service.Add, items);
    }

    protected override ActionResult Update(T[] item)
    {
        return Save(Service.Update, item);
    }

    protected override ActionResult Delete(T[] items)
    {
        return Save(Service.Delete, items);
    }

    protected override ActionResult FindById(I id)
    {
        return FindById(Service.Get, id);
    }

    public override ActionResult FindAll()
    {
        return FindAll(() => Service.GetAll()?.ToArray()!);
    }
}
