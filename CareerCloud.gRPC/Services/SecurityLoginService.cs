namespace CareerCloud.gRPC.Services;

using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Converters;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

public class SecurityLoginService(BaseLogic<SecurityLoginPoco> service) : Protos.SecurityLoginService.SecurityLoginServiceBase
{
    public override Task<Users> AddUsers(Users request, ServerCallContext context)
    {
        SecurityLoginPoco[] rows = request.Users_.Select(e => e.Convert()).ToArray();
        service.Add(rows);

        Users users = new();
        users.Users_.AddRange(rows.Select(e => e.Convert()).ToList());

        return Task.FromResult(users);
    }

    public override Task<Users> EditUsers(Users request, ServerCallContext context)
    {
        SecurityLoginPoco[] rows = request.Users_.Select(e => e.Convert()).ToArray();
        service.Update(rows);

        Users users = new();
        users.Users_.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(users);
    }

    public override Task<Empty> RemoveUsers(RemoveUsersRequest request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }

    public override Task<UserLogin> GetUser(GetUserRequest request, ServerCallContext context)
    {
        SecurityLoginPoco poco = service.Get(request.Convert());
        return Task.FromResult(poco.Convert());
    }

    public override Task<Users> ListUsers(Empty request, ServerCallContext context)
    {
        return Task.Run(() =>
        {
            Users users = new Users();
            users.Users_.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
            return users;
        });
    }
}
