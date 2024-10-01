using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class SystemLanguageCodeController : BaseCrudController<SystemLanguageCodePoco, string>
{
    [ActivatorUtilitiesConstructor]
    public SystemLanguageCodeController(BusinessLogicFactory factory)
        : base(factory)
    {

    }

    public SystemLanguageCodeController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] items)
    {
        return Delete(items);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSystemLanguageCode([FromRoute] string id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] items)
    {
        return Add(items);
    }

    [HttpPut]
    public ActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] items)
    {
        return Update(items);
    }
}
