using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityRoleController : ControllerBase
    {
        public ActionResult DeleteSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetSecurityRole(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutSecurityRole(SecurityRolePoco[] securityRolePocos)
        {
            throw new NotImplementedException();
        }
    }
}
