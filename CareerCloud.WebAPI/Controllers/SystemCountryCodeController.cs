using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class SystemCountryCodeController : BaseCrudController<SystemCountryCodePoco, string>
{
    [ActivatorUtilitiesConstructor]
    public SystemCountryCodeController(BusinessLogicFactory factory) : base(factory)
    {

    }

    public SystemCountryCodeController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpPost]
    public ActionResult PostSystemCountryCode(SystemCountryCodePoco[] items)
    {
        return Add(items);
    }

    [HttpGet]
    [Route("{code}")]
    public ActionResult GetSystemCountryCode(string code)
    {
        return FindById(code);
    }

    [HttpPut]
    public ActionResult PutSystemCountryCode(SystemCountryCodePoco[] items)
    {
        return Update(items);
    }

    [HttpDelete]
    public ActionResult DeleteSystemCountryCode(SystemCountryCodePoco[] items)
    {
        return Delete(items);
    }
}
