using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantProfileController : ControllerBase
    {
        public ActionResult DeleteApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetApplicantProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutApplicantProfile(ApplicantProfilePoco[] applicantProfilePocos)
        {
            throw new NotImplementedException();
        }
    }
}
