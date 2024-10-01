using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class CompanyJobSkillController : IPocoCrudController<CompanyJobSkillPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyJobSkillController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyJobSkillController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {
    }

    [HttpDelete]
    public ActionResult DeleteCompanyJobSkill(CompanyJobSkillPoco[] skills)
    {
        return Delete(skills);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyJobSkill(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostCompanyJobSkill(CompanyJobSkillPoco[] skills)
    {
        return Add(skills);
    }

    [HttpPut]
    public ActionResult PutCompanyJobSkill(CompanyJobSkillPoco[] skills)
    {
        return Update(skills);
    }
}
