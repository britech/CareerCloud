using CareerCloud.BusinessLogicLayer;
using CareerCloud.Pocos;
using CareerCloud.WebAPI.Core;
using CareerCloud.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

public class SecurityLoginController : IPocoCrudController<SecurityLoginPoco>
{
    [ActivatorUtilitiesConstructor]
    public SecurityLoginController(BusinessLogicFactory factory) : base(factory)
    {
    }

    public SecurityLoginController()
        : this(CareerCloudServiceFactory.Default.Instance)
    {

    }

    [HttpDelete]
    public ActionResult DeleteSecurityLogin(SecurityLoginPoco[] users)
    {
        return Delete(users);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetSecurityLogin(Guid id)
    {
        return FindById(id);
    }

    [HttpPost]
    public ActionResult PostSecurityLogin(SecurityLoginPoco[] users)
    {
        return Add(users);
    }

    [HttpPut]
    public ActionResult PutSecurityLogin(SecurityLoginPoco[] users)
    {
        return Update(users);
    }
}
