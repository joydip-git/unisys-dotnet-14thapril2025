using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionDemo
{
    internal class Program
    {
        //T => Type parameter
        static void Add<T>(T x, T y)
        {

        }
        static void Main()
        {
            Console.WriteLine("1. from file \n2. from database");
            Console.Write("enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            //Container container = Container.Create();
            //IDataManager? manager = container.GetService<IDataManager, DataManager>();

            IServiceCollection container = new ServiceCollection();
            //register services
            ServiceDescriptor managerDescriptor =
                new ServiceDescriptor(
                    serviceType: typeof(IDataManager),
                    implementationType: typeof(UpdatedDataManager),
                    lifetime: ServiceLifetime.Singleton
                    );
            container.Add(managerDescriptor);

            switch (choice)
            {
                case 1:
                    container.AddSingleton<IDataReader, FileDataReader>();
                    break;

                case 2:
                    container.AddSingleton<IDataReader, DbDataReader>();
                    break;

                default:
                    break;
            }
            
            
            IServiceProvider provider = container.BuildServiceProvider();
            //IDataReader reader =  provider.GetRequiredService<IDataReader>();
            IDataManager? manager = provider.GetService<IDataManager>();
            Console.WriteLine(manager?.FetchChoice);
            Console.WriteLine(manager?.GetData());
        }
    }
}
