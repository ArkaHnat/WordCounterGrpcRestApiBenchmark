using System.ServiceModel;

namespace WordCounterNs.Shared.Rest;

/// <summary>
///     This is a sample service that demonstrates all types of gRPC operations from a code-first gRPC service
/// </summary>
[ServiceContract]
public interface IRestWordCounterService
{
    Dictionary<string, int> CountWordsWithLinq(string content);

    Dictionary<string, int> CountWordsWithoutLinq(string content);
}