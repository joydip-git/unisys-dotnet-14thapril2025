using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    internal class Program
    {
        static void Main()
        {
            //a collection of services, which will be dependency injected in other dependent parties
            IServiceCollection serviceRegistry = new ServiceCollection();
                      
            serviceRegistry.AddSingleton<ISingletonService, SingletonService>();
            serviceRegistry.AddScoped<IScopedService, ScopedService>();
            serviceRegistry.AddTransient<ITransientService, TransientService>();
            serviceRegistry.AddTransient<ServiceLifetimeReporter>();


            IServiceProvider container = serviceRegistry.BuildServiceProvider();

            ManageServices(container, "Lifetime-1");
            ManageServices(container, "Lifetime-2");

        }
        static void ManageServices(IServiceProvider container,string lifetime)
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
