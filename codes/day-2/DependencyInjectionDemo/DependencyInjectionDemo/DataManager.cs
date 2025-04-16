namespace DependencyInjectionDemo
{
    class DataManager
    {
        int fetchChoice;
        public DataManager(int choice)
        {
            fetchChoice = choice;
        }
        public string GetData()
        {
            string data = string.Empty;
            switch (fetchChoice)
            {
                case 1:
                    FileDataReader filereader = new FileDataReader();
                    data = filereader.ReadData();
                    break;

                case 2:
                    DbDataReader dbreader = new DbDataReader();
                    data = dbreader.ReadData();
                    break;

                default:
                    break;
            }
            return data;
        }
    }
}
