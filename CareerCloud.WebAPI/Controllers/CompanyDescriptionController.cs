using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyDescriptionController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult GetCompanyDescription(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
    {
        throw new NotImplementedException();
    }
}
