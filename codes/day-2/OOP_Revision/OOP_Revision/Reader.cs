namespace OOP_Revision
{
    abstract class Reader
    {
        public Reader() { }
        string data;
        public string Data
        {
            get => data;
            protected set => data = value;
        }

        //abstract method is by default virtual
        public abstract void ReadData();
        //public abstract string Data { set; get; }
    }
}
