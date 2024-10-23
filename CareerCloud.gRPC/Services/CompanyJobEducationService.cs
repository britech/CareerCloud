using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services;

public class CompanyJobEducationService(BaseLogic<CompanyJobEducationPoco> service)
    : Protos.CompanyJobEducationService.CompanyJobEducationServiceBase
{
    public override Task<CompanyJobEducationCollection> Add(CompanyJobEducationCollection request, ServerCallContext context)
    {
        CompanyJobEducationPoco[] rows = request.Entries.Select(e => e.Convert()).ToArray();
        service.Add(rows);

        CompanyJobEducationCollection response = new();
        response.Entries.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<CompanyJobEducationCollection> Edit(CompanyJobEducationCollection request, ServerCallContext context)
    {
        CompanyJobEducationPoco[] rows = request.Entries.Select(e => e.Convert()).ToArray();
        service.Update(rows);

        CompanyJobEducationCollection response = new();
        response.Entries.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<CompanyJobEducation> Get(GetCompanyJobEducation request, ServerCallContext context)
    {
        return Task.FromResult(service.Get(request.Convert()).Convert());
    }

    public override Task<CompanyJobEducationCollection> List(Empty request, ServerCallContext context)
    {
        CompanyJobEducationCollection response = new();
        response.Entries.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<Empty> Remove(RemoveCompanyJobEducation request, ServerCallContext context)
    {
        return base.Remove(request, context);
    }
}
