using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class CompanyProfileController : IPocoCrudController<CompanyProfilePoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyProfileController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyProfileController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteCompanyProfile(CompanyProfilePoco[] profiles)
    {
        return Delete(profiles);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyProfile(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostCompanyProfile(CompanyProfilePoco[] profiles)
    {
        return Add(profiles);
    }

    [HttpPut]
    public ActionResult PutCompanyProfile(CompanyProfilePoco[] profiles)
    {
        return Update(profiles);
    }
}
