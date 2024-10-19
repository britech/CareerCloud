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

public class SecurityLoginsRoleController : IPocoCrudController<SecurityLoginsRolePoco>
{
    [ActivatorUtilitiesConstructor]
    public SecurityLoginsRoleController(BaseLogic<SecurityLoginsRolePoco> service) : base(service)
    {
    }
    
    public SecurityLoginsRoleController()
        : this(new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Unlink user roles", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "User roles unlinked successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteSecurityLoginRole(
        [SwaggerRequestBody(Description = "The roles to unlink", Required = false)] SecurityLoginsRolePoco[] userRoles) => Delete(userRoles);

    [SwaggerOperation(Summary = "Retrieve the user role", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "The user role", typeof(SecurityLoginsRolePoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User role is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSecurityLoginsRole(
        [SwaggerParameter(Description = "The link ID.", Required = false)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Link user roles", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "User roles linked successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostSecurityLoginRole(
        [SwaggerRequestBody(Description = "The roles to link", Required = false)] SecurityLoginsRolePoco[] userRoles) => Add(userRoles);

    [SwaggerOperation(Summary = "List all roles for all users", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "All roles for all users", typeof(List<SecurityLoginsRolePoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "User-Role links is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
