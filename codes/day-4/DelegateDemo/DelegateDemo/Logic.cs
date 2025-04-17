namespace DelegateDemo
{
    public class Logic
    {
        public static bool IsEven(int x) => x % 2 == 0;
        //create a instance method for checking a number is odd or not
        public bool IsOdd(int x) => x % 2 != 0;
        //public bool IsGreater(int a) => a > 5 ? true : false;
    }
}
