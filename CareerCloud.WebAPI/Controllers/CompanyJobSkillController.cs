using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyJobSkillController : ControllerBase
{
    [HttpDelete]
    public OkObjectResult DeleteCompanyJobSkill(CompanyJobSkillPoco[] companyJobSkillPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetCompanyJobSkill(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostCompanyJobSkill(CompanyJobSkillPoco[] companyJobSkillPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutCompanyJobSkill(CompanyJobSkillPoco[] companyJobSkillPocos)
    {
        throw new NotImplementedException();
    }
}
