namespace FirstApp
{
    class Person
    {
        //? top (type objet pointer)
        //? sbi (sync block index) => 0/1
        readonly int id; //only assignable through ctor. NO other ways.
        string name;

        public Person() { }
        public Person(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        //public void SetName(string name) => this.name = name;
        //public string GetName() => this.name;

        public string Name
        {
            //public void SetName(string name) => this.name = name;
            set => this.name = value;
            //public string GetName() => this.name;
            get => this.name;
        }

        //public int Id { get => this.id; }
        //read-only property expression body syntax
        public int Id => this.id;        

        //method expression body syntax
        //public void PrintInfo() => Console.WriteLine($"{id}, {name}");
        //method expression body syntax
        public string PrintInfo() => $"{id}, {name}";
    }
}
