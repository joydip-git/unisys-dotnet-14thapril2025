using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Unisys.DotNet.PmsApp.DataAccessLayer.Abstractions;
using Unisys.DotNet.PmsApp.DataAccessLayer.Implementations;
using Unisys.DotNet.PmsApp.Repository;
using Unisys.DotNet.PmsApp.Models;
using Unisys.DotNet.PmsApp.BusinessLayer.Abstractions;
using Unisys.DotNet.PmsApp.BusinessLayer.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

try
{
    //ILogger logger = LoggerFactory
    //    .Create(options=>options.AddConsole())
    //    .CreateLogger("info");

    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    ConfigureServices(builder);

    IHost host = builder.Build();

    IServiceProvider container = host.Services;
    InteractWithBusinessComponent(container);

    host.Run();

    host.Dispose();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

static void ConfigureServices(IHostApplicationBuilder builder)
{
    //builder.Services.AddScoped<ProductRepository>();
    builder.Services.AddDbContext<ProductRepository>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("UnisysDbConStr")),
        ServiceLifetime.Scoped);
    builder.Services.AddScoped<IDaoContract<Product, int>, ProductDao>();
    builder.Services.AddScoped<IBoContract<Product, int>, ProductBo>();
}

static void InteractWithBusinessComponent(IServiceProvider serviceProvider)
{
    try
    {
        var scope = serviceProvider.CreateScope();

        var provider = scope.ServiceProvider;
        var productBo = provider.GetRequiredService<IBoContract<Product, int>>();

        productBo
            .FetchAll()
            .ToList()
            .ForEach(p => Console.WriteLine(p.Name));

        scope.Dispose();
    }
    catch (Exception)
    {
        throw;
    }
}
