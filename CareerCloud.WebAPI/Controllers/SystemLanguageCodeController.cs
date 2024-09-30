using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SystemLanguageCodeController : ControllerBase
{
    [HttpDelete]
    public ActionResult DeleteSystemLanguageCode(SystemLanguageCodePoco[] systemLanguageCodePocos)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult GetSystemLanguageCode(string languageID)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public ActionResult PostSystemLanguageCode(SystemLanguageCodePoco[] systemLanguageCodePocos)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult PutSystemLanguageCode(SystemLanguageCodePoco[] systemLanguageCodePocos)
    {
        throw new NotImplementedException();
    }
}
