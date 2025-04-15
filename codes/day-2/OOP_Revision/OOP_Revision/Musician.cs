namespace OOP_Revision
{
    class Musician : Person
    {
        private string instrument;

        public string Instrument
        {
            get { return instrument; }
            set { instrument = value; }
        }
        public Musician() { }

        public Musician(string name, string instrument) : base(name)
        {
            this.instrument = instrument;
        }

        public override string PrintInfo() => $"{base.PrintInfo()},{instrument}";

    }
}
