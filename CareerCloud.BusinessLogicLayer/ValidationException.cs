namespace CareerCloud.BusinessLogicLayer;

public class ValidationException(int code, string message) : Exception(message)
{
    public static readonly ValidationException EDUCATION_MAJOR_REQUIRED = new(107, "Cannot be empty or less than 3 characters.");
    public static readonly ValidationException EDUCATION_START_DATE_GREATER_THAN_TODAY = new(108, "Cannot be greater than today.");
    public static readonly ValidationException EDUCATION_COMPLETION_DATE_LESS_THAN_STARTDATE = new(109, "CompletionDate cannot be earlier than StartDate.");
    public static readonly ValidationException JOB_APPLICATION_DATE_GREATER_THAN_TODAY = new(110, "ApplicationDate cannot be greater than today.");
    public static readonly ValidationException CURRENT_SALARY_IS_NEGATIVE = new(111, "CurrentSalary cannot be negative.");
    public static readonly ValidationException CURRENT_RATE_IS_NEGATIVE = new(112, "CurrentRate cannot be negative");
    public static readonly ValidationException RESUME_REQUIRED = new(113, "Resume cannot be empty");
    public static readonly ValidationException SKILL_START_MONTH_INVALID = new(101, "Cannot be greater than 12");
    public static readonly ValidationException SKILL_END_MONTH_INVALID = new(102, "Cannot be greater than 12");
    public static readonly ValidationException SKILL_START_YEAR_INVALID = new(103, "Cannot be less than 1900");
    public static readonly ValidationException SKILL_END_YEAR_LESS_THAN_START_YEAR = new(104, "EndYear cannot be less than StartYear");
    public static readonly ValidationException WORK_HISTORY_COMPANY_NAME_REQUIRED = new(105, "CompanyName should be included in the work history.");
    public static readonly ValidationException COMPANY_DESCRIPTION_MIN_LEN = new(107, "CompanyDescription should be greater than 2 characters.");
    public static readonly ValidationException COMPANY_NAME_MIN_LEN = new(106, "CompanyName should be greater than least 2 characters.");
    public static readonly ValidationException JOB_NAME_REQUIRED = new(300, "JobName is required.");
    public static readonly ValidationException JOB_DESCRIPTION_REQUIRED = new(301, "JobDescription is required.");
    public static readonly ValidationException JOB_REQUIRED_EDUCATION_MAJOR_MIN_LEN = new(200, "Mandated Education Major should be greater than 2 characters");
    public static readonly ValidationException JOB_REQUIRED_EDUCATION_IMPORTANCE_MIN_LEVEL = new(201, "Importance Level for required Education Major should be greater than 0");
    public static readonly ValidationException JOB_REQUIRED_SKILL_IMPORTANCE_LEVEL_MIN_LEVEL = new(400, "Importance Level for required Skill should be greater than 0");
    public static readonly ValidationException COMPANY_LOCATION_COUNTRY_REQUIRED = new(500, "Company Location - Country is required.");
    public static readonly ValidationException COMPANY_LOCATION_PROVINCE_REQUIRED = new(501, "Company Location - Province is required.");
    public static readonly ValidationException COMPANY_LOCATION_STREET_REQUIRED = new(502, "Company Location - Street is required.");
    public static readonly ValidationException COMPANY_LOCATION_CITY_REQUIRED = new(503, "Company Location - City is required.");
    public static readonly ValidationException COMPANY_LOCATION_POSTALCODE_REQUIRED = new(504, "Company Location - Postal Code is required.");
    public static readonly ValidationException COMPANY_WEBSITE_INVALID_DOMAIN = new(600, "Website domain for company is not recognized");
    public static readonly ValidationException COMPANY_PHONE_INVALID_PATTERN = new(601, "Contact Phone for company is invalid");
    public static readonly ValidationException SECURITY_ROLE_REQUIRED = new(800, "Security Role is required.");
    public static readonly ValidationException SYSTEM_COUNTRY_NAME_REQUIRED = new(900, "System - Country Code is required.");
    public static readonly ValidationException SYSTEM_COUNTRY_CODE_REQUIRED = new(901, "System - Country Name is required.");
    public static readonly ValidationException SYSTEM_LANGUAGE_ID_REQUIRED = new(1000, "System - LanguageID is required.");
    public static readonly ValidationException SYSTEM_LANGUAGE_NAME_REQUIRED = new(1001, "System - Language Name is required.");
    public static readonly ValidationException SYSTEM_LANGUAGE_NATIVE_NAME_REQUIRED = new(1002, "System - Language Native Name is required.");

    public int Code { get; init; } = code;
}