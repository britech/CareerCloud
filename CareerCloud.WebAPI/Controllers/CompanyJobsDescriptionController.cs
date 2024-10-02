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

public class CompanyJobsDescriptionController : IPocoCrudController<CompanyJobDescriptionPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyJobsDescriptionController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyJobsDescriptionController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Remove a series of job descriptions.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of job descriptions removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteCompanyJobsDescription(
        [SwaggerRequestBody(Description = "The job descriptions to remove", Required = true)] CompanyJobDescriptionPoco[] jobDescriptions) => Delete(jobDescriptions);

    [SwaggerOperation(Summary = "Retrieve the job description", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "The job description", typeof(CompanyJobDescriptionPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Job description is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyJobsDescription(
        [SwaggerParameter(Description = "The description ID", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of job descriptions.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of job descriptions added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostCompanyJobsDescription(
        [SwaggerRequestBody(Description = "The job descriptions to add", Required = true)]  CompanyJobDescriptionPoco[] jobDescriptions) => Add(jobDescriptions);

    [SwaggerOperation(Summary = "Update a series of job descriptions.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of job descriptions updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutCompanyJobsDescription(
        [SwaggerRequestBody(Description = "The job descriptions to update", Required = true)] CompanyJobDescriptionPoco[] jobDescriptions) => Update(jobDescriptions);

    [SwaggerOperation(Summary = "List all job descriptions for all jobs", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "All job descriptions for all jobs", typeof(List<CompanyJobDescriptionPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Job descriptions is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
