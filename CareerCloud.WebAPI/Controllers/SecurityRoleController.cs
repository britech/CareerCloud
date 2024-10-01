using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class SecurityRoleController : IPocoCrudController<SecurityRolePoco>
{
    [ActivatorUtilitiesConstructor]
    public SecurityRoleController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public SecurityRoleController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteSecurityRole(SecurityRolePoco[] roles)
    {
        return Delete(roles);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSecurityRole(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostSecurityRole(SecurityRolePoco[] roles)
    {
        return Add(roles);
    }

    [HttpPut]
    public ActionResult PutSecurityRole(SecurityRolePoco[] roles)
    {
        return Update(roles);
    }
}
