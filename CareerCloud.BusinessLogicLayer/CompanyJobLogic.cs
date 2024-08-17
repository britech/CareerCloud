using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : BaseLogic<CompanyJobPoco>(repository)
{
    
}
