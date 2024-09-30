using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantSkillController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteApplicantSkill(ApplicantSkillPoco[] applicantSkillPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetApplicantSkill(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostApplicantSkill(ApplicantSkillPoco[] applicantSkillPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutApplicantSkill(ApplicantSkillPoco[] applicantSkillPocos)
    {
        throw new NotImplementedException();
    }
}
