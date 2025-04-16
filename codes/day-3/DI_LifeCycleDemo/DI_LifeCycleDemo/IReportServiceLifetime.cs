using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public interface IReportServiceLifetime
    {
        Guid Id { get; }
        ServiceLifetime Lifetime { get; }
    }
}
