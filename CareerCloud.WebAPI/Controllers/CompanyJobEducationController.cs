using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyJobEducationController : ControllerBase
{
    [HttpDelete]
    public OkObjectResult DeleteCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetCompanyJobEducation(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutCompanyJobEducation(CompanyJobEducationPoco[] companyJobEducationPocos)
    {
        throw new NotImplementedException();
    }
}
