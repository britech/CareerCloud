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

public class ApplicantSkillController : IPocoCrudController<ApplicantSkillPoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantSkillController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public ApplicantSkillController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Remove a series of applicant's skills.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Applicant's skills removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteApplicantSkill(
        [SwaggerRequestBody(Description = "The skils to add.", Required = true)] ApplicantSkillPoco[] skills) => Delete(skills);

    [SwaggerOperation(Summary = "Retrieve the applicant's skill entry.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The applicant's skill entry.", typeof(ApplicantSkillPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Applicant's skill entry is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantSkill(
        [SwaggerParameter(Description = "The ID of the applicant's skill entry.", Required = true)]Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of applicant's skills.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Applicant's skills added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostApplicantSkill(
        [SwaggerRequestBody(Description = "The applicant skills to add.", Required = true)] ApplicantSkillPoco[] skills) => Add(skills);

    [SwaggerOperation(Summary = "Update a series of applicant's skills.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Applicant's skills updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutApplicantSkill(
        [SwaggerRequestBody(Description = "The applicant's skills to update", Required = true)] ApplicantSkillPoco[] skills) => Update(skills);

    [SwaggerOperation(Summary = "List all skills of all applicants.", Tags = [TagNames.TAG_APPLICANT_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "All skills of all applicants", typeof(List<ApplicantSkillPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Skills is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
