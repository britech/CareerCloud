using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class ApplicantJobApplicationController : IPocoCrudController<ApplicantJobApplicationPoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantJobApplicationController(BusinessLogicFactory factory) : base(factory)
    {

    }

    public ApplicantJobApplicationController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteApplicantJobApplication(ApplicantJobApplicationPoco[] jobApplications)
    {
        return Delete(jobApplications);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantJobApplication(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostApplicantJobApplication(ApplicantJobApplicationPoco[] jobApplications)
    {
        return Add(jobApplications);
    }

    [HttpPut]
    public ActionResult PutApplicantJobApplication(ApplicantJobApplicationPoco[] jobApplications)
    {
        return Update(jobApplications);
    }
}
