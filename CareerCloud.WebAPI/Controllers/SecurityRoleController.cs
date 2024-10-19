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

public class SecurityRoleController : IPocoCrudController<SecurityRolePoco>
{
    [ActivatorUtilitiesConstructor]
    public SecurityRoleController(BaseLogic<SecurityRolePoco> service) : base(service)
    {
    }

    public SecurityRoleController()
        : this(new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Remove a security roles", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Security roles removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteSecurityRole(
        [SwaggerRequestBody(Description = "The roles to remove.", Required = true)] SecurityRolePoco[] roles) => Delete(roles);

    [SwaggerOperation(Summary = "Retrieve the security role.", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "The role", typeof(SecurityRolePoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User role is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSecurityRole(
        [SwaggerParameter(Description = "The role ID", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add security roles", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Roles added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostSecurityRole(
        [SwaggerRequestBody(Description = "The roles to add.", Required = true)] SecurityRolePoco[] roles) => Add(roles);

    [SwaggerOperation(Summary = "Update security roles", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "Roles updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutSecurityRole(
        [SwaggerRequestBody(Description = "The roles to update.", Required = true)] SecurityRolePoco[] roles) => Update(roles);

    [SwaggerOperation(Summary = "List all roles", Tags = [TagNames.TAG_SYSTEM])]
    [SwaggerResponse(StatusCodes.Status200OK, "All roles", typeof(List<SecurityRolePoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "User-Role links is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
