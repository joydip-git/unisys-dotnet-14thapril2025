namespace OOP_Revision
{
    class Employee : Person
    {
		private double salary;

		public double Salary
		{
			get { return salary; }
			set { salary = value; }
		}
		public Employee() { }
		public Employee(string name, double salary) : base(name)
		{
			this.salary = salary;
		}		
		public override string PrintInfo() => $"{base.PrintInfo()},{salary}";
	}
}
