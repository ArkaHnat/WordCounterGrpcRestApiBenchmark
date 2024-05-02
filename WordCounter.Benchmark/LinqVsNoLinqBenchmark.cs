using BenchmarkDotNet.Attributes;
using WordCounterNs.Shared;

namespace WordCounterNs.Benchmark;

public class LinqVsNoLinqBenchmark
{
    private string Content = string.Empty;

    [GlobalSetup]
    public void GlobalSetup()
    {
        this.Content = WordHelpers.GenerateRandomString(100);
    }

    [Benchmark]
    public void WithoutLinq()
    {
        Counter.CountWordsWithoutLinq(this.Content);
    }

    [Benchmark]
    public void WithLinq()
    {
        Counter.CountWordsWithoutLinq(this.Content);
    }
}