using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class ApplicantWorkHistoryController : IPocoCrudController<ApplicantWorkHistoryPoco>
{
    [ActivatorUtilitiesConstructor]
    public ApplicantWorkHistoryController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public ApplicantWorkHistoryController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteApplicantWorkHistory(ApplicantWorkHistoryPoco[] workHistories)
    {
        return Delete(workHistories);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetApplicantWorkHistory(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostApplicantWorkHistory(ApplicantWorkHistoryPoco[] workHistories)
    {
        return Add(workHistories);
    }

    [HttpPut]
    public ActionResult PutApplicantWorkHistory(ApplicantWorkHistoryPoco[] workHistories)
    {
        return Update(workHistories);
    }
}
