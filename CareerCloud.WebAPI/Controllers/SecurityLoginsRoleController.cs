using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class SecurityLoginsRoleController : IPocoCrudController<SecurityLoginsRolePoco>
{
    [ActivatorUtilitiesConstructor]
    public SecurityLoginsRoleController(BusinessLogicFactory factory) : base(factory)
    {
    }
    
    public SecurityLoginsRoleController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteSecurityLoginRole(SecurityLoginsRolePoco[] userRoles)
    {
        return Delete(userRoles);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSecurityLoginsRole(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostSecurityLoginRole(SecurityLoginsRolePoco[] userRoles)
    {
        return Add(userRoles);
    }
}
