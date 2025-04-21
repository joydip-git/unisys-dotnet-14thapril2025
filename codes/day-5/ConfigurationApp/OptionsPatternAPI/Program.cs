using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OptionsPatternAPI;

Console.WriteLine("Using Options API in configuration...");

HostApplicationBuilder builder = Host.CreateApplicationBuilder();

builder.Configuration.AddJsonFile(@"appsettings.json", false, true);

//registering a configuration provider (through options api) which will read data from section "UnisysDbConStr" in appsettings.json file and produce an object of UnisysDbConStr with those data
//actually an object of type implementing IOptions<T> will be created when Repository object is created and depndency injected in the repository object. the IOptions<T> will contain an instance of T with data as pre-populated from appsettings.json section of the same name as that of T
builder
    .Services
    .Configure<UnisysDbConStr>(
    builder.Configuration.GetRequiredSection($"ConnectionStrings:{nameof(UnisysDbConStr)}")
    );
//this code will create an instance of UnisysDbConStr without any data from settings file
//builder.Services.AddScoped<UnisysDbConStr>();

builder.Services.AddSingleton<Repository>();

IHost host = builder.Build();

var repo = host.Services.GetRequiredService<Repository>();
repo.GetData();

host.Run();
host.Dispose();
