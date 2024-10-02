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

public class CompanyJobSkillController : IPocoCrudController<CompanyJobSkillPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyJobSkillController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyJobSkillController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {
    }

    [SwaggerOperation(Summary = "Remove a series of skill requirements.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of skill requirements removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteCompanyJobSkill(
        [SwaggerRequestBody(Description = "The skill requirements to remove", Required = true)] CompanyJobSkillPoco[] skills) => Delete(skills);

    [SwaggerOperation(Summary = "Retrieve the skill requirement entry", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "The skill requirement entry", typeof(CompanyJobSkillPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Skill requirement entry is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyJobSkill(
        [SwaggerParameter(Description = "The requirement ID", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of skill requirements.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of skill requirements added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostCompanyJobSkill(
        [SwaggerRequestBody(Description = "The skill requirements to add", Required = true)] CompanyJobSkillPoco[] skills) => Add(skills);

    [SwaggerOperation(Summary = "Update a series of skill requirements.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of skill requirements updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutCompanyJobSkill(
        [SwaggerRequestBody(Description = "The skill requirements to update", Required = true)]  CompanyJobSkillPoco[] skills) => Update(skills);

    [SwaggerOperation(Summary = "List all skill requirements for all jobs", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "All skill requirements for all jobs", typeof(List<CompanyJobSkillPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Skill requirements is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
