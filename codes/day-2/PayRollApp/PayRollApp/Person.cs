namespace PayRollApp
{
    class A
    {
        private string name;
        private string location;
        private string salary;

        public A()
        {
            Console.WriteLine("default ctor of A");
        }

        public A(string name, string location, string salary)
        {
            Console.WriteLine("overloaded ctor of A");
            this.name = name;
            this.location = location;
            this.salary = salary;
        }
    }
    class B : A
    {
        string someData;

        public B() { Console.WriteLine("default ctor of B"); }

        public B(string name, string location, string salary, string someData) : base(name, location, salary)
        {
            Console.WriteLine("overloaded ctor of B");
            this.someData = someData;
        }
    }
}
