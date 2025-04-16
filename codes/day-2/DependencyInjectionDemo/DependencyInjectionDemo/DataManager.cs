using System.ComponentModel;

namespace DependencyInjectionDemo
{
    public class DataManager : IDataManager
    {
        int fetchChoice;
        Container container;
        public DataManager() { container = Container.Create(); }
        public int FetchChoice { set => fetchChoice = value; get => fetchChoice; }
        public string? GetData()
        {
            string data = string.Empty;
            IDataReader? reader = null;
            switch (fetchChoice)
            {
                case 1:
                    reader = container.GetService<IDataReader, FileDataReader>();
                    break;

                case 2:
                    reader = container.GetService<IDataReader, FileDataReader>();
                    break;

                default:
                    break;
            }
            return reader?.ReadData();
        }
    }
}
