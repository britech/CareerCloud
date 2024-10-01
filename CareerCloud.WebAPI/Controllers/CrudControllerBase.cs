using CareerCloud.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/careercloud/v1/[controller]")]
[ApiController]
public class CrudControllerBase<T, I> : ControllerBase
{
    [NonAction]
    public virtual ActionResult Modify(Action<T[]> action, T[] items)
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
    public virtual ActionResult Query(Func<I, T> func, I id)
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

    private static ObjectResult BuildGeneralFault(Exception ex)
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

    private static ObjectResult BuildValidationFault(AggregateException ex)
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

    private static ObjectResult BuildApiFault(ProblemDetails problem)
    {
        return new ObjectResult(problem)
        {
            StatusCode = problem.Status
        };
    }
}
