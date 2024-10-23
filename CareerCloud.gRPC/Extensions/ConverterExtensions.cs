using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;

namespace CareerCloud.gRPC.Extensions;

public static class ConverterExtensions
{
    private readonly static Decimal? POCO_DEFAULT_DECIMAL = null;

    #region SecurityLogin
    public static SecurityLoginPoco Convert(this SecurityLogin proto)
    {
        SecurityLoginPoco poco = new()
        {
            Id = Guid.Parse(proto.Id),
            Login = proto.Username,
            Password = proto.Password,
            EmailAddress = proto.EmailAddress,
            PhoneNumber = proto.PhoneNumber,
            FullName = proto.Name,
            IsLocked = proto.IsLocked,
            IsInactive = proto.IsInactive,
            ForceChangePassword = proto.ForcePasswordChange,
            PrefferredLanguage = proto.PreferredLanguage
        };

        if (proto.DateCreated != null)
            poco.Created = proto.DateCreated.ToDateTime();

        if (proto.PasswordUpdatedDate != null)
            poco.PasswordUpdate = proto.PasswordUpdatedDate.ToDateTime();

        if (proto.AgreementAcceptedDate != null) 
            poco.AgreementAccepted = proto.AgreementAcceptedDate.ToDateTime();

        return poco;
    }

    public static SecurityLogin Convert(this SecurityLoginPoco poco)
    {
        return new SecurityLogin
        {
            Id = poco.Id.ToString(),
            Username = poco.Login,
            Password = poco.Password,
            DateCreated = Timestamp.FromDateTime(poco.Created.ToUniversalTime()),
            PasswordUpdatedDate = Timestamp.FromDateTime(poco.PasswordUpdate.GetValueOrDefault(DateTime.MinValue).ToUniversalTime()),
            AgreementAcceptedDate = Timestamp.FromDateTime(poco.AgreementAccepted.GetValueOrDefault(DateTime.MinValue).ToUniversalTime()),
            IsLocked = poco.IsLocked,
            IsInactive = poco.IsInactive,
            EmailAddress = poco.EmailAddress,
            PhoneNumber = poco.PhoneNumber ?? "",
            Name = poco.FullName ?? "",
            ForcePasswordChange = poco.ForceChangePassword,
            PreferredLanguage = poco.PrefferredLanguage ?? ""
        };
    }

    public static SecurityLoginPoco[] Convert(this RemoveLoginsRequest request)
    {
        return request.Ids.Select(e => new SecurityLoginPoco
        {
            Id = Guid.Parse(e)
        }).ToArray();
    }

    public static Guid Convert(this GetLoginRequest request)
    {
        return Guid.Parse(request.Id);
    }
    #endregion

    #region SecurityLoginLog
    public static SecurityLoginsLogPoco Convert(this SecurityLoginLog proto)
    {
        return new SecurityLoginsLogPoco
        {
            Id = Guid.Parse(proto.Id),
            Login = Guid.Parse(proto.Login),
            LogonDate = proto.LogonDate.ToDateTime(),
            SourceIP = proto.SourceIp,
            IsSuccesful = proto.IsSucessful
        };
    }

    public static SecurityLoginLog Convert(this SecurityLoginsLogPoco poco)
    {
        return new SecurityLoginLog
        {
            Id = poco.Id.ToString(),
            Login = poco.Login.ToString(),
            LogonDate = Timestamp.FromDateTime(poco.LogonDate.ToUniversalTime()),
            SourceIp = poco.SourceIP,
            IsSucessful = poco.IsSuccesful
        };
    }

    public static SecurityLoginsLogPoco[] Convert(this RemoveLogsRequest request)
    {
        return request.Ids.Select(e => new SecurityLoginsLogPoco
        {
            Id = Guid.Parse(e)
        }).ToArray();
    }

    public static Guid Convert(this GetLogRequest request)
    {
        return Guid.Parse(request.Id);
    }
    #endregion

    #region SystemLanguageCode
    public static SystemLanguageCodePoco Convert(this SystemLanguage proto)
    {
        return new SystemLanguageCodePoco
        {
            LanguageID = proto.LanguageId,
            Name = proto.Name,
            NativeName = proto.NativeName,
        };
    } 

    public static SystemLanguage Convert(this SystemLanguageCodePoco poco)
    {
        return new SystemLanguage
        {
            LanguageId = poco.LanguageID,
            Name = poco.Name,
            NativeName = poco.NativeName,
        };
    }

    public static SystemLanguageCodePoco[] Convert(this RemoveLanguageRequest request)
    {
        return request.LanguageIds.Select(e => new SystemLanguageCodePoco
        {
            LanguageID = e
        }).ToArray();
    }

    public static string Convert(this GetLanguageRequest request)
    {
        return request.LanguageId;
    }
    #endregion

    #region ApplicantEducation
    public static ApplicantEducationPoco Convert(this ApplicantEducation proto)
    {
        return new ApplicantEducationPoco
        {
            Id = Guid.Parse(proto.Id),
            Applicant = Guid.Parse(proto.Applicant),
            CertificateDiploma = proto.Type,
            Major = proto.Major,
            StartDate = proto.StartDate?.ToDateTime(),
            CompletionDate = proto.CompletionDate?.ToDateTime(),
            CompletionPercent = (Byte?) proto.CompletionPercent
        };
    }

    public static ApplicantEducation Convert(this ApplicantEducationPoco poco)
    {
        return new ApplicantEducation
        {
            Id = poco.Id.ToString(),
            Applicant = poco.Applicant.ToString(),
            Type = poco.CertificateDiploma ?? "",
            Major = poco.Major ?? "",
            StartDate = Timestamp.FromDateTime(poco.StartDate.GetValueOrDefault(DateTime.MinValue).ToUniversalTime()),
            CompletionDate = Timestamp.FromDateTime(poco.CompletionDate.GetValueOrDefault(DateTime.MinValue).ToUniversalTime()),
            CompletionPercent = poco.CompletionPercent ?? 0
        };
    }

    public static ApplicantEducationPoco[] Convert(this RemoveApplicantEducationRequest request)
    {
        return request.Ids.Select(e => new ApplicantEducationPoco
        {
            Id = Guid.Parse(e)
        }).ToArray();
    }

    public static Guid Convert(this GetApplicantEducationRequest request) => Guid.Parse(request.Id.ToString());
    #endregion

    #region ApplicantJobApplication
    public static ApplicantJobApplicationPoco Convert(this ApplicantJobApplication proto)
    {
        ApplicantJobApplicationPoco poco = new()
        {
            Id = Guid.Parse(proto.Id),
            Applicant = Guid.Parse(proto.Applicant),
            Job = Guid.Parse(proto.Job)
        };

        if (proto.ApplicationDate != null)
            poco.ApplicationDate = proto.ApplicationDate.ToDateTime();

        return poco;
    }

    public static ApplicantJobApplication Convert(this ApplicantJobApplicationPoco poco)
    {
        return new ApplicantJobApplication
        {
            Id = poco.Id.ToString(),
            Applicant = poco.Applicant.ToString(),
            Job = poco.Job.ToString(),
            ApplicationDate = Timestamp.FromDateTime(poco.ApplicationDate)
        };
    }

    public static ApplicantJobApplicationPoco[] Convert(this RemoveApplicantJobApplicationRequest request)
    {
        return request.Ids.Select(e => new ApplicantJobApplicationPoco
        {
            Id = Guid.Parse(e)
        }).ToArray();
    }

    public static Guid Convert(this GetApplicantJobApplicationRequest request)
    {
        return Guid.Parse(request.Id);
    }
    #endregion

    #region ApplicantProfile
    public static ApplicantProfilePoco Convert(this ApplicantProfile proto)
    {
        _ = decimal.TryParse(proto.CurrentRate, out decimal currentRate);
        _ = decimal.TryParse(proto.CurrentSalary, out decimal currentSalary);

        return new ApplicantProfilePoco
        {
            Id = Guid.Parse(proto.Id),
            Login = Guid.Parse(proto.Login),
            CurrentSalary = currentSalary,
            CurrentRate = currentRate,
            Currency = proto.Currency,
            Street = proto.Street,
            City = proto.City,
            Province = proto.Province,
            PostalCode = proto.PostalCode,
            Country = proto.Country
        };
    }

    public static ApplicantProfile Convert(this ApplicantProfilePoco poco)
    {
        return new ApplicantProfile
        {
            Id = poco.Id.ToString(),
            Login = poco.Login.ToString(),
            CurrentSalary = poco.CurrentSalary.GetValueOrDefault(decimal.Zero).ToString(),
            CurrentRate = poco.CurrentRate.GetValueOrDefault(decimal.Zero).ToString(),
            Currency = poco.Currency ?? string.Empty,
            Street = poco.Street ?? string.Empty,
            City = poco.City ?? string.Empty,
            Province = poco.Province ?? string.Empty,
            PostalCode = poco.PostalCode ?? string.Empty,
            Country = poco.Country ?? string.Empty
        };
    }

    public static ApplicantProfilePoco[] Convert(this RemoveApplicantProfile proto)
    {
        return proto.Ids
            .Where(e => Guid.TryParse(e, out Guid _))
            .Select(e => new ApplicantProfilePoco 
            {
                Id = Guid.Parse(e)
            }).ToArray();
    }

    public static Guid Convert(this GetApplicantProfile proto)
    {
        _ = Guid.TryParse(proto.Id, out Guid result);
        return result;
    }
    #endregion
}
