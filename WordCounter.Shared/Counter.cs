using System.Text;

namespace WordCounterNs.Shared;

public class Counter
{
    private static readonly char[] WordSeparators = [' ', ',', '.', '-', '\n', '\t', '\r', '[', ']', ';', ':', '<', '>', '=', '/', '\\']; //and so on

    private static string RemoveNonAlphanumericWithLinq(string input)
    {
        var result = new StringBuilder();
        input.Where(char.IsLetterOrDigit)
            .ToList()
            .ForEach(a => result.Append(a));

        return result.ToString();
    }

    private static string RemoveNonAlphanumericWithoutLinq(string input)
    {
        var result = new StringBuilder();
        foreach (var c in input)
        {
            if (char.IsLetterOrDigit(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    public static Dictionary<string, int> CountWordsWithLinq(string content)
    {
        var res = content.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries)
            .Select(RemoveNonAlphanumericWithLinq)
            .Where(b => !string.IsNullOrWhiteSpace(b))
            .GroupBy(c => c, StringComparer.OrdinalIgnoreCase)
            .ToDictionary(x => x.Key, x => x.Count());

        return res;
    }

    public static Dictionary<string, int> CountWordsWithoutLinq(string content)
    {
        var wordCount = new Dictionary<string, int>();

        var words = content.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            var cleanedWord = RemoveNonAlphanumericWithoutLinq(word);
            cleanedWord = word.Trim()
                .ToLower();

            if (!wordCount.ContainsKey(cleanedWord))
            {
                wordCount[cleanedWord] = 1;
            }
            else
            {
                wordCount[cleanedWord]++;
            }
        }

        return wordCount;
    }

    public static string ConvertResultToOutputFormat(Dictionary<string, int> dict)
    {
        var tmp = dict.Select(a => $"{a.Value.ToString()}: {a.Key.ToString()}");
        var result = string.Join(Environment.NewLine, tmp);
        return result;
    }
}