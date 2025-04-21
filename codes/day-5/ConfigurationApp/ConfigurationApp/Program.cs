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
//reading data from a section in settings file
var profile = configuration.GetRequiredSection("Environment").GetValue<string>("APP_PROFILE");

//Binding a custom object to a configuration section
var dbConnection = configuration.GetRequiredSection($"Profile:{profile}:{nameof(DatabaseConnection)}").Get<DatabaseConnection>();

if (dbConnection != null)
    Console.WriteLine(dbConnection?.Database);
else
    Console.WriteLine("not found...");

//reading from in-memory collection
Console.WriteLine($"App Profile: {configuration["Profile"]}");
Console.WriteLine($"App Profile: {profile}");
