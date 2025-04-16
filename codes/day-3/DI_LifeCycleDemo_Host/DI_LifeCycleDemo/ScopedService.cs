using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public sealed class ScopedService : IScopedService
    {
        public ScopedService()
        {
            Console.WriteLine($"Scoped created...");
        }
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
