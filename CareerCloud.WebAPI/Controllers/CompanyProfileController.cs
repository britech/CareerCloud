using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProfileController : ControllerBase
    {
        public ActionResult DeleteCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult GetCompanyProfile(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutCompanyProfile(CompanyProfilePoco[] companyProfilePocos)
        {
            throw new NotImplementedException();
        }
    }
}
