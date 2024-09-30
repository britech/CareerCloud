using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyLocationController : ControllerBase
{
    [HttpDelete]
    public OkObjectResult DeleteCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetCompanyLocation(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
    {
        throw new NotImplementedException();
    }
}
