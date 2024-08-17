namespace CareerCloud.BusinessLogicLayer;

public class PocoValidationRule<TPoco>(Predicate<TPoco> rule, ValidationException validationException)
{
    public Predicate<TPoco> Rule { private get; init; } = rule;
    public ValidationException ValidationException { private get; init; } = validationException;

    public ValidationException Validate(TPoco item)
    {
        return Rule(item) ? null! : ValidationException;
    }
}
