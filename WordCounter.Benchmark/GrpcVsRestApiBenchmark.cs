using BenchmarkDotNet.Attributes;
using Grpc.Net.Client;
using MyNamespace;
using ProtoBuf.Grpc.Client;
using WordCounterNs.Shared.Grpc;

namespace WordCounterNs.Benchmark;

public class GrpcVsRestApiBenchmark
{
    private readonly int numberOfCalls = 1000;
    private GrpcChannel channel;
    private string generatedContent = string.Empty;
    private IGrpcWordCounterService grpcClient;
    private WordCounterClient restClient;

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.channel = GrpcChannel.ForAddress("https://localhost:7262");
        this.grpcClient = this.channel.CreateGrpcService<IGrpcWordCounterService>();
        this.restClient = new WordCounterClient("https://localhost:7021", new HttpClient());
        this.generatedContent = WordHelpers.GenerateRandomString(10000);
    }

    [Benchmark]
    public async Task GrpcParallel()
    {
        var taskList = new List<Task>();
        foreach (var i in Enumerable.Range(0, this.numberOfCalls))
        {
            taskList.Add(this.grpcClient.CountWordsWithLinq(new GrpcWordCounterRequest { Content = this.generatedContent }));
        }

        Task.WaitAll(taskList.ToArray());
    }

    [Benchmark]
    public async Task RestParallel()
    {
        var taskList = new List<Task>();
        foreach (var i in Enumerable.Range(0, this.numberOfCalls))
        {
            taskList.Add(this.restClient.CountWordsWithLinqAsync(new RestWordCounterRequest { Content = this.generatedContent }));
        }

        Task.WaitAll(taskList.ToArray());
    }

    [Benchmark]
    public async Task GrpcSequential()
    {
        foreach (var i in Enumerable.Range(0, this.numberOfCalls))
        {
            var res = await this.grpcClient.CountWordsWithLinq(new GrpcWordCounterRequest { Content = this.generatedContent });
        }
    }

    [Benchmark]
    public async Task RestSequential()
    {
        foreach (var i in Enumerable.Range(0, this.numberOfCalls))
        {
            var res = await this.restClient.CountWordsWithLinqAsync(new RestWordCounterRequest { Content = this.generatedContent });
        }
    }
}