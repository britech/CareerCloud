using CareerCloud.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Core;

[Route("api/careercloud/v1/[controller]")]
[ApiController]
public abstract class AbstractCrudController<T, I>(BusinessLogicFactory factory) : ControllerBase
{
    public BusinessLogicFactory Factory { get; init; } = factory;

    [NonAction]
    protected abstract ActionResult FindById(I id);

    [HttpGet]
    public abstract ActionResult FindAll();

    [NonAction]
    protected abstract ActionResult Add(T[] items);

    [NonAction]
    protected abstract ActionResult Update(T[] items);

    [NonAction]
    protected abstract ActionResult Delete(T[] items);

    [NonAction]
    protected virtual ActionResult Save(Action<T[]> action, T[] items)
    {
        try
        {
            action.Invoke(items);
            return Ok();
        }
        catch (AggregateException ex)
        {
            if (ex.InnerExceptions.All(e => e is ValidationException))
                return BuildValidationFault(ex);
            else
                throw;
        }
        catch (Exception ex)
        {
            return BuildGeneralFault(ex);
        }
    }

    [NonAction]
    protected virtual ActionResult FindById(Func<I, T> func, I id)
    {
        try
        {
            T result = func.Invoke(id);
            return result == null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            return BuildGeneralFault(ex);
        }
    }

    [NonAction]
    protected virtual ActionResult FindAll(Func<T[]> func)
    {
        try
        {
            T[] results = func.Invoke();
            return results == null || results.Length == 0 ? NoContent() : Ok(results);
        }
        catch (Exception ex)
        {
            return BuildGeneralFault(ex);
        }
    }

    protected virtual ObjectResult BuildGeneralFault(Exception ex)
    {
        return BuildApiFault(new ProblemDetails()
        {
            Title = "API Fault",
            Detail = "Contact support for assistance",
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://atc.dev/careercloud/contact-us",
            Extensions =
            {
                { "ErrorMessage", ex.Message }
            }
        });
    }

    protected virtual ObjectResult BuildValidationFault(AggregateException ex)
    {
        Dictionary<int, string> violatedRules = [];
        foreach (var entry in ex.InnerExceptions)
        {
            violatedRules.TryAdd(((ValidationException)entry).Code, ((ValidationException)entry).Message);
        }

        return BuildApiFault(new ProblemDetails()
        {
            Title = "Invalid inputs detected.",
            Detail = "Refer to the API reference to resolve the violated input rules.",
            Status = StatusCodes.Status400BadRequest,
            Type = "https://atc.dev/careercloud/api-reference",
            Extensions =
            {
                { "ViolatedRules", violatedRules }
            }
        });
    }

    protected virtual ObjectResult BuildApiFault(ProblemDetails problem)
    {
        return new ObjectResult(problem)
        {
            StatusCode = problem.Status
        };
    }
}
