using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class ApplicantProfileController : IPocoCrudController<ApplicantProfilePoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantProfileController(BusinessLogicFactory factory) : base(factory)
    {

    }

    public ApplicantProfileController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteApplicantProfile(ApplicantProfilePoco[] profiles)
    {
        return Delete(profiles);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantProfile(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostApplicantProfile(ApplicantProfilePoco[] profiles)
    {
        return Add(profiles);
    }

    [HttpPut]
    public ActionResult PutApplicantProfile(ApplicantProfilePoco[] profiles)
    {
        return Update(profiles);
    }
}
