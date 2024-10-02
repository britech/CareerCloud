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

public class ApplicantWorkHistoryController : IPocoCrudController<ApplicantWorkHistoryPoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantWorkHistoryController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public ApplicantWorkHistoryController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Remove a series of applicant's work histories.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Applicant's work histories removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteApplicantWorkHistory(
        [SwaggerRequestBody(Description = "The work histories to remove.", Required = true)] ApplicantWorkHistoryPoco[] workHistories) => Delete(workHistories);

    [SwaggerOperation(Summary = "Retrieve the applicant's work history.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The applicant's work history.", typeof(ApplicantWorkHistoryPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Work history is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantWorkHistory(
        [SwaggerParameter(Description = "The work history reference ID.", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of applicant's work histories.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Applicant's work histories removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostApplicantWorkHistory(
        [SwaggerRequestBody(Description = "The work histories to add.")] ApplicantWorkHistoryPoco[] workHistories) => Add(workHistories);

    [SwaggerOperation(Summary = "Update a series of applicant's work histories.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Applicant's work histories removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutApplicantWorkHistory(
        [SwaggerRequestBody(Description = "The work histories to update.", Required = true)] ApplicantWorkHistoryPoco[] workHistories) => Update(workHistories);

    [SwaggerOperation(Summary = "List all work history of all applicants.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "All work history of all applicants", typeof(List<ApplicantWorkHistoryPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Work histories is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
