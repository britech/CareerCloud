using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantResumeController : ControllerBase
    {
        public ActionResult DeleteApplicantResume(ApplicantResumePoco[] applicantResumePocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetApplicantResume(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostApplicantResume(ApplicantResumePoco[] applicantResumePocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutApplicantResume(ApplicantResumePoco[] applicantResumePocos)
        {
            throw new NotImplementedException();
        }
    }
}
