namespace OOP_Revision
{
    interface IOperations
    {
        //by default public
        //by default abstract
        //do not use those accesss specifier and modifier
        void ReadData();        
    }
    interface IData
    {
        string Data { get; }
    }
}
