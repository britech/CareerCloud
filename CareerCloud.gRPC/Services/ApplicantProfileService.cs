using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services;

public class ApplicantProfileService(BaseLogic<ApplicantProfilePoco> service)
    : Protos.ApplicantProfileService.ApplicantProfileServiceBase
{
    public override Task<ApplicantProfiles> Add(ApplicantProfiles request, ServerCallContext context)
    {
        ApplicantProfilePoco[] rows = request.Profiles.Select(e => e.Convert()).ToArray();
        service.Add(rows);

        ApplicantProfiles response = new();
        response.Profiles.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<ApplicantProfiles> Edit(ApplicantProfiles request, ServerCallContext context)
    {
        ApplicantProfilePoco[] rows = request.Profiles.Select(e => e.Convert()).ToArray();
        service.Update(rows);

        ApplicantProfiles response = new();
        response.Profiles.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<Empty> Remove(RemoveApplicantProfile request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }

    public override Task<ApplicantProfile> Get(GetApplicantProfile request, ServerCallContext context)
    {
        return Task.FromResult(service.Get(request.Convert()).Convert());
    }

    public override Task<ApplicantProfiles> List(Empty request, ServerCallContext context)
    {
        ApplicantProfiles response = new();
        response.Profiles.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return base.List(request, context);
    }
}
