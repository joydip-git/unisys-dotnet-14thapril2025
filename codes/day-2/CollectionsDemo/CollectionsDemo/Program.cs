//using System.Collections;
namespace CollectionsDemo
{
    internal class Program
    {
        static void Main()
        {
            List<int> list = new List<int>();
            list.Add(5);//0
            list.Add(4);//1
            list.Add(1);//2 
            list.Add(3);//3 
            list.Add(2);//4 
            list.Add(6);//5 =>4

            //index<=number of elements
            list.Insert(6, 10);
            //Collections.Sort(list);
            list.Sort();

            //list.Remove(2);
            list.RemoveAt(4);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("\n");
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }           
            
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(1);
            set.Add(3);

            Console.WriteLine("\n");
            foreach (int item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
