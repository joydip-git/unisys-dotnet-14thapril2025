using FirstApp;

namespace Sample //name is NOT equal to the app name
{
    internal class Program
    {
        //static void Main()
        //static void Main(string[] args)
        //static int Main(){return 0;}
        //static int Main(string[] args){return 0;}
        static void Main()
        {
            //x => variable or identifier
            //x => value type variable [stores the actual value]
            //int => value type data type
            int x = 10;
            Console.WriteLine("Value of x " + x);
            //string interpolation or string template
            Console.WriteLine($"value of x {x}");

            //anilPerson and sunilPerson =>both are reference type variables, storing references of two instances in the heap of Person class 
            //Person anilPerson = new Person(1,"anil");
            Person anilPerson = null;
            anilPerson = new(1, "anil");

            anilPerson.Name = "anil kumar";
            Console.WriteLine(anilPerson.Name);

            Person sunilPerson = null;
            sunilPerson = new(2, "sunil");

            string info = anilPerson.PrintInfo();
            Console.WriteLine(info);
            Add(12, 13);
            Console.WriteLine("Hello to .NET and C#!");
            Console.WriteLine("press any key to close the app: ");
            Console.ReadKey();
        }
        static int Add(int x, int y)
        {
            int res = x + y;
            return res;
        }
    }
}
