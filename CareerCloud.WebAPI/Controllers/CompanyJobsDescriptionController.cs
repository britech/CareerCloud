using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyJobsDescriptionController : ControllerBase
    {
        public OkObjectResult DeleteCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            throw new NotImplementedException();
        }

        public OkObjectResult GetCompanyJobsDescription(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutCompanyJobsDescription(CompanyJobDescriptionPoco[] companyJobDescriptionPocos)
        {
            throw new NotImplementedException();
        }
    }
}
