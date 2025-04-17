using System.Reflection;

namespace DelegateBasics
{
    //delegate looks like prototype of the function(s) to be called using this delegate
    //Note: you can't call any method whose signature DOES NOT match to that of the delegate signature
    delegate void CalDel(int a, int b);

    class Calculation
    {
        public static void Add(int x, int y) => Console.WriteLine(x + y);
        public void Subtract(int x, int y) => Console.WriteLine(x - y);
    }
    internal class Program
    {
        static void Main()
        {
            //Add(12, 13);
            //Subtract(12, 3);
            //ThreadStart addthrdDel = new ThreadStart()
            //Thread addThrd = new Thread()
            //addThrd.Start();
            //Calculation.Add(1, 2);

            //MethodInfo addMethodInfo = typeof(Calculation).GetMethod("Add");
            //CalDel addDel = new CalDel(Calculation.Add);
            CalDel addDel = Calculation.Add;

            Calculation calculation = new Calculation();
            //MethodInfo subMethodInfo = calculation.GetType().GerMethod("Add");
            //CalDel subDel = new CalDel(calculation.Subtract);
            CalDel subDel = calculation.Subtract;

            //CalDel multiDel = public void Multiply(int a, int b)
            //{ 
            //    Console.WriteLine(a + b);
            //};

            //anonymous method (2.0)
            //a delegate referring to an anonymous method is known as anonymous delegate
            CalDel multiDel = delegate (int a, int b)
            {
                Console.WriteLine(a * b);
            };

            //Lambda Expression (3.0) -> expression style anonymous method
            //Lanbda operator (=>)
            //CalDel divDel = (int a, int b) => Console.WriteLine(a / b);
            //CalDel divDel = (a, b) => Console.WriteLine(a / b);
            //Type inference
            CalDel divDel = (a, b) =>
            {
                if (b == 0)
                    throw new Exception("b is zero");
                Console.WriteLine(a / b);
            };

            //addDel(12, 13);
            //subDel.Invoke(12, 3);
            CallMethods(addDel, 12, 13);
            CallMethods(subDel, 12, 3);
            CallMethods(multiDel, 12, 3);
            CallMethods(divDel, 12, 3);
        }
        static void CallMethods(CalDel calDel, int m, int n)
        {
            calDel(m, n);
        }
    }
}
