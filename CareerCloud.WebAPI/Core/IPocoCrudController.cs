using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Core;

public abstract class IPocoCrudController<T>(BusinessLogicFactory factory) : AbstractCrudController<T, Guid>(factory)
    where T : IPoco
{
    protected override ActionResult Add(T[] items)
    {
        return Save(Factory.CreateIPocoService<T>().Add, items);
    }

    protected override ActionResult Update(T[] items)
    {
        return Save(Factory.CreateIPocoService<T>().Update, items);
    }

    protected override ActionResult Delete(T[] items)
    {
        return Save(Factory.CreateIPocoService<T>().Delete, items);
    }

    protected override ActionResult FindById(Guid id)
    {
        return FindById(Factory.CreateIPocoService<T>().Get, id);
    }

    public override ActionResult FindAll()
    {
        return FindAll(() => Factory.CreateIPocoService<T>().GetAll()?.ToArray()!);
    }
}
