using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public interface IScopedService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Scoped;
    }
}
