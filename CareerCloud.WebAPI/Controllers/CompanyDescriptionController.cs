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

public class CompanyDescriptionController : IPocoCrudController<CompanyDescriptionPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyDescriptionController(BaseLogic<CompanyDescriptionPoco> service) : base(service)
    {
    }

    public CompanyDescriptionController()
        : this(new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Remove a series of company descriptions", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of company description removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteCompanyDescription(
        [SwaggerRequestBody(Description = "The company descriptions to remove.", Required = true)] CompanyDescriptionPoco[] companyDescriptionPocos) => Delete(companyDescriptionPocos);

    [SwaggerOperation(Summary = "Retrieve the company description", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "The company description", typeof(CompanyDescriptionPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Description is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyDescription(Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of company descriptions", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Company descriptions added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostCompanyDescription(
        [SwaggerRequestBody(Description = "The company descriptions to add.", Required = true)]CompanyDescriptionPoco[] descriptions) => Add(descriptions);

    [SwaggerOperation(Summary = "Update a series of company descriptions", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "Company descriptions updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutCompanyDescription(
        [SwaggerRequestBody(Description = "The company description to update.", Required = true)] CompanyDescriptionPoco[] descriptions) => Update(descriptions);

    [SwaggerOperation(Summary = "List all company descriptions", Tags = [TagNames.TAG_COMPANY_PROFILE])]
    [SwaggerResponse(StatusCodes.Status200OK, "All company descriptions", typeof(List<CompanyDescriptionPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Descriptions is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
