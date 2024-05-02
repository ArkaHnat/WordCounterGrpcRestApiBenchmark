using System.Runtime.Serialization;

namespace WordCounterNs.Shared.Grpc;

[DataContract]
public class GrpcWordCounterRequest
{
    [DataMember(Order = 1)] 
    public string Content { get; set; }
}