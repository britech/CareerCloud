using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantProfileController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public OkObjectResult GetApplicantProfile(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
    {
        throw new NotImplementedException();
    }
}
