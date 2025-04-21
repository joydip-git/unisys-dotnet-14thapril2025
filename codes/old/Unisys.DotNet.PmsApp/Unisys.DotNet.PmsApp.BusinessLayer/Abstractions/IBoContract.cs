using System.Collections.Generic;
using Unisys.DotNet.PmsApp.Models;

namespace Unisys.DotNet.PmsApp.BusinessLayer.Abstractions
{
    public interface IBoContract<T, TKey> where T : class
    {
        IEnumerable<T> FetchAll(SortChoice sortChoice = SortChoice.SortById);
        T Fetch(TKey key);
        bool Add(T item);
        bool Remove(TKey key);
        bool Modify(TKey key, T item);
    }
}
