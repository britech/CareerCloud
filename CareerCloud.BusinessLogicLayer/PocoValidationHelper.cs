namespace CareerCloud.BusinessLogicLayer;

public class PocoValidationHelper
{
    public static void Validate<TPoco>(PocoValidationRule<TPoco>[] rules, TPoco[] items)
    {
        List<ValidationException> validationExceptions = [];

        foreach (TPoco item in items)
        {
            foreach(PocoValidationRule<TPoco> rule in rules)
            {
                ValidationException result = rule.Validate(item);
                if (result != null)
                {
                    validationExceptions.Add(result);
                }
            }
        }

        if (validationExceptions.Count > 0)
        {
            throw new AggregateException(validationExceptions);
        }
    }
}
