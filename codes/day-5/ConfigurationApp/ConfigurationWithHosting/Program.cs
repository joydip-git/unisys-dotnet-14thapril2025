using ConfigurationWithHosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Welcome to configuration managed by hosting!");
Dictionary<string, string?> inMemoryKeyValues = new Dictionary<string, string?>();
inMemoryKeyValues.Add("Profile", "Production");

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
//configuraion provider builer
ConfigurationManager manager = builder.Configuration;
manager.AddInMemoryCollection(inMemoryKeyValues);
manager.AddJsonFile(@"appsettings.json", false, true);
manager.AddEnvironmentVariables();

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
    //reading from in-memory collection
    Console.WriteLine($"App Profile: {configuration["Profile"]}");

    //reading environment variable
    var profile = configuration.GetRequiredSection("Environment").GetValue<string>("APP_PROFILE");

    //Binding a section with a custom object
    var connection = configuration.GetRequiredSection($"Profile:{profile}:{nameof(DatabaseConnection)}").Get<DatabaseConnection>();
    Console.WriteLine(connection?.Database);
    scope.Dispose();
}