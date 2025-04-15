namespace PayRollApp.Models
{
    public class Employee
    {
        private readonly int id;
        private string name;
        private decimal basicPay;
        private decimal daPay;
        private decimal hraPay;
        private decimal totalPay;
        private static string company;

        //it is never called explicitly, rather runtime calls it implicitly, before any other constructor
        //it is never declared with any access specifier
        //hence can't be parameterized
        //this ctor is invoked ONLY one time, no matter how many instances you are creating and the very first instance that you create or access any other static member of the class
        //purpose is to assign values to static data members ONLY
        static Employee()
        {
            company = "Unisys";
            Console.WriteLine($"company name={company}");
        }

        public Employee() { Console.WriteLine("default ctor called"); }

        public Employee(int id, string name, decimal basicPay, decimal daPay, decimal hraPay)
        {
            Console.WriteLine("parameterized ctor called");
            this.id = id;
            this.name = name;
            this.basicPay = basicPay;
            this.daPay = daPay;
            this.hraPay = hraPay;
            //company = "Unisys";
        }

        public static string Company
        {
            get { return company; }
            set { company = value; }
        }

        public decimal HraPay
        {
            get { return hraPay; }
            set { hraPay = value; }
        }
        public decimal DaPay
        {
            get { return daPay; }
            set { daPay = value; }
        }
        public decimal BasicPay
        {
            get { return basicPay; }
            set { basicPay = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //read-only properties
        public int Id { get => id; }

        //read-only property with expression body syntax
        public decimal TotalPay => totalPay;

        //method with expression body syntax
        public void CalculateSalary() => totalPay = basicPay + daPay + hraPay;
    }
}
