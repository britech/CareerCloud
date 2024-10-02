using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class BusinessLogicFactory
{
    private readonly Dictionary<Type, object> _services = [];

    public virtual void RegisterService<T>(BaseLogic<T> service)
        where T : IPoco
    {
        _services.TryAdd(typeof(T), service);
    }

    public virtual void RegisterService<T, I>(AbstractValidatedPocoCRUDService<T, I> service)
    {
        _services.TryAdd(typeof(T), service);
    }

    public virtual BaseLogic<T> CreateIPocoService<T>()
        where T : IPoco
    {
        return (GetService(typeof(T)) as BaseLogic<T>)!;
    }

    public virtual AbstractValidatedPocoCRUDService<T, I> CreateService<T, I>()
    {
        return (GetService(typeof(T)) as AbstractValidatedPocoCRUDService<T, I>)!;
    }

    private object? GetService(Type type)
    {
        object? service = _services[type];
        return service ?? throw new Exception($"No available service for type {nameof(type)}");
    }
}
