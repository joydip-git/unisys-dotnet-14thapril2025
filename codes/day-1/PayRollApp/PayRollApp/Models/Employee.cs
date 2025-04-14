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

        public Employee() { }

        public Employee(int id, string name, decimal basicPay, decimal daPay, decimal hraPay)
        {
            this.id = id;
            this.name = name;
            this.basicPay = basicPay;
            this.daPay = daPay;
            this.hraPay = hraPay;
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
