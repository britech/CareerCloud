using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityLoginsLogLogic(IDataRepository<SecurityLoginsLogPoco> repository) : BaseLogic<SecurityLoginsLogPoco>(repository)
{
   
}
