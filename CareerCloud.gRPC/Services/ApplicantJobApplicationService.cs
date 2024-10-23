using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services;

public class ApplicantJobApplicationService(BaseLogic<ApplicantJobApplicationPoco> service)
    : Protos.ApplicantJobApplicationService.ApplicantJobApplicationServiceBase
{
    public override Task<ApplicantJobApplications> Add(ApplicantJobApplications request, ServerCallContext context)
    {
        ApplicantJobApplicationPoco[] rows = request.Applications.Select(e => e.Convert()).ToArray();
        service.Add(rows);

        ApplicantJobApplications response = new();
        response.Applications.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<ApplicantJobApplications> Edit(ApplicantJobApplications request, ServerCallContext context)
    {
        ApplicantJobApplicationPoco[] rows = request.Applications.Select(e => e.Convert()).ToArray();
        service.Update(rows);

        ApplicantJobApplications response = new();
        response.Applications.AddRange(rows.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<Empty> Remove(RemoveApplicantJobApplicationRequest request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }

    public override Task<ApplicantJobApplication> Get(GetApplicantJobApplicationRequest request, ServerCallContext context)
    {
        return Task.FromResult(service.Get(request.Convert()).Convert());
    }

    public override Task<ApplicantJobApplications> List(Empty request, ServerCallContext context)
    {
        ApplicantJobApplications response = new();
        response.Applications.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }
}
