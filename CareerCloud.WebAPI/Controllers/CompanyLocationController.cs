using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyLocationController : IPocoCrudController<CompanyLocationPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyLocationController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyLocationController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteCompanyLocation(CompanyLocationPoco[] locations)
    {
        return Delete(locations);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyLocation(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostCompanyLocation(CompanyLocationPoco[] locations)
    {
        return Add(locations);
    }

    [HttpPut]
    public ActionResult PutCompanyLocation(CompanyLocationPoco[] locations)
    {
        return Update(locations);
    }
}
