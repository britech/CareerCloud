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

public class SecurityLoginsLogController : IPocoCrudController<SecurityLoginsLogPoco>
{
    [ActivatorUtilitiesConstructor]
    public SecurityLoginsLogController(BaseLogic<SecurityLoginsLogPoco> service) : base(service)
    {
    }

    public SecurityLoginsLogController()
        : this(new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(EFRepositoryFactory.Default.Instance)))
    {

    }

    [SwaggerOperation(Summary = "Remove a series of audit logs", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of logs removed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpDelete]
    public ActionResult DeleteSecurityLoginLog(
        [SwaggerRequestBody(Description = "The logs to remove.", Required = true)] SecurityLoginsLogPoco[] auditLogs) => Delete(auditLogs);

    [SwaggerOperation(Summary = "Retrieve the audit log", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "The log", typeof(SecurityLoginsLogPoco), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Log is not available, ensure ID is correct.", typeof(ExampleNotFoundFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSecurityLoginLog(
        [SwaggerParameter(Description = "The audit ID", Required = true)] Guid id) => FindById(id);

    [SwaggerOperation(Summary = "Add a series of user logs", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of logs added successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPost]
    public ActionResult PostSecurityLoginLog(
        [SwaggerRequestBody(Description = "The logs to add.", Required = true)] SecurityLoginsLogPoco[] auditLogs) => Add(auditLogs);

    [SwaggerOperation(Summary = "Update a series of user logs", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "Series of logs updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Input validation failed, check your entries.", typeof(ExampleValidationFault), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    [Consumes(MediaTypeNames.Application.Json)]
    [HttpPut]
    public ActionResult PutSecurityLoginLog(
        [SwaggerRequestBody(Description = "The logs to update.", Required = true)] SecurityLoginsLogPoco[] auditLogs) => Update(auditLogs);

    [SwaggerOperation(Summary = "List all audit logs", Tags = [TagNames.TAG_USER])]
    [SwaggerResponse(StatusCodes.Status200OK, "All audit logs", typeof(List<SecurityLoginsLogPoco>), [MediaTypeNames.Application.Json])]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Audit logs is empty. If expected not empty, try again later or call support.")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "API Fault occured, try again later or call support.", typeof(ExampleGeneralFault), [MediaTypeNames.Application.Json])]
    public override ActionResult FindAll() => base.FindAll();
}
