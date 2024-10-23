using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services;

public class ApplicantEducationService(BaseLogic<ApplicantEducationPoco> service)
    : Protos.ApplicantEducationService.ApplicantEducationServiceBase
{
    public override Task<ApplicantEducations> Add(ApplicantEducations request, ServerCallContext context)
    {
        ApplicantEducationPoco[] items = request.Entries.Select(e => e.Convert()).ToArray();
        service.Add(items);

        ApplicantEducations response = new();
        response.Entries.AddRange(items.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<ApplicantEducations> Edit(ApplicantEducations request, ServerCallContext context)
    {
        ApplicantEducationPoco[] items = request.Entries.Select(e => e.Convert()).ToArray();
        service.Update(items);

        ApplicantEducations response = new();
        response.Entries.AddRange(items.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<Empty> Delete(RemoveApplicantEducationRequest request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }

    public override Task<ApplicantEducation> Get(GetApplicantEducationRequest request, ServerCallContext context)
    {
        return Task.FromResult(service.Get(request.Convert()).Convert());
    }

    public override Task<ApplicantEducations> List(Empty request, ServerCallContext context)
    {
        ApplicantEducations response = new();
        response.Entries.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }
}
