using Unisys.DotNet.PmsApp.Models;

namespace Unisys.DotNet.PmsApp.BusinessLayer.Abstractions
{
    public interface IBoContract<T, TKey> where T : class
    {
        //optional argument with default value (4.0-2010)
        //optional arguments should be the last ones in the parameter list. before that all required arguments should be mentioned
        IEnumerable<T> FetchAll(SortChoice sortChoice = SortChoice.SortById);

        T? Fetch(TKey key);
        bool Add(T item);
        bool Remove(TKey key);
        bool Modify(TKey key, T item);
    }

    //class UI
    //{
    //    static void Main()
    //    {
    //        IBoContract<Product, int>? bo = null;
    //        bo?.FetchAll();
    //        bo?.FetchAll(SortChoice.SortByName);
    //    }
    //}
}
