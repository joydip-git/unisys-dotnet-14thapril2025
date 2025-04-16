using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public sealed class SingletonService : ISingletonService
    {
        public SingletonService()
        {
            Console.WriteLine($"Singleton created...");
        }
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
