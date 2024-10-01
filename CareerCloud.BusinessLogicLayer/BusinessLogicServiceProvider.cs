using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class BusinessLogicServiceProvider : IServiceProvider
{
    private readonly HashSet<object> _services;

    public BusinessLogicServiceProvider()
    {
        _services = [];
    }

    public virtual void RegisterService<T>(BaseLogic<T> service)
        where T : IPoco
    {
        _services.Add(service);
    }

    public virtual void RegisterService<T, I>(AbstractValidatedPocoCRUDService<T, I> service)
    {
        _services.Add(service);
    }

    public virtual BaseLogic<T> CreateIPocoService<T>()
        where T : IPoco
    {
        return (GetService(typeof(BaseLogic<T>)) as BaseLogic<T>)!;
    }

    public virtual AbstractValidatedPocoCRUDService<T, I> CreateService<T, I>()
    {
        return (GetService(typeof(AbstractValidatedPocoCRUDService<T, I>)) as AbstractValidatedPocoCRUDService<T, I>)!;
    }

    public object? GetService(Type serviceType)
    {
        object? service = _services.FirstOrDefault(s => s.GetType() == serviceType);
        return service ?? throw new Exception($"No available service for type {nameof(serviceType)}");
    }
}
