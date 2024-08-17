using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SystemLanguageCodeLogic : AbstractValidatedPocoCRUDService<SystemLanguageCodePoco, string>
{
    public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) 
        : base(repository, [
            new PocoValidationRule<SystemLanguageCodePoco>(
                item => !string.IsNullOrEmpty(item?.LanguageID),
                ValidationException.SYSTEM_LANGUAGE_ID_REQUIRED
                ),
            new PocoValidationRule<SystemLanguageCodePoco>(
                item => !string.IsNullOrEmpty(item?.Name),
                ValidationException.SYSTEM_LANGUAGE_NAME_REQUIRED
                ),
            new PocoValidationRule<SystemLanguageCodePoco>(
                item => !string.IsNullOrEmpty(item?.NativeName),
                ValidationException.SYSTEM_LANGUAGE_NATIVE_NAME_REQUIRED
                )
            ])
    {
    }

    public override SystemLanguageCodePoco Get(string id)
    {
        return Repository.GetSingle(_language => _language.LanguageID == id);
    }
}
