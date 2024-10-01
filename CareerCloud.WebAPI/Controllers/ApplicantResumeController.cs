using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class ApplicantResumeController : IPocoCrudController<ApplicantResumePoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantResumeController(BusinessLogicFactory factory) : base(factory)
    {

    }

    public ApplicantResumeController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteApplicantResume(ApplicantResumePoco[] resumes)
    {
        return Delete(resumes);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantResume(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostApplicantResume(ApplicantResumePoco[] resumes)
    {
        return Add(resumes);
    }

    [HttpPut]
    public ActionResult PutApplicantResume(ApplicantResumePoco[] resumes)
    {
        return Update(resumes);
    }
}
