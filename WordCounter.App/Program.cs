using Microsoft.Extensions.DependencyInjection;
using WordCounterNs.Shared;
using WordCounterNs.Shared.Rest;

namespace WordCounterApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = CreateServices();

        var app = services.GetRequiredService<IRestWordCounterService>();
        if (File.Exists(args[0]))
        {
            var fileContent = File.ReadAllText(args[0]);
            var res = app.CountWordsWithLinq(fileContent);
            Console.WriteLine(Counter.ConvertResultToOutputFormat(res));
        }
        else
        {
            throw new FileNotFoundException();
        }

        Console.ReadLine();
    }

    private static ServiceProvider CreateServices()
    {
        var serviceProvider = new ServiceCollection().AddSingleton<IOptionalDependecy, OptionalDependecny>()
            .AddSingleton<IRestWordCounterService, RestWordCounterService>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}