using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityLoginsLogController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetSecurityLoginLog(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutSecurityLoginLog(SecurityLoginsLogPoco[] securityLoginsLogPocos)
    {
        throw new NotImplementedException();
    }
}
