namespace DependencyInjectionDemo
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("1. from file \n2. from database");
            Console.Write("enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            DataManager manager = new DataManager(choice);
            Console.WriteLine(manager.GetData());
        }
    }
}
