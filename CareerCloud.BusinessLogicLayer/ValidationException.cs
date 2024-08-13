namespace CareerCloud.BusinessLogicLayer;

public class ValidationException(string message, int code) : Exception(message)
{
    public int Code { get; init; } = code;
}
