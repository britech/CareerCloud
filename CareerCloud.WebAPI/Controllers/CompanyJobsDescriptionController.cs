using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class CompanyJobsDescriptionController : IPocoCrudController<CompanyJobDescriptionPoco>
{
    [ActivatorUtilitiesConstructor]
    public CompanyJobsDescriptionController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public CompanyJobsDescriptionController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteCompanyJobsDescription(CompanyJobDescriptionPoco[] jobDescriptions)
    {
        return Delete(jobDescriptions);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetCompanyJobsDescription(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostCompanyJobsDescription(CompanyJobDescriptionPoco[] jobDescriptions)
    {
        return Add(jobDescriptions);
    }

    [HttpPut]
    public ActionResult PutCompanyJobsDescription(CompanyJobDescriptionPoco[] jobDescriptions)
    {
        return Update(jobDescriptions);
    }
}
