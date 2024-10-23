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

public class ApplicantEducationController : IPocoCrudController<ApplicantEducationPoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantEducationController(BaseLogic<ApplicantEducationPoco> service) : base(service)
    {

    }

    public ApplicantEducationController()
        : this(new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Add a series of applicant's education history.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Education History entries are successfully added.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostApplicantEducation(
        [SwaggerRequestBody(Description = "The education history entries to be added.", Required = true)] ApplicantEducationPoco[] educations) => Add(educations);

    [SwaggerOperation(Summary = "Get an applicant's education history entry.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The applicant's education history entry", typeof(ApplicantEducationPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Applicant's education history entry is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantEducation(
        [SwaggerParameter(Description = "The reference id of the applicant's education history entry.", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Update a series of applicant's education.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Education History entries are successfully updated.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutApplicantEducation(
        [SwaggerRequestBody(Description = "The education history entries to be updated.", Required = true)] ApplicantEducationPoco[] educations) => Update(educations);

    [SwaggerOperation(Summary = "Delete a series of applicant's education history", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Education History entries are successfully removed.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteApplicantEducation(
        [SwaggerRequestBody(Description = "The education history entries to be removed.", Required = true)] ApplicantEducationPoco[] educations) => Delete(educations);

    [SwaggerOperation(Summary = "Lists all education history of all applicants.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The application history entries of all applicants", typeof(List<ApplicantEducationPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Applicant education history entries is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
