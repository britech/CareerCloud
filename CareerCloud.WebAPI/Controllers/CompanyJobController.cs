using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class CompanyJobController : IPocoCrudController<CompanyJobPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyJobController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyJobController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteCompanyJob(CompanyJobPoco[] jobs)
    {
        return Delete(jobs);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyJob(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostCompanyJob(CompanyJobPoco[] jobs)
    {
        return Add(jobs);
    }

    [HttpPut]
    public ActionResult PutCompanyJob(CompanyJobPoco[] jobs)
    {
        return Update(jobs);
    }
}
