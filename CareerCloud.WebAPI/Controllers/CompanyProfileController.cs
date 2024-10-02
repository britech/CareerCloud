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

public class CompanyProfileController : IPocoCrudController<CompanyProfilePoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyProfileController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyProfileController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Remove a series of profiles", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of profiles removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteCompanyProfile(
        [SwaggerRequestBody(Description = "The profiles to remove.", Required = true)] CompanyProfilePoco[] profiles) => Delete(profiles);

    [SwaggerOperation(Summary = "Retrieve the profile", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The profile", typeof(CompanyProfilePoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Profile is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyProfile(
        [SwaggerParameter(Description = "The profile ID", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of profiles", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of profiles added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostCompanyProfile(
        [SwaggerRequestBody(Description = "The profiles to add.", Required = true)]  CompanyProfilePoco[] profiles) => Add(profiles);

    [SwaggerOperation(Summary = "Update a series of profiles", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of profiles updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutCompanyProfile(
        [SwaggerRequestBody(Description = "The profiles to update.", Required = true)]  CompanyProfilePoco[] profiles) => Update(profiles);

    [SwaggerOperation(Summary = "List all profiles", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "All profiles", typeof(List<CompanyProfilePoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Profiles is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
