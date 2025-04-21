using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Welcome to configuration managed by hosting!");
Dictionary<string, string?> inMemoryKeyValues = new Dictionary<string, string?>();
inMemoryKeyValues.Add("Profile", "Development");

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
ConfigurationManager manager = builder.Configuration;
manager.AddInMemoryCollection(inMemoryKeyValues);

//behind the Configuration object was registered as service for you
//builder.Services.AddScoped<IConfiguration,ConfigurationManager>();

IHost host = builder.Build();

/*
 * //asking for DI of Confoguration Provider (for in-memory data source) without any scope
    IConfiguration configuration = host.Services.GetRequiredService<IConfiguration>();
 */

ReadInMemoryConfiguration(host.Services);

host.Run();
host.Dispose();

static void ReadInMemoryConfiguration(IServiceProvider container)
{
    var scope = container.CreateScope();
    var provider = scope.ServiceProvider;
    //asking for DI of Confoguration Provider (for in-memory data source) within a scope
    IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
    Console.WriteLine($"App Profile: {configuration["Profile"]}");

    scope.Dispose();
}