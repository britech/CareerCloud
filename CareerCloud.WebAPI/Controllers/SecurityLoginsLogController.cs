using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityLoginsLogController : ControllerBase
    {
        public ActionResult DeleteSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetSecurityLoginLog(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
        {
            throw new NotImplementedException();
        }
    }
}
