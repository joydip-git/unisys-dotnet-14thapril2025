using System;

namespace OOP_Revision
{
    internal class Program
    {
        static void Add(int x, int y)
        {
            Console.WriteLine(x + y);
        }
        static void Add(int x, int y, int z)
        {
            Console.WriteLine(x + y + z);
        }
        static void Add(int x, int y, long z)
        {
            Console.WriteLine(x + y + z);
        }
        static void Add(int x, long y, int z)
        {
            Console.WriteLine(x + y + z);
        }
        static void Main()
        {
            C cobj = new C();
            cobj.M();//-> possible if the method is implemented implicitly

            //implicit invocation of interace members
            cobj.M1();
            cobj.M2();

            //explicit invocation of interface members
            IA ia = cobj;
            ia.M();    
            
            IB ib = cobj;
            ib.M();
        }
        static void UseOOP()
        {
            //binding => method call -> appropriate method (by compiler)
            //during exact same method will be called
            Add(12, 14); //line 5
            Add(12, 13, 14);//line 9
            Add(12, 13, 123456789123);//line 13
            Add(12, 123456789123, 13);//line 17

            Console.WriteLine("1. Employee\n2. Musician");
            Console.Write("enter choice[1/2]: ");
            int choice = int.Parse(Console.ReadLine());
            //Employee employee = new Employee("anil",1000);
            //up-casting (create an instance of child clas and store the reference in the reference variable of base class
            Person person = null;
            switch (choice)
            {
                case 1:
                    person = new Employee("anil", 1000);
                    //Employee employee = new Employee("anil", 1000);
                    //Console.WriteLine(employee.PrintInfo());
                    break;

                case 2:
                    person = new Musician("joydip", "tabla");
                    //Musician musician = new Musician("joydip", "tabla");
                    //Console.WriteLine(musician.PrintInfo());
                    break;

                default:
                    break;
            }
            if (person != null)
            {
                //line 23 of Person.cs => line 25 of Musician or 23 of Employee
                string info = person.PrintInfo();
                Console.WriteLine(info);
            }
            //Reader reader = new Reader();
            //reader.ReadData();
            Reader fileReader = new FileDataReader(@"path");
            Reader dbReader = new DbDataReader(@"constr");
            fileReader.ReadData();
            dbReader.ReadData();

            Console.WriteLine(fileReader.Data);
            Console.WriteLine(dbReader.Data);
        }
    }
}
