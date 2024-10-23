namespace CareerCloud.EntityFrameworkDataAccess.Exceptions;

public class EntityNotFoundException(string entityName, object id) : Exception
{
    public string EntityName { get; init; } = entityName;
    public object Id { get; init; } = id;
}
