namespace DI_LifeCycleDemo
{
    public class ServiceLifetimeReporter
    {
        private ISingletonService singletonService;
        private ITransientService transientService;
        private IScopedService scopedService;

        public ServiceLifetimeReporter(ISingletonService singletonService, ITransientService transientService, IScopedService scopedService)
        {
            this.singletonService = singletonService;
            this.transientService = transientService;
            this.scopedService = scopedService;
        }

        public void ReportService(string lifetimeDetails)
        {
            Console.WriteLine(lifetimeDetails);

            LogService<ISingletonService>(singletonService, "always same guid");

            LogService<IScopedService>(scopedService, "different guid with differnt lifetime/scope, but same guid for one lifetime/scope");

            LogService<ITransientService>(transientService, "always different guid");
        }

        private static void LogService<T>(T service, string message) where T : IReportServiceLifetime => Console.WriteLine(
            $"{typeof(T).Name}:{service.Id} =>{message}");
    }
}
