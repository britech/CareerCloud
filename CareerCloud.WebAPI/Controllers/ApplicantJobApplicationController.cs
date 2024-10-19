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

public class ApplicantJobApplicationController : IPocoCrudController<ApplicantJobApplicationPoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantJobApplicationController(BaseLogic<ApplicantJobApplicationPoco> service) : base(service)
    {

    }

    public ApplicantJobApplicationController()
        : this(new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Withdraw a series of job applications.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Job applications successfully withdrawn.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteApplicantJobApplication(
        [SwaggerRequestBody(Description = "The job applications to be withdrawn.", Required = true)] ApplicantJobApplicationPoco[] jobApplications) => Delete(jobApplications);

    [SwaggerOperation(Summary = "Retrieve job application details", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "The job application details", typeof(ApplicantJobApplicationPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Applicant's job application details is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantJobApplication(
        [SwaggerParameter(Description = "The reference ID of the job application.", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Record a series of job applications.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Job applications successfully recorded.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostApplicantJobApplication(
        [SwaggerRequestBody(Description = "The job applications to record.", Required = true)] ApplicantJobApplicationPoco[] jobApplications) => Add(jobApplications);

    [SwaggerOperation(Summary = "Update a series of job applications.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Job applications successfully updated.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutApplicantJobApplication(
        [SwaggerRequestBody(Description = "The job applications to update.", Required = true)] ApplicantJobApplicationPoco[] jobApplications) => Update(jobApplications);

    [SwaggerOperation(Summary = "List the job applications", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "The job applications", typeof(List<ApplicantJobApplicationPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Job applications is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
