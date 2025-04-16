using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public sealed class TransientService : ITransientService
    {
        public TransientService()
        {
            Console.WriteLine($"Tranisent created...");
        }
        Guid IReportServiceLifetime.Id { get; } = Guid.NewGuid();
    }
}
