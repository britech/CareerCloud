using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantEducationController : ControllerBase
    {
        private readonly BaseLogic<ApplicantEducationPoco> _logic;

        [ActivatorUtilitiesConstructor]
        public ApplicantEducationController(BaseLogic<ApplicantEducationPoco> logic)
        {
            _logic = logic;
        }

        public ApplicantEducationController()
            : this(new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>()))
        {

        }

        public ActionResult PostApplicantEducation(ApplicantEducationPoco[] applicantEducationPocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetApplicantEducation(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutApplicantEducation(ApplicantEducationPoco[] applicantEducationPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteApplicantEducation(ApplicantEducationPoco[] applicantEducationPocos)
        {
            throw new NotImplementedException();
        }
    }
}
