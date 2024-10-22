using CareerCloud.BusinessLogicLayer;
using CareerCloud.gRPC.Extensions;
using CareerCloud.gRPC.Protos;
using CareerCloud.Pocos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CareerCloud.gRPC.Services;

public class SystemLanguageCodeService(AbstractValidatedPocoCRUDService<SystemLanguageCodePoco, string> service) 
    : Protos.SystemLanguageCodeService.SystemLanguageCodeServiceBase
{
    public override Task<SystemLanguages> Add(SystemLanguages request, ServerCallContext context)
    {
        SystemLanguageCodePoco[] languages = request.Languages.Select(e => e.Convert()).ToArray();
        service.Add(languages);

        SystemLanguages response = new();
        response.Languages.AddRange(languages.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<SystemLanguages> Edit(SystemLanguages request, ServerCallContext context)
    {
        SystemLanguageCodePoco[] languages = request.Languages.Select(e => e.Convert()).ToArray();
        service.Update(languages);

        SystemLanguages response = new();
        response.Languages.AddRange(languages.Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }

    public override Task<Empty> Remove(RemoveLanguageRequest request, ServerCallContext context)
    {
        service.Delete(request.Convert());
        return Task.FromResult(new Empty());
    }

    public override Task<SystemLanguage> Get(GetLanguageRequest request, ServerCallContext context)
    {
        return Task.FromResult(service.Get(request.Convert()).Convert());
    }

    public override Task<SystemLanguages> List(Empty request, ServerCallContext context)
    {
        SystemLanguages response = new();
        response.Languages.AddRange(service.GetAll().Select(e => e.Convert()).ToList());
        return Task.FromResult(response);
    }
}
