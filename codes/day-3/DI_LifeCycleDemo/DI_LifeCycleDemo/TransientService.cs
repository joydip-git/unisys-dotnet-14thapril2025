using Microsoft.Extensions.DependencyInjection;

namespace DI_LifeCycleDemo
{
    public class TransientService : ITransientService
    {
        public Guid Id => Guid.NewGuid();
    }
}
