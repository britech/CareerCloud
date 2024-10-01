using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class ApplicantEducationController : IPocoCrudController<ApplicantEducationPoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantEducationController(BusinessLogicFactory factory) : base(factory)
    {

    }

    public ApplicantEducationController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpPost]
    public ActionResult PostApplicantEducation(ApplicantEducationPoco[] educations)
    {
        return Add(educations);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantEducation(Guid id)
    {
        return FindById(id);
    }

    [HttpPut]
    public ActionResult PutApplicantEducation(ApplicantEducationPoco[] educations)
    {
        return Update(educations);
    }

    [HttpDelete]
    public ActionResult DeleteApplicantEducation(ApplicantEducationPoco[] educations)
    {
        return Delete(educations);
    }
}
