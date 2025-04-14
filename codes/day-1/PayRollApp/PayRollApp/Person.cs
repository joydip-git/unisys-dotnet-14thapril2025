namespace PayRollApp
{
    class Person
    {
        private int id;
        private string name;
        private long mobileNo;

        public Person()
        {

        }

        public Person(int id, string name, long mobileNo)
        {
            this.id = id;
            this.name = name;
            this.mobileNo = mobileNo;
        }

        public long MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Id
        {
            get => id;
            set { id = value; }
        }
        public string GetInfo() => $"{id},{name},{mobileNo}";
    }
}
