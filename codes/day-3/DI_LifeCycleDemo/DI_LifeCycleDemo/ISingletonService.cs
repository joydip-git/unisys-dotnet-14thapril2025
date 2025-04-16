using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public interface ISingletonService : IReportServiceLifetime
    {      
        ServiceLifetime IReportServiceLifetime.Lifetime => ServiceLifetime.Singleton;
    }
}
