using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services;

public class SecurityLoginsLogService(BaseLogic<SecurityLoginsLogPoco> service) 
    : Protos.SecurityLoginsLogService.SecurityLoginsLogServiceBase
{
    public override Task<SecurityLoginLogs> Add(SecurityLoginLogs request, ServerCallContext context)
    {
        SecurityLoginsLogPoco[] rows = request.Logs.Select(e => e.Convert()).ToArray();
        service.Add(rows);

        SecurityLoginLogs logs = new();
        logs.Logs.AddRange(rows.Select(e => e.Convert()).ToList());

        return Task.FromResult(logs);
    }

    public override Task<SecurityLoginLogs> Edit(SecurityLoginLogs request, ServerCallContext context)
    {
        SecurityLoginsLogPoco[] rows = request.Logs.Select(e => e.Convert()).ToArray();
        service.Update(rows);

        SecurityLoginLogs logs = new();
        logs.Logs.AddRange(rows.Select(e => e.Convert()).ToList());

        return Task.FromResult(logs);
    }

    public override Task<Empty> Remove(RemoveLogsRequest request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }

    public override Task<SecurityLoginLog> Get(GetLogRequest request, ServerCallContext context)
    {
        return Task.FromResult(service.Get(request.Convert()).Convert());
    }

    public override Task<SecurityLoginLogs> List(Empty request, ServerCallContext context)
    {
        SecurityLoginLogs logs = new();
        logs.Logs.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return Task.FromResult(logs);
    }
}
