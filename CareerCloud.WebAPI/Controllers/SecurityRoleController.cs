using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityRoleController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteSecurityRole(SecurityRolePoco[] securityRolePocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetSecurityRole(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostSecurityRole(SecurityRolePoco[] securityRolePocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutSecurityRole(SecurityRolePoco[] securityRolePocos)
    {
        throw new NotImplementedException();
    }
}
