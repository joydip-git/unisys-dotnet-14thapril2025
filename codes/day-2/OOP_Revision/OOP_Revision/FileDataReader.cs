namespace OOP_Revision
{
    class FileDataReader : Reader
    {
        string filePath;
        public FileDataReader() { }
        public FileDataReader(string filePath)
        {
            this.filePath = filePath;
        }

        public override void ReadData()
        {
            //fetch the data from file and set it to Data property
            Data = "file data";
        }
    }
}
