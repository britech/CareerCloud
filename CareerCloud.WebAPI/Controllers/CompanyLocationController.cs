using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Constants;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Examples;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyLocationController : IPocoCrudController<CompanyLocationPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyLocationController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyLocationController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Remove a series of locations", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of locations removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteCompanyLocation(
        [SwaggerRequestBody(Description = "The locations to remove.", Required = true)] CompanyLocationPoco[] locations) => Delete(locations);

    [SwaggerOperation(Summary = "Retrieve the location", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The location", typeof(CompanyLocationPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Location is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyLocation(
        [SwaggerParameter(Description = "The location ID", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of locations", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of locations added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostCompanyLocation(
        [SwaggerRequestBody(Description = "The locations to add.", Required = true)]  CompanyLocationPoco[] locations) => Add(locations);

    [SwaggerOperation(Summary = "Update a series of locations", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of locations updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutCompanyLocation(
        [SwaggerRequestBody(Description = "The locations to update.", Required = true)] CompanyLocationPoco[] locations) => Update(locations);

    [SwaggerOperation(Summary = "List all locations", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "All locations", typeof(List<CompanyLocationPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Locations is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
