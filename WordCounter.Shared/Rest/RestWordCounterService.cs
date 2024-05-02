namespace WordCounterNs.Shared.Rest;

public class RestWordCounterService : IRestWordCounterService
{
    private readonly IOptionalDependecy dependency;

    public RestWordCounterService(IOptionalDependecy dependency)
    {
        this.dependency = dependency;
    }

    public Dictionary<string, int> CountWordsWithLinq(string content)
    {
        return Counter.CountWordsWithLinq(content);
    }

    public Dictionary<string, int> CountWordsWithoutLinq(string content)
    {
        return Counter.CountWordsWithoutLinq(content);
    }
}