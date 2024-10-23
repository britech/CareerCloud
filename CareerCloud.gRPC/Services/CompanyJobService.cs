using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services;

public class CompanyJobService(BaseLogic<CompanyJobPoco> service)
    : Protos.CompanyJobService.CompanyJobServiceBase
{
    public override Task<CompanyJobCollection> Add(CompanyJobCollection request, ServerCallContext context)
    {
        CompanyJobPoco[] rows = request.Entries.Select(e => e.Convert()).ToArray();
        service.Add(rows);

        CompanyJobCollection response = new();
        response.Entries.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<CompanyJobCollection> Edit(CompanyJobCollection request, ServerCallContext context)
    {
        CompanyJobPoco[] rows = request.Entries.Select(e => e.Convert()).ToArray();
        service.Update(rows);

        CompanyJobCollection response = new();
        response.Entries.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<CompanyJob> Get(GetCompanyJob request, ServerCallContext context)
    {
        return Task.FromResult(service.Get(request.Convert()).Convert());
    }

    public override Task<CompanyJobCollection> List(Empty request, ServerCallContext context)
    {
        CompanyJobCollection response = new();
        response.Entries.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<Empty> Remove(RemoveCompanyJob request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }
}
