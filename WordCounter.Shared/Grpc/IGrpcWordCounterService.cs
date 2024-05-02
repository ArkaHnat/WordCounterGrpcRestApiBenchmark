using System.ServiceModel;
using ProtoBuf.Grpc;

namespace WordCounterNs.Shared.Grpc;

/// <summary>
///     This is a sample service that demonstrates all types of gRPC operations from a code-first gRPC service
/// </summary>
[ServiceContract]
public interface IGrpcWordCounterService
{
    /// <summary>
    ///     A Unary operation takes a single request, and returns a single response
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    [OperationContract]
    Task<GrpcWordCounterResponse> CountWordsWithLinq(GrpcWordCounterRequest request, CallContext context = default);

    /// <summary>
    ///     A Unary operation takes a single request, and returns a single response
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    [OperationContract]
    Task<GrpcWordCounterResponse> CountWordsWithoutLinq(GrpcWordCounterRequest request, CallContext context = default);
}