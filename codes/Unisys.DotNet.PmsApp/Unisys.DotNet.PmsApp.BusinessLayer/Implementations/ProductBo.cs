using Unisys.DotNet.PmsApp.BusinessLayer.Abstractions;
using Unisys.DotNet.PmsApp.DataAccessLayer.Abstractions;
using Unisys.DotNet.PmsApp.Models;

namespace Unisys.DotNet.PmsApp.BusinessLayer.Implementations
{
    //primary constructor: used only when you have one ctor with args to assign value to data members
    public class ProductBo(IDaoContract<Product, int> dao) : IBoContract<Product, int>
    {
        //private readonly IDaoContract<Product, int> dao;

        //public ProductBo(IDaoContract<Product, int> dao) => this.dao = dao;

        public bool Add(Product item)
        {
            return false;
        }

        public Product? Fetch(int key)
        {
            try
            {
                if (key == 0)
                    throw new Exception("the id can't be zero");

                var record = dao.Get(key);
                if (record == null)
                    throw new Exception("no record found with given id: " + key);
                else
                    return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Product> FetchAll(SortChoice sortChoice = SortChoice.SortById)
        {
            try
            {
                var records = dao.GetAll();
                if (!records.Any())
                    throw new Exception("no record found...");

                /*
                 * switch (sortChoice)
                {
                    case SortChoice.SortById:
                        //Func<Product, int> idSort = p => p.Id;
                        result = records.OrderBy(p => p.Id);
                        break;
                    case SortChoice.SortByName:
                        //Func<Product, string> nameSort = p => p.Name;
                        result = records.OrderBy(p => p.Name);
                        break;
                    case SortChoice.SortByPrice:
                        //Func<Product, decimal> priceSort = p => p.Price;
                        result = records.OrderBy(p => p.Price);
                        break;
                    case SortChoice.SortByMake:
                        //Func<Product, string> nameSort = p => p.Make;
                        result = records.OrderBy(p => p.Make);
                        break;
                    case SortChoice.SortByYear:
                        //Func<Product, string> nameSort = p => p.Year;
                        result = records.OrderBy(p => p.Year);
                        break;
                    default:
                        //Func<Product, int> nameSort = p => p.Id;
                        result = records.OrderBy(p => p.Id);
                        break;
                }
                 */

                IOrderedEnumerable<Product>
                        result = sortChoice switch
                        {
                            SortChoice.SortById => records.OrderBy(p => p.Id),
                            SortChoice.SortByName => records.OrderBy(p => p.Name),
                            SortChoice.SortByPrice => records.OrderBy(p => p.Price),
                            SortChoice.SortByMake => records.OrderBy(p => p.Make),
                            SortChoice.SortByYear => records.OrderBy(p => p.Year),
                            _ => records.OrderBy(p => p.Id),
                        };
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(int key, Product item)
        {
            return false;
        }

        public bool Remove(int key)
        {
            return false;
        }
    }
}
