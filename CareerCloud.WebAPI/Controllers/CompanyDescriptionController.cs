using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDescriptionController : ControllerBase
    {
        public ActionResult DeleteCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult GetCompanyDescription(Guid id)
        {
            throw new NotImplementedException();
        }

        public ActionResult PostCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            throw new NotImplementedException();
        }

        public ActionResult PutCompanyDescription(CompanyDescriptionPoco[] companyDescriptionPocos)
        {
            throw new NotImplementedException();
        }
    }
}
