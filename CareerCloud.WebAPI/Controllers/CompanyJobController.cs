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

public class CompanyJobController : IPocoCrudController<CompanyJobPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyJobController(BaseLogic<CompanyJobPoco> service) : base(service)
    {
    }

    public CompanyJobController()
        : this(new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Remove a series of posted jobs.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of posted jobs removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteCompanyJob(
        [SwaggerRequestBody(Description = "The posted jobs to be removed.", Required = true)] CompanyJobPoco[] jobs) => Delete(jobs);

    [SwaggerOperation(Summary = "Retrieve the job detail", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "The job detail", typeof(CompanyJobPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Job detail is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyJob(
        [SwaggerParameter(Description = "The job ID.", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Create job entries.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Job entries added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostCompanyJob(
        [SwaggerRequestBody(Description = "The jobs to post.", Required = true)] CompanyJobPoco[] jobs) => Add(jobs);

    [SwaggerOperation(Summary = "Update a series of job entries.", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "Job entries updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutCompanyJob(
        [SwaggerRequestBody(Description = "The posted jobs to update.", Required = true)]  CompanyJobPoco[] jobs) => Update(jobs);

    [SwaggerOperation(Summary = "List all jobs", Tags = [TagNames.TAG_JOBS])]
    [SwaggerResponse(StatusCodes.Status200OK, "All jobs", typeof(List<CompanyJobPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Jobs is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
