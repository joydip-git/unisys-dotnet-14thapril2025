namespace DI_LifeCycleDemo
{
    public class ServiceLifetimeReporter
    {
        //every time same service if you even create multiple instances of SLR in different scopes
        private ISingletonService singletonService;
        //every time different service if you create multiple instances of SLR, does not matter same or differnt scope
        private ITransientService transientService;
        //if you create multiple instances of SLR in the same scope only one instance of scoped service wil be created, but for different scope, different instance will be used
        private IScopedService scopedService;

        public ServiceLifetimeReporter(ISingletonService singletonService, ITransientService transientService, IScopedService scopedService)
        {
            this.singletonService = singletonService;
            this.transientService = transientService;
            this.scopedService = scopedService;
            Console.WriteLine("SLR created...");
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
