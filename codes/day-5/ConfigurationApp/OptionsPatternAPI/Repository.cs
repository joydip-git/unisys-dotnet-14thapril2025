using Microsoft.Extensions.Options;

namespace OptionsPatternAPI
{
    public class Repository
    {
        private readonly UnisysDbConStr unisysDbConStr;
        //public Repository(UnisysDbConStr dbConStr) => DONT use this

        //public Repository(IOptions<UnisysDbConStr> dbConStr)
        public Repository(IOptionsSnapshot<UnisysDbConStr> dbConStr)
        {
            //unisysDbConStr = dbConStr;
            unisysDbConStr = dbConStr.Value;
        }

        public void GetData()
        {
            Console.WriteLine(unisysDbConStr.Server == null || unisysDbConStr.Server == string.Empty ? "NA" : unisysDbConStr.Server);
        }
    }
}
