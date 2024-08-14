namespace CareerCloud.BusinessLogicLayer;

public class PocoValidationHelper
{
    public static void Verify<TPoco>(Func<TPoco, List<ValidationException>> validationFunc, TPoco[] items) 
    {
        List<ValidationException> validationErrors = [];
        foreach (var item in items) { 
            List<ValidationException> errors = validationFunc(item);
            if (errors?.Count > 0)
            {
                validationErrors.AddRange(errors);
            }
        }

        if (validationErrors.Count > 0)
        {
            throw new AggregateException(validationErrors);
        }
    }
}
