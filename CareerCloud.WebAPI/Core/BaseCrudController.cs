using CareerCloud.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Core;

public abstract class BaseCrudController<T, I>(BusinessLogicFactory factory) : AbstractCrudController<T, I>(factory)
    where T : class
{
    protected override ActionResult Add(T[] items)
    {
        return Save(Factory.CreateService<T, I>().Add, items);
    }

    protected override ActionResult Update(T[] items)
    {
        return Save(Factory.CreateService<T, I>().Update, items);
    }

    protected override ActionResult Delete(T[] items)
    {
        return Save(Factory.CreateService<T, I>().Delete, items);
    }

    protected override ActionResult FindById(I id)
    {
        return FindById(Factory.CreateService<T, I>().Get, id);
    }

    public override ActionResult FindAll()
    {
        return FindAll(() => Factory.CreateService<T, I>().GetAll()?.ToArray()!);
    }
}
