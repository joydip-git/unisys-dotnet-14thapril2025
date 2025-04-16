using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DI_LifeCycleDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //a collection of services, which will be dependency injected in other dependent parties

            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            
            //Services property of HostApplicationBuilder returns you the reference of "existing" ServiceCollection instance
            //IServiceCollection serviceRegistry = builder.Services;
            
            //or
            //manual service collection creation (without help of host)
            //IServiceCollection serviceRegistry = new ServiceCollection();

            //serviceRegistry.AddSingleton<ISingletonService, SingletonService>();
            //serviceRegistry.AddScoped<IScopedService, ScopedService>();
            //serviceRegistry.AddTransient<ITransientService, TransientService>();
            //serviceRegistry.AddTransient<ServiceLifetimeReporter>();

            builder.Services.AddSingleton<ISingletonService, SingletonService>();
            builder.Services.AddScoped<IScopedService, ScopedService>();
            builder.Services.AddTransient<ITransientService, TransientService>();
            builder.Services.AddTransient<ServiceLifetimeReporter>();
            
            //IServiceProvider container = serviceRegistry.BuildServiceProvider();

            IHost host = builder.Build();

            //Services property of IHost returns the reference of the container (IServiceProvider) instance
            IServiceProvider container = host.Services;

            ManageServices(container, "Lifetime-1");
            ManageServices(container, "Lifetime-2");

            //runs your application and blocks the current thread...
            host.Run();

            //Console.WriteLine("press any key to terminate..");
            //Console.ReadKey();
        }
        static void ManageServices(IServiceProvider container, string lifetime)
        {
            Console.WriteLine("in manage service");
            //create a context for services
            IServiceScope scope = container.CreateScope();
            IServiceProvider provider = scope.ServiceProvider;

            //creating context bound service (Excpet the singletom, because singleton instance is singleton through the app)
            ServiceLifetimeReporter reporter = provider.GetRequiredService<ServiceLifetimeReporter>();
            reporter.ReportService($"{lifetime}: Call-1 to provider to log services instances");

            Console.WriteLine("\n\n");

            reporter = provider.GetRequiredService<ServiceLifetimeReporter>();
            reporter.ReportService($"{lifetime}: Call-2 to provider to log services instances");

            scope.Dispose();

            Console.WriteLine("\n");
        }
    }
}
