using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/careercloud/v1/[controller]")]
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

    /// <summary>
    ///     Adds the 
    /// </summary>
    /// <param name="applicantEducationPocos"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] applicantEducationPocos)
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantEducation(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutApplicantEducation(ApplicantEducationPoco[] applicantEducationPocos)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public ActionResult DeleteApplicantEducation(ApplicantEducationPoco[] applicantEducationPocos)
    {
        throw new NotImplementedException();
    }
}
