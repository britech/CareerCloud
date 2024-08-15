using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SystemLanguageCodeLogic : AbstractValidatedPocoCRUDService<SystemLanguageCodePoco, string>
{
    public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository) : base(repository)
    {
    }

    public override SystemLanguageCodePoco Get(string id)
    {
        return Repository.GetSingle(_language => _language.LanguageID == id);
    }

    protected override void Verify(SystemLanguageCodePoco[] items)
    {
        PocoValidationHelper.Verify(item =>
        {
            List<ValidationException> errors = new List<ValidationException>();
            
            if (string.IsNullOrEmpty(item?.LanguageID))
            {
                errors.Add(ValidationException.SYSTEM_LANGUAGE_ID_REQUIRED);
            }

            if (string.IsNullOrEmpty(item?.Name))
            {
                errors.Add(ValidationException.SYSTEM_LANGUAGE_NAME_REQUIRED);
            }

            if (string.IsNullOrEmpty(item?.NativeName))
            {
                errors.Add(ValidationException.SYSTEM_LANGUAGE_NATIVE_NAME_REQUIRED);
            }

            return errors;
        }, items);
    }
}
