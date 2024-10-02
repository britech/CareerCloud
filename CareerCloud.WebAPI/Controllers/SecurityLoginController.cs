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

public class SecurityLoginController : IPocoCrudController<SecurityLoginPoco>
{
    [ActivatorUtilitiesConstructor]
    public SecurityLoginController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public SecurityLoginController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [SwaggerOperation(Summary = "Remove a series of login users", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of users removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteSecurityLogin(
        [SwaggerRequestBody(Description = "The users to remove.", Required = true)] SecurityLoginPoco[] users)
    {
        return Delete(users);
    }

    [SwaggerOperation(Summary = "Retrieve the user profile", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "The profile", typeof(SecurityLoginPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Profile is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSecurityLogin(
        [SwaggerParameter(Description = "The User ID", Required = true)] Guid id)
    {
        return FindById(id);
    }

    [SwaggerOperation(Summary = "Add a series of user profiles", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of profiles added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostSecurityLogin(
        [SwaggerRequestBody(Description = "The users to add.", Required = true)]  SecurityLoginPoco[] users)
    {
        return Add(users);
    }

    [SwaggerOperation(Summary = "Update a series of user profiles", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of profiles updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutSecurityLogin(
        [SwaggerRequestBody(Description = "The users to update.", Required = true)] SecurityLoginPoco[] users)
    {
        return Update(users);
    }

    [SwaggerOperation(Summary = "List all profiles", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "All profiles", typeof(List<SecurityLoginPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Profiles is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
