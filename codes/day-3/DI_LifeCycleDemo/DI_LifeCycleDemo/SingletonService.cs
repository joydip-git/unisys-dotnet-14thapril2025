using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public class SingletonService : ISingletonService
    {
        public Guid Id => Guid.NewGuid();
    }
}
