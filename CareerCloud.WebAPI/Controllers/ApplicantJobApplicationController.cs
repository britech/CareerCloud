using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantJobApplicationController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetApplicantJobApplication(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
    {
        throw new NotImplementedException();
    }
}
