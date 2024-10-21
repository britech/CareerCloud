using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;

namespace CareerCloud.gRPC.Extensions;

public static class ConverterExtensions
{
    public static SecurityLoginPoco Convert(this UserLogin proto)
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

        if (proto.PasswordUpdateDate != null)
            poco.PasswordUpdate = proto.PasswordUpdateDate.ToDateTime();

        if (proto.AgreementAcceptedDate != null) 
            poco.AgreementAccepted = proto.AgreementAcceptedDate.ToDateTime();

        return poco;
    }

    public static UserLogin Convert(this SecurityLoginPoco poco)
    {
        return new UserLogin
        {
            Id = poco.Id.ToString(),
            Username = poco.Login,
            Password = poco.Password,
            DateCreated = Timestamp.FromDateTime(poco.Created.ToUniversalTime()),
            PasswordUpdateDate = Timestamp.FromDateTime(poco.PasswordUpdate.GetValueOrDefault(DateTime.MinValue).ToUniversalTime()),
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

    public static SecurityLoginPoco[] Convert(this RemoveUsersRequest request)
    {
        return request.Users.Select(e => new SecurityLoginPoco
        {
            Id = Guid.Parse(e)
        }).ToArray();
    }

    public static Guid Convert(this GetUserRequest request)
    {
        return Guid.Parse(request.Id);
    }
}
