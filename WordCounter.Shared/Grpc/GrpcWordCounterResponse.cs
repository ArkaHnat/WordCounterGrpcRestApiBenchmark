using System.Runtime.Serialization;

namespace WordCounterNs.Shared.Grpc;

[DataContract]
public class GrpcWordCounterResponse
{
    [DataMember(Order = 1)] 
    public Dictionary<string, int> Content { get; set; }
}