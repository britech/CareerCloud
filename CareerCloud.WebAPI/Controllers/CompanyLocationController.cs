using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyLocationController : ControllerBase
    {
        public OkObjectResult DeleteCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetCompanyLocation(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutCompanyLocation(CompanyLocationPoco[] companyLocationPocos)
        {
            throw new NotImplementedException();
        }
    }
}
