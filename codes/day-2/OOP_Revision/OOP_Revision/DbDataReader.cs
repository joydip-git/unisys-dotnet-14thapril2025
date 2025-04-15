namespace OOP_Revision
{
    class DbDataReader : Reader
    {
        string dbConStr;

        public DbDataReader() { }
        public DbDataReader(string dbConStr)
        {
            this.dbConStr = dbConStr;
        }

        //abstract method should be implemented with override keyword
        public override void ReadData()
        {
            //base.ReadData();
            //fetch the data from database and set it to Data property
            this.Data = $"db data";
        }
    }
}
