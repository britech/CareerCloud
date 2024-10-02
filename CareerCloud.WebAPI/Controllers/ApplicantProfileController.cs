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

public class ApplicantProfileController : IPocoCrudController<ApplicantProfilePoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantProfileController(BusinessLogicFactory factory) : base(factory)
    {

    }

    public ApplicantProfileController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Remove applicant profiles", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Profiles removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpDelete]
    public ActionResult DeleteApplicantProfile(
        [SwaggerRequestBody(Description = "The profiles to be removed.", Required = true)] ApplicantProfilePoco[] profiles) => Delete(profiles);

    [SwaggerOperation(Summary = "Retrieve the applicant profile", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The applicant profile.", typeof(ApplicantProfilePoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Applicant profile is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantProfile(
        [SwaggerParameter(Description = "The profile ID.", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add applicant profiles.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Profiles created successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpPost]
    public ActionResult PostApplicantProfile(
        [SwaggerRequestBody(Description = "The profiles to be added.", Required = true)] ApplicantProfilePoco[] profiles) => Add(profiles);

    [SwaggerOperation(Summary = "Update applicant profiles.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Profiles updated successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpPut]
    public ActionResult PutApplicantProfile(
        [SwaggerRequestBody(Description = "The applicant profiles to be updated.", Required = true)] ApplicantProfilePoco[] profiles) => Update(profiles);

    [SwaggerOperation(Summary = "List all profiles.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The profiles", typeof(List<ApplicantProfilePoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Profiles is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
