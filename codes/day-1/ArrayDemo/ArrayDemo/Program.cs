namespace ArrayDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Array (system namespace)
            //Array numbers = new Array(int,3);
            int[] numbers = new int[3];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"enter value at numbers[{i}]: ");
                int x = int.Parse(Console.ReadLine());//10 -> "10" ->
                numbers[i] = x;
            }
            Console.WriteLine("\n");
            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }

            string[] names = new string[3];
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"value at names[{i}]: {names[i]}");
                Console.Write($"enter name at names[{i}]: ");
                names[i] = Console.ReadLine();
            }

            int[,] matrix = new int[2, 2];
        }
    }
}
