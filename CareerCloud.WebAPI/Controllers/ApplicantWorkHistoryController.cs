using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantWorkHistoryController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteApplicantWorkHistory(ApplicantWorkHistoryPoco[] applicantWorkHistoryPocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult GetApplicantWorkHistory(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostApplicantWorkHistory(ApplicantWorkHistoryPoco[] applicantWorkHistoryPocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutApplicantWorkHistory(ApplicantWorkHistoryPoco[] applicantWorkHistoryPocos)
    {
        throw new NotImplementedException();
    }
}
