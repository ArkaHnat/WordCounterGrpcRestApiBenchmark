////Write a program (and prove that it works, we expect you to write automated tests) that:
////Given a text file, count the occurrence of each unique word in the file.
//// For example; a file containing the string “Go do that thing that you do so well” should find these counts:
////1: Go
////2: do
////    2: that
////    1: thing
////    1: you
////    1: so
////    1: well

////    Please, provide the solution using C#.
////You also can use any FP language if you have experience with.

using NSwag;
using WordCounterNs.Shared;
using WordCounterNs.Shared.Rest;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IOptionalDependecy, OptionalDependecny>();
builder.Services.AddTransient<IRestWordCounterService, RestWordCounterService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(documet =>
{
    documet.DocumentName = "v1";
    documet.PostProcess = document =>
    {
        document.ExternalDocumentation = new OpenApiExternalDocumentation
        {
            Description = "Redoc documentation",
            Url = "/redoc"
        };
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.MapGrpcService<WordCounterService>().AddToGrpcBrowserWithService<IWordCounterService>();

app.UseRouting();
app.UseOpenApi();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUi();
    app.UseReDoc(options => { options.Path = "/redoc"; });
}

app.UseHttpsRedirection();
app.Run();