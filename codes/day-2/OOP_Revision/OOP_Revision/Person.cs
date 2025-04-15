namespace OOP_Revision
{
    class Person
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public Person() { }
		public Person(string name)
		{
			this.name = name;
		}
		public virtual string PrintInfo() => $"{name}";
	}
}
