using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantJobApplicationController : ControllerBase
    {
        public ActionResult DeleteApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetApplicantJobApplication(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutApplicantJobApplication(ApplicantJobApplicationPoco[] applicantJobApplicationPocos)
        {
            throw new NotImplementedException();
        }
    }
}
