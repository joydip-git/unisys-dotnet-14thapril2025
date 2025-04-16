namespace DependencyInjectionDemo
{
    public class UpdatedDataManager : IDataManager
    {
        //it will store reference of any class instance which implements IDataReader interface
        IDataReader reader;

        //constructor injection
        public UpdatedDataManager(IDataReader reader)
        {
            this.reader = reader;
        }

        [Obsolete("this property is legacy...do not use this")]
        public int FetchChoice { get; set; }

        public string? GetData()
        {
            string? data = reader.ReadData();
            if (data == null || data == string.Empty)
                throw new Exception("no data");
            else
                return data;
        }
    }
}
