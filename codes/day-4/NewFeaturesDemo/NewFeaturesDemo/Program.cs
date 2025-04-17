namespace NewFeaturesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //a=>explicitly typed local variable
            //int a = 10;

            //type inferenece (determining the data type of the variable from the assigned value)
            //x => implicitly typed local variable (3.0)
            var x = 10;
            Console.WriteLine(x);

            //explcitly typed array local variable
            //int[] values = new int[] { 1, 2, 3, 4 };
            //int[] values = [1, 2, 3, 4];

            //collection-initializer syntax (3.0)
            //values => implcitly typed array local variable
            var values = new[] { 1, 2, 3, 4 };
            var list1 = new List<int> { 1, 2, 3, 4 };
            //new syntax for collection-initializer
            var list = new List<int>[1, 2, 3, 4];

            //Nullable<int> data = null;
            //data = 10;
            int? data = null;
            if (data.HasValue)
                Console.WriteLine(data.Value);
            else
                Console.WriteLine("na");


            //string str = null;
            //if (str != null)
            //{
            //    string lower = str.ToLower();
            //    Console.WriteLine(lower);
            //}

            //null check
            string? str = null;
            //string? newStr = str == null ? null : str;

            //?? null-coalesce operator
            string? newStr = str ?? str;

            //null propagation (?.)
            Console.WriteLine(newStr?.ToLower());
        }
    }
}
