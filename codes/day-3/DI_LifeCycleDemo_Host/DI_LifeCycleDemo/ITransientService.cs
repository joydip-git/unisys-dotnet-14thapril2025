using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public interface ITransientService : IReportServiceLifetime
    {
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Transient;
    }
}
