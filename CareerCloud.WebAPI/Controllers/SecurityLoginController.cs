using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityLoginController : ControllerBase
    {
        public ActionResult DeleteSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetSecurityLogin(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
        {
            throw new NotImplementedException();
        }
    }
}
