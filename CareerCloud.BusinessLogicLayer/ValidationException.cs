namespace CareerCloud.BusinessLogicLayer;

public class ValidationException : Exception
{
    public int Code { get; init; }

    public ValidationException(string message, int code) : base(message)
    { 
        this.Code = code;
    }
}
