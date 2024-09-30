using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantResumeController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteApplicantResume(ApplicantResumePoco[] applicantResumePocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetApplicantResume(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostApplicantResume(ApplicantResumePoco[] applicantResumePocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutApplicantResume(ApplicantResumePoco[] applicantResumePocos)
    {
        throw new NotImplementedException();
    }
}
