using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Core;

public abstract class IPocoCrudController<T>(BaseLogic<T> service) : AbstractCrudController<T, Guid>
    where T : IPoco
{
    public BaseLogic<T> Service { get; init; } = service;

    protected override ActionResult Add(T[] items)
    {
        return Save(Service.Add, items);
    }

    protected override ActionResult Update(T[] items)
    {
        return Save(Service.Update, items);
    }

    protected override ActionResult Delete(T[] items)
    {
        return Save(Service.Delete, items);
    }

    protected override ActionResult FindById(Guid id)
    {
        return FindById(Service.Get, id);
    }

    public override ActionResult FindAll()
    {
        return FindAll(() => Service.GetAll()?.ToArray()!);
    }
}
