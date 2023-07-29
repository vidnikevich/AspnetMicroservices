using Ocelot.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddDebug();
builder.Logging.AddConsole();
builder.Configuration.
    AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services.AddOcelot()
                .AddCacheManager(settings => settings.WithDictionaryHandle());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

await app.RunAsync();
