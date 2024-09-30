using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityLoginController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetSecurityLogin(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutSecurityLogin(SecurityLoginPoco[] securityLoginPocos)
    {
        throw new NotImplementedException();
    }
}
