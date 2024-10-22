﻿using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;

namespace CareerCloud.gRPC.Extensions;

public static class ConverterExtensions
{
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

    public static SecurityLoginsLogPoco Convert(this Audit proto)
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

    public static Audit Convert(this SecurityLoginsLogPoco poco)
    {
        return new Audit
        {
            Id = poco.Id.ToString(),
            Login = poco.Login.ToString(),
            LogonDate = Timestamp.FromDateTime(poco.LogonDate.ToUniversalTime()),
            SourceIp = poco.SourceIP,
            IsSucessful = poco.IsSuccesful
        };
    }

    public static SecurityLoginsLogPoco[] Convert(this RemoveRecordsRequest request)
    {
        return request.Rows.Select(e => new SecurityLoginsLogPoco
        {
            Id = Guid.Parse(e)
        }).ToArray();
    }

    public static Guid Convert(this GetRecordRequest request)
    {
        return Guid.Parse(request.Id);
    }
}
