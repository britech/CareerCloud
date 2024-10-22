namespace CareerCloud.gRPC.Services;

using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

public class SecurityLoginService(BaseLogic<SecurityLoginPoco> service) : Protos.SecurityLoginService.SecurityLoginServiceBase
{
    public override Task<SecurityLogins> Add(SecurityLogins request, ServerCallContext context)
    {
        SecurityLoginPoco[] rows = request.Logins.Select(e => e.Convert()).ToArray();
        service.Add(rows);

        SecurityLogins logins = new();
        logins.Logins.AddRange(rows.Select(e => e.Convert()).ToList());

        return Task.FromResult(logins);
    }

    public override Task<SecurityLogins> Edit(SecurityLogins request, ServerCallContext context)
    {
        SecurityLoginPoco[] rows = request.Logins.Select(e => e.Convert()).ToArray();
        service.Update(rows);

        SecurityLogins logins = new();
        logins.Logins.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(logins);
    }

    public override Task<Empty> Remove(RemoveLoginsRequest request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }

    public override Task<SecurityLogin> Get(GetLoginRequest request, ServerCallContext context)
    {
        SecurityLoginPoco poco = service.Get(request.Convert());
        return Task.FromResult(poco.Convert());
    }

    public override Task<SecurityLogins> List(Empty request, ServerCallContext context)
    {
        SecurityLogins logins = new();
        logins.Logins.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return Task.FromResult(logins);
    }
}
