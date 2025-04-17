namespace DelegateDemo
{
    internal class Program
    {
        //filter ONLY even numbers from the list and create a new list with those even numbers
        static List<int> Filter(List<int> input, TaskDel taskDel)
        {
            //create a new empty list
            //List<int> output = new List<int>();
            List<int> output = [];

            //iterate through the input list using foreach loop
            //check whether the number is even or not
            //if even, add the same into the empty list

            foreach (var item in input)
            {
                if (taskDel(item))
                    output.Add(item);
            }

            //return the list containing even numbers
            return output;
        }
        static void Main()
        {
            //source of data
            //create a list containing numbers from 0 ->9
            //List<int> numbers = new List<int> { 1, 3, 4, 2, 7, 5, 0, 6, 9, 8 };
            List<int> numbers = [1, 3, 4, 2, 7, 5, 0, 6, 9, 8];
            List<string> names = ["anil", "sunil", "joydip"];

            //call the Filter function and pass this list, which will return the new list containing only even numbers
            //TaskDel logic = Logic.IsEven;
            TaskDel logic = new Logic().IsOdd;
            //TaskDel logic = lambda for greater than
            var result = Filter(numbers, logic);
            //display all the even numbers from that list
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
