using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class SecurityLoginsLogController : IPocoCrudController<SecurityLoginsLogPoco>
{
    [ActivatorUtilitiesConstructor]
    public SecurityLoginsLogController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public SecurityLoginsLogController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteSecurityLoginLog(SecurityLoginsLogPoco[] auditLogs)
    {
        return Delete(auditLogs);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSecurityLoginLog(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostSecurityLoginLog(SecurityLoginsLogPoco[] auditLogs)
    {
        return Add(auditLogs);
    }

    [HttpPut]
    public ActionResult PutSecurityLoginLog(SecurityLoginsLogPoco[] auditLogs)
    {
        return Update(auditLogs);
    }
}
