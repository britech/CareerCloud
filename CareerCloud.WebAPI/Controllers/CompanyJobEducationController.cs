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

public class CompanyJobEducationController : IPocoCrudController<CompanyJobEducationPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyJobEducationController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyJobEducationController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Remove a series of education requirements.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of education requirements removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteCompanyJobEducation(
        [SwaggerRequestBody(Description = "The requirements to remove.", Required = true)] CompanyJobEducationPoco[] educations) => Delete(educations);

    [SwaggerOperation(Summary = "Retrieve the education requirement entry", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "The education requirement", typeof(CompanyJobEducationPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Education requirement is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyJobEducation(
        [SwaggerParameter(Description = "The requirement ID.", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of education requirements.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of education requirements added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostCompanyJobEducation(
        [SwaggerRequestBody(Description = "The requirements to add.", Required = true)] CompanyJobEducationPoco[] educations) => Add(educations);

    [SwaggerOperation(Summary = "Update a series of education requirements.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of educationr requirements updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutCompanyJobEducation(
        [SwaggerRequestBody(Description = "The requirements to update", Required = true)] CompanyJobEducationPoco[] educations) => Update(educations);

    [SwaggerOperation(Summary = "List all education requirements for all jobs", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "All education requirements for all jobs", typeof(List<CompanyJobEducationPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Education requirements is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
