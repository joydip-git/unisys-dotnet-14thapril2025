using Microsoft.Extensions.DependencyInjection;

namespace first_dotnet_app;

public class Program
{
    public static void Main()
    {
        Console.WriteLine($"hello...");

        IServiceCollection container = new ServiceCollection();
    }
}
