using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services;

public class CompanyDescriptionService(BaseLogic<CompanyDescriptionPoco> service)
    : Protos.CompanyDescriptionService.CompanyDescriptionServiceBase
{
    public override Task<CompanyDescriptionCollection> Add(CompanyDescriptionCollection request, ServerCallContext context)
    {
        CompanyDescriptionPoco[] rows = request.Entries.Select(e => e.Convert()).ToArray();
        service.Add(rows);

        CompanyDescriptionCollection response = new();
        response.Entries.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<CompanyDescriptionCollection> Edit(CompanyDescriptionCollection request, ServerCallContext context)
    {
        CompanyDescriptionPoco[] rows = request.Entries.Select(e => e.Convert()).ToArray();
        service.Update(rows);

        CompanyDescriptionCollection response = new();
        response.Entries.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<CompanyDescription> Get(GetCompanyDescription request, ServerCallContext context)
    {
        return Task.FromResult(service.Get(request.Convert()).Convert());
    }

    public override Task<CompanyDescriptionCollection> List(Empty request, ServerCallContext context)
    {
        CompanyDescriptionCollection response = new();
        response.Entries.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<Empty> Remove(RemoveCompanyDescription request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }
}
