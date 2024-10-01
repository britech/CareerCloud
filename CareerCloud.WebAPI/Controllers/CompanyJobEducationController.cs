using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class CompanyJobEducationController : IPocoCrudController<CompanyJobEducationPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyJobEducationController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyJobEducationController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteCompanyJobEducation(CompanyJobEducationPoco[] educations)
    {
        return Delete(educations);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyJobEducation(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostCompanyJobEducation(CompanyJobEducationPoco[] educations)
    {
        return Add(educations);
    }

    [HttpPut]
    public ActionResult PutCompanyJobEducation(CompanyJobEducationPoco[] educations)
    {
        return Update(educations);
    }
}
