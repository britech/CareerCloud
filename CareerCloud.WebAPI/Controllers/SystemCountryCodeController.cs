using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/careercloud/v1/[controller]")]
[ApiController]
public class SystemCountryCodeController : ControllerBase
{
    private readonly AbstractValidatedPocoCRUDService<SystemCountryCodePoco, string> _service;

    [ActivatorUtilitiesConstructor]
    public SystemCountryCodeController(AbstractValidatedPocoCRUDService<SystemCountryCodePoco, string> service)
    {
        _service = service;
    }

    public SystemCountryCodeController()
        : this(new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>()))
    {

    }

    [HttpPost]
    public ActionResult PostSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
    {
        return ControllerHelper.ModifyItems<SystemCountryCodePoco[]>(_service.Add, systemCountryCodePocos);
    }

    [HttpGet]
    public ActionResult GetSystemCountryCode(string code)
    {
        return ControllerHelper.GetItem<string, SystemCountryCodePoco>(_service.Get, code);
    }

    [HttpPut]
    public ActionResult PutSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
    {
        return ControllerHelper.ModifyItems<SystemCountryCodePoco[]>(_service.Update, systemCountryCodePocos);
    }

    [HttpDelete]
    public ActionResult DeleteSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
    {
        return ControllerHelper.ModifyItems<SystemCountryCodePoco[]>(_service.Delete, systemCountryCodePocos);
    }
}
