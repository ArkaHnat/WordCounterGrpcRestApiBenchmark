using GrpcBrowser.Configuration;
using ProtoBuf.Grpc.Server;
using WordCounterNs.Shared;
using WordCounterNs.Shared.Grpc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddCodeFirstGrpc();
builder.Services.AddGrpcBrowser();
builder.Services.AddSingleton<IOptionalDependecy, OptionalDependecny>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<GrpcWordCounterService>()
    .AddToGrpcBrowserWithService<IGrpcWordCounterService>();

app.UseRouting();
app.UseGrpcBrowser();
app.MapGrpcBrowser();
app.MapGet("/", context =>
{
    context.Response.StatusCode = 302;
    context.Response.Headers.Add("Location", "https://localhost:7262/grpc");
    return Task.CompletedTask;
});

app.Run();