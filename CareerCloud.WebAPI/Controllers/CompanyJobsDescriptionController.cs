using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyJobsDescriptionController : ControllerBase
{
    [HttpDelete]
    public OkObjectResult DeleteCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetCompanyJobsDescription(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
    {
        throw new NotImplementedException();
    }
}
