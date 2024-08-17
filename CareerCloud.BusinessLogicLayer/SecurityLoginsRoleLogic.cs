using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : BaseLogic<SecurityLoginsRolePoco>(repository)
{
    
}
