namespace OOP_Revision
{
    interface IA { void M(); void M1(); }
    interface IB { void M(); void M2(); }

    class C : IA, IB
    {
        //implicit implementation
        public void M() { Console.WriteLine("M implemented in C"); }

        //explicit implementation
        //void IA.M() { Console.WriteLine("M from IA"); }
        //void IB.M() { Console.WriteLine("M from IB"); }

        public void M1() { Console.WriteLine("M1 from IA implemented in C"); }
        public void M2() { Console.WriteLine("M2 from IB implemented in C"); }
    }
    class D:IA, IB
    {
        public void M() { Console.WriteLine("M from IA/IB implemented in D"); }
        public void M1() { Console.WriteLine("M1 from IA implemented in D"); }
        public void M2() { Console.WriteLine("M2 from IB implemented in D"); }
    }
}
