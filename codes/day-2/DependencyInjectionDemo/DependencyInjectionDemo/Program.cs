using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionDemo
{
    internal class Program
    {
        //T => Type parameter
        static void Add<T>(T x, T y)
        {

        }
        static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            //register services
            ServiceDescriptor managerDescriptor =
                new ServiceDescriptor(
                    serviceType: typeof(IDataManager),
                    implementationType: typeof(UpdatedDataManager),
                    lifetime: ServiceLifetime.Singleton
                    );
            serviceCollection.Add(managerDescriptor);

            switch (choice)
            {
                case 1:
                    serviceCollection.AddSingleton<IDataReader, FileDataReader>();
                    break;

                case 2:
                    serviceCollection.AddSingleton<IDataReader, DbDataReader>();
                    break;

                default:
                    break;
            }


            IServiceProvider container = serviceCollection.BuildServiceProvider();
            return container;
        }
        static void Main()
        {
            Console.WriteLine("1. from file \n2. from database");
            Console.Write("enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            //Container container = Container.Create();
            //IDataManager? manager = container.GetService<IDataManager, DataManager>();

            IServiceProvider container = ConfigureServices();
            //IDataReader reader =  container.GetRequiredService<IDataReader>();
            IDataManager? manager = container.GetService<IDataManager>();
            //Console.WriteLine(manager?.FetchChoice);
            Console.WriteLine(manager?.GetData());
        }
    }
}
