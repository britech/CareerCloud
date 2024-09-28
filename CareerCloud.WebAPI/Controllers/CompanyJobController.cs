using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyJobController : ControllerBase
    {
        public OkObjectResult DeleteCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetCompanyJob(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutCompanyJob(CompanyJobPoco[] companyJobPocos)
        {
            throw new NotImplementedException();
        }
    }
}
