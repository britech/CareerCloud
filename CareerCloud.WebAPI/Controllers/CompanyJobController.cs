using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyJobController : ControllerBase
{
    [HttpDelete]
    public OkObjectResult DeleteCompanyJob(CompanyJobPoco[] companyJobPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetCompanyJob(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostCompanyJob(CompanyJobPoco[] companyJobPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutCompanyJob(CompanyJobPoco[] companyJobPocos)
    {
        throw new NotImplementedException();
    }
}
