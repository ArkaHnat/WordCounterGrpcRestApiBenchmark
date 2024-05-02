using Microsoft.AspNetCore.Mvc;
using WordCounterNs.Shared.Rest;

namespace WordCounterNs.Controllers;

[ApiController]
[Route("[controller]")]
public class WordCounterController : ControllerBase
{
    private readonly ILogger<WordCounterController> logger;
    private readonly IRestWordCounterService wcService;

    public WordCounterController(IRestWordCounterService wcService, ILogger<WordCounterController> logger)
    {
        this.wcService = wcService;
        this.logger = logger;
    }

    [HttpPost("PostFileSync")]
    [ProducesResponseType<Dictionary<string, int>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RestWordCounterResponse>> PostFileSync(IFormFile uploadedFile)
    {
        var content = await WordHelpers.ReadFormFileAsync(uploadedFile);

        if (string.IsNullOrWhiteSpace(content))
        {
            return this.BadRequest("File is IsNullOrWhiteSpace");
        }

        return new RestWordCounterResponse
        {
            Content = this.wcService.CountWordsWithLinq(content)
        };
    }

    [HttpPost("CountWordsWithoutLinq")]
    [ProducesResponseType<RestWordCounterResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RestWordCounterResponse>> CountWordsWithoutLinq(RestWordCounterRequest request)
    {
        var content = request.Content;

        if (string.IsNullOrWhiteSpace(content))
        {
            return this.BadRequest("File is IsNullOrWhiteSpace");
        }

        return new RestWordCounterResponse
        {
            Content = this.wcService.CountWordsWithoutLinq(content)
        };
    }

    [HttpPost("CountWordsWithLinq")]
    [ProducesResponseType<RestWordCounterResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RestWordCounterResponse>> CountWordsWithLinq(RestWordCounterRequest request)
    {
        var content = request.Content;

        if (string.IsNullOrWhiteSpace(content))
        {
            return this.BadRequest("File is IsNullOrWhiteSpace");
        }

        return new RestWordCounterResponse
        {
            Content = this.wcService.CountWordsWithLinq(content)
        };
    }
}