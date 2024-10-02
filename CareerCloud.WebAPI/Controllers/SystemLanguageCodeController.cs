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

public class SystemLanguageCodeController : BaseCrudController<SystemLanguageCodePoco, string>
{
    [ActivatorUtilitiesConstructor]
    public SystemLanguageCodeController(BusinessLogicFactory factory)
        : base(factory)
    {

    }

    public SystemLanguageCodeController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Add languages", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Languages removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteSystemLanguageCode(
        [SwaggerRequestBody(Description = "The languages to remove", Required = true)] SystemLanguageCodePoco[] items) => Delete(items);

    [SwaggerOperation(Summary = "Retrieve language info", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "The info", typeof(SystemLanguageCodePoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Info is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSystemLanguageCode([FromRoute] string id) => FindById(id);

    [SwaggerOperation(Summary = "Add languages", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Languages added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostSystemLanguageCode(
        [SwaggerRequestBody(Description = "The languages to add", Required = true)] SystemLanguageCodePoco[] items) => Add(items);

    [SwaggerOperation(Summary = "Update languages", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Languages updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutSystemLanguageCode(
        [SwaggerRequestBody(Description = "The languages to update", Required = true)] SystemLanguageCodePoco[] items) => Update(items);

    [SwaggerOperation(Summary = "List all languages", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "All languages", typeof(List<SystemLanguageCodePoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Languages is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
