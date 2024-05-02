using System.Text;
using Microsoft.AspNetCore.Http;

namespace WordCounterNs;

public class WordHelpers
{
    public static async Task<string> ReadFormFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return await Task.FromResult((string)null);
        }

        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            return await reader.ReadToEndAsync();
        }
    }

    public static string GenerateRandomString(int v)
    {
        var random = new Random();

        var numberOfStrings = random.Next(v, v);
        var sb = new StringBuilder();

        for (var i = 0; i < numberOfStrings; i++)
        {
            sb.Append(GenerateRandomString(random, random.Next(1, 12)));
        }

        return sb.ToString();
    }

    private static string GenerateRandomString(Random random, int length)
    {
        //const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string chars = "ABCDEF";
        var stringBuilder = new StringBuilder(length);

        for (var i = 0; i < length; i++)
        {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }

        stringBuilder.Append(" ");

        return stringBuilder.ToString();
    }
}