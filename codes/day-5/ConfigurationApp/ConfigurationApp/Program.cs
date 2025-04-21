using ConfigurationApp;
using Microsoft.Extensions.Configuration;

//Configurations in .NET
Console.WriteLine("welcome to configuations without Host....");

Dictionary<string, string?> inMemoryKeyValues = new Dictionary<string, string?>();
inMemoryKeyValues.Add("Profile", "Development");

var configBuilder = new ConfigurationBuilder();
configBuilder.AddInMemoryCollection(inMemoryKeyValues);
configBuilder.AddJsonFile(@"appsettings.json", false, true);
configBuilder.AddEnvironmentVariables();


//IConfigurationRoot inherits from IConfiguration
IConfigurationRoot configuration = configBuilder.Build();
var profile = configuration.GetRequiredSection("Environment").GetValue<string>("APP_PROFILE");
var dbConnection = configuration.GetRequiredSection("Profile").GetRequiredSection("Development").GetValue<DatabaseConnection>("DatabaseConnection");

if (dbConnection != null)
    Console.WriteLine(dbConnection.Server);
else
    Console.WriteLine("not found...");

    Console.WriteLine($"App Profile: {configuration["Profile"]}");
Console.WriteLine($"App Profile: {profile}");
