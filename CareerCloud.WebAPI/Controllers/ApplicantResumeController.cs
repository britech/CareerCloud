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

public class ApplicantResumeController : IPocoCrudController<ApplicantResumePoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantResumeController(BaseLogic<ApplicantResumePoco> service) : base(service)
    {

    }

    public ApplicantResumeController()
        : this(new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Remove resumes.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Resumes removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteApplicantResume(
        [SwaggerRequestBody(Description = "The resumes to remove.", Required = true)] ApplicantResumePoco[] resumes) => Delete(resumes);

    [SwaggerOperation(Summary = "Retrieve the resume", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The resume.", typeof(ApplicantResumePoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Applicant profile is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantResume(
        [SwaggerParameter(Description = "The reference ID of the resume.", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add resumes", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Resumes removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostApplicantResume(
        [SwaggerRequestBody(Description = "The resumes to add.", Required = true)] ApplicantResumePoco[] resumes) => Add(resumes);

    [SwaggerOperation(Summary = "Update resumes.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Resumes removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutApplicantResume(
        [SwaggerRequestBody(Description = "The resumes to update.", Required = true)] ApplicantResumePoco[] resumes) => Update(resumes);

    [SwaggerOperation(Summary = "List resumes.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The profiles", typeof(List<ApplicantResumePoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Resumes is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
