using ProtoBuf.Grpc;

namespace WordCounterNs.Shared.Grpc;

public class GrpcWordCounterService : IGrpcWordCounterService
{
    private IOptionalDependecy dependency;

    public GrpcWordCounterService(IOptionalDependecy dependency)
    {
        this.dependency = dependency;
    }

    public Task<GrpcWordCounterResponse> CountWordsWithoutLinq(GrpcWordCounterRequest request, CallContext context = default)
    {
        return Task.FromResult(new GrpcWordCounterResponse { Content = Counter.CountWordsWithoutLinq(request.Content) });
    }

    public Task<GrpcWordCounterResponse> CountWordsWithLinq(GrpcWordCounterRequest request, CallContext context = default)
    {
        return Task.FromResult(new GrpcWordCounterResponse { Content = Counter.CountWordsWithLinq(request.Content) });
    }
}