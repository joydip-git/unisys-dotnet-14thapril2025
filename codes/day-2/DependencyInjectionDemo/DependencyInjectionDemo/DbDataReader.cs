namespace DependencyInjectionDemo
{
    public class DbDataReader : IDataReader
    {
        public string ReadData()
        {
            return "database data";
        }
    }
}
