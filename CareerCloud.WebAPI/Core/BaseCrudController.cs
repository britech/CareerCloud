using CareerCloud.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Core;

public abstract class BaseCrudController<T, I>(AbstractValidatedPocoCRUDService<T, I> service) : AbstractCrudController<T, I>(service)
    where T : class
{
    protected override ActionResult Add(T[] items)
    {
        return Save(service.Add, items);
    }

    protected override ActionResult Update(T[] items)
    {
        return Save(service.Update, items);
    }

    protected override ActionResult Delete(T[] items)
    {
        return Save(service.Delete, items);
    }

    protected override ActionResult FindById(I id)
    {
        return FindById(service.Get, id);
    }

    public override ActionResult FindAll()
    {
        return FindAll(() => service.GetAll()?.ToArray()!);
    }
}
