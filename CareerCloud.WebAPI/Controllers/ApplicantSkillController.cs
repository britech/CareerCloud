using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class ApplicantSkillController : IPocoCrudController<ApplicantSkillPoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantSkillController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public ApplicantSkillController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteApplicantSkill(ApplicantSkillPoco[] skills)
    {
        return Delete(skills);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantSkill(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostApplicantSkill(ApplicantSkillPoco[] skills)
    {
        return Add(skills);
    }

    [HttpPut]
    public ActionResult PutApplicantSkill(ApplicantSkillPoco[] skills)
    {
        return Update(skills);
    }
}
