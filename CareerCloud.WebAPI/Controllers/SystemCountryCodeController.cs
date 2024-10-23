using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Constants;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Examples;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace CareerCloud.WebAPI.Controllers;

public class SystemCountryCodeController : BaseCrudController<SystemCountryCodePoco, string>
{
    [ActivatorUtilitiesConstructor]
    public SystemCountryCodeController(AbstractValidatedPocoCRUDService<SystemCountryCodePoco, string> service) : base(service)
    {

    }

    public SystemCountryCodeController()
        : this(new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Add countries", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Countries added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostSystemCountryCode(
        [SwaggerRequestBody(Description = "The countries to add.", Required = true)] SystemCountryCodePoco[] items) => Add(items);

    [SwaggerOperation(Summary = "Retrieve country info", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "The info", typeof(SystemCountryCodePoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Info is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{code}")]
    public ActionResult GetSystemCountryCode(
        [SwaggerParameter(Description = "The country code", Required = true)] string code) => FindById(code);

    [SwaggerOperation(Summary = "Update countries", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Countries updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutSystemCountryCode(
        [SwaggerRequestBody(Description = "The countries to update.", Required = true)] SystemCountryCodePoco[] items) => Update(items);

    [SwaggerOperation(Summary = "Remove countries", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Countries removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteSystemCountryCode(
        [SwaggerRequestBody(Description = "The countries to remove.", Required = true)] SystemCountryCodePoco[] items) => Delete(items);

    [SwaggerOperation(Summary = "List all countries", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "All countries", typeof(List<SystemCountryCodePoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Countries is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
