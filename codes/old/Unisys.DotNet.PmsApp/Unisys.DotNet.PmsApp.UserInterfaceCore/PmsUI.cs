using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Unisys.DotNet.PmsApp.BusinessLayer.Implementations;
using Unisys.DotNet.PmsApp.BusinessLayerCore.Abstractions;
using Unisys.DotNet.PmsApp.DataAccessLayerCore.Abstractions;
using Unisys.DotNet.PmsApp.DataAccessLayerCore.Implementation;
using Unisys.DotNet.PmsApp.ModelsCore;
using Unisys.DotNet.PmsApp.RepositoryCore;

namespace Unisys.DotNet.PmsApp.UserInterfaceCore
{
    public class PmsUI
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"App Doamin={AppDomain.CurrentDomain.FriendlyName}");
            //AssemblyLoadContext

            //refer my code from Unisys.DotNet.PmsApp created using .NET 9
            try
            {
                //ILogger logger = LoggerFactory
                //    .Create(options=>options.AddConsole())
                //    .CreateLogger("info");

                HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
                RegisterServices(builder);

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
        }

        private static void InteractWithBusinessComponent(IServiceProvider container)
        {
            try
            {
                var scope = container.CreateScope();

                var provider = scope.ServiceProvider;
                var productBo = provider.GetRequiredService<IBoContract<Product, int>>();

                productBo?
                    .FetchAll()?
                    .ToList()
                    .ForEach(p => Console.WriteLine(p.Name));

                scope.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void RegisterServices(HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<IDaoContract<Product, int>, ProductDao>();
            builder.Services.AddScoped<IBoContract<Product, int>, ProductBo>();
        }
    }
}
