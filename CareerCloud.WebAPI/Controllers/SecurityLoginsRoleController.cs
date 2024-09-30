using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityLoginsRoleController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteSecurityLoginRole(SecurityLoginsRolePoco[] securityLoginsRolePocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetSecurityLoginsRole(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostSecurityLoginRole(SecurityLoginsRolePoco[] securityLoginsRolePocos)
    {
        throw new NotImplementedException();
    }
}
