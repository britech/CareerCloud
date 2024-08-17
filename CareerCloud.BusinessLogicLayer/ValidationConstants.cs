namespace CareerCloud.BusinessLogicLayer;

public static class ValidationConstants
{
    public static readonly int EDUCATION_MAJOR_MIN_LEN = 3;
    public static readonly decimal CURRENT_SALARY_MIN_VALUE = decimal.Zero;
    public static readonly decimal CURRENT_RATE_MIN_VALUE = decimal.Zero;
    public static readonly int MAX_MONTHS = 12;
    public static readonly int MIN_YEAR = 1900;
    public static readonly int WORK_HISTORY_COMPANY_NAME_MIN_LEN = 3;
    public static readonly int COMPANY_DESCRIPTION_MIN_LEN = 3;
    public static readonly int COMPANY_NAME_MIN_LEN = 3;
    public static readonly int JOB_REQUIRED_EDUCATION_MAJOR_MIN_LEN = 2;
    public static readonly int JOB_REQUIRED_EDUCATION_IMPORTANCE_MIN_LEVEL = 0;
    public static readonly int JOB_REQUIRED_SKILL_IMPORTANCE_LEVEL_MIN_LEVEL = 0;
    public static readonly string[] VALID_DOMAINS = [".ca", ".com", ".biz"];
    public static readonly string COMPANY_PHONE_REGEX_PATTERN = "\\d{1}\\d{2}-\\d{3}-\\d{4}";

    static ValidationConstants()
    {

    }
}