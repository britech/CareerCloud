using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Core;

public abstract class IPocoCrudController<T>(BaseLogic<T> service) : AbstractCrudController<T, Guid>(service)
    where T : IPoco
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

    protected override ActionResult FindById(Guid id)
    {
        return FindById(service.Get, id);
    }

    public override ActionResult FindAll()
    {
        return FindAll(() => service.GetAll()?.ToArray()!);
    }
}
