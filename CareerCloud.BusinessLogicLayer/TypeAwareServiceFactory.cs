using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class TypeAwareServiceFactory
{
    private readonly Dictionary<Type, object> services;

    public TypeAwareServiceFactory()
    {
        services = [];
    }

    public virtual void RegisterService<T>(BaseLogic<T> service)
        where T : IPoco
    {
        services.TryAdd(typeof(T), service);
    }

    public virtual void RegisterService<T, I>(AbstractValidatedPocoCRUDService<T, I> service)
    {
        services.TryAdd(typeof(T), service);
    }

    public virtual BaseLogic<T> CreateIPocoService<T>()
        where T : IPoco
    {
        Type type = typeof(T);
        if (services.TryGetValue(type, out object? value))
            return (value as BaseLogic<T>)!;
        else
            throw new Exception($"No available service for type {nameof(type)}");
    }

    public virtual AbstractValidatedPocoCRUDService<T, I> CreateService<T, I>()
    {
        Type type = typeof(T);
        if (services.TryGetValue(type, out object? value))
            return (value as AbstractValidatedPocoCRUDService<T, I>)!;
        else
            throw new Exception($"No available service for type {nameof(type)}");
    }
}
