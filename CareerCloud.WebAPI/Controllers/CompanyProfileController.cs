using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyProfileController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult GetCompanyProfile(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
    {
        throw new NotImplementedException();
    }
}
