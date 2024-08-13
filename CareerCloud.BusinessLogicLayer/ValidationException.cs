namespace CareerCloud.BusinessLogicLayer;

public class ValidationException(int code, string message) : Exception(message)
{
    public int Code { get; init; } = code;
}
