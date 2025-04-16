using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public class ScopedService : IScopedService
    {
        public Guid Id => Guid.NewGuid();
    }
}
