using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Snapshooter.NUnit;
using WordCounterNs.Shared;
using WordCounterNs.Shared.Rest;

namespace WordCounterNs.Tests;

public class RestWordCounterServiceTests
{
    private readonly Fixture fixture = new();
    private RestWordCounterService sut;

    [SetUp]
    public void Setup()
    {
        this.fixture.Customize(new AutoMoqCustomization());
        this.sut = this.fixture.Create<RestWordCounterService>();
    }

    [Test]
    public void TestLongsString()
    {
        var filePath = "testData.txt";
        var fileContent = File.ReadAllText(filePath);

        var result = this.sut.CountWordsWithLinq(fileContent);
        var res = Counter.ConvertResultToOutputFormat(result);

        Snapshot.Match(res);
    }

    [TestCase("Go do that thing that you do so well", "1: Go\r\n2: do\r\n2: that\r\n1: thing\r\n1: you\r\n1: so\r\n1: well")]
    [TestCase("a", "1: a")]
    [TestCase("a A ", "2: a")]
    [TestCase("A a ", "2: A")]
    [TestCase("a | a ", "2: a")]
    [TestCase("a |a ", "2: a")]
    [TestCase("a 1 a ", "2: a\r\n1: 1")]
    [TestCase("a 1a ", "1: a\r\n1: 1a")]
    [TestCase("a b b", "1: a\r\n2: b")]
    [TestCase("b a ", "1: b\r\n1: a")]
    [TestCase("a b a", "2: a\r\n1: b")]
    [TestCase("\r\ta \nb \ra", "2: a\r\n1: b")]
    [TestCase("a b c  \r\nab\r\nb a", "2: a\r\n2: b\r\n1: c\r\n1: ab")]
    public void TestCases2(string content, string response)
    {
        var result = this.sut.CountWordsWithLinq(content);
        var res = WordCounterNs.Shared.Counter.ConvertResultToOutputFormat(result);
        var flattened = res.Replace(Environment.NewLine, "\r\n");
        res.Should()
            .Be(response);
    }
}