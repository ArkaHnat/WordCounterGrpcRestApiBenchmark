using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace WordCounterNs.Benchmark;

public class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<GrpcVsRestApiBenchmark>(ManualConfig.Create(DefaultConfig.Instance)
            .WithOptions(ConfigOptions.DisableOptimizationsValidator));
    }
}