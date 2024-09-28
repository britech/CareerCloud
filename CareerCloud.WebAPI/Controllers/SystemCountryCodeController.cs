using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
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

        public ActionResult PostSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult GetSystemCountryCode(string code)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteSystemCountryCode(SystemCountryCodePoco[] systemCountryCodePocos)
        {
            throw new NotImplementedException();
        }
    }
}
