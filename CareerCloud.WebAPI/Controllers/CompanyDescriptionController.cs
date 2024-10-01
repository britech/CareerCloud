using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class CompanyDescriptionController : IPocoCrudController<CompanyDescriptionPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyDescriptionController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyDescriptionController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
    {
        return Delete(companyDescriptionPocos);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyDescription(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostCompanyDescription(CompanyDescriptionPoco[] descriptions)
    {
        return Add(descriptions);
    }

    [HttpPut]
    public ActionResult PutCompanyDescription(CompanyDescriptionPoco[] descriptions)
    {
        return Update(descriptions);
    }
}
