using Unisys.DotNet.PmsApp.BusinessLayerCore.Abstractions;
using Unisys.DotNet.PmsApp.DataAccessLayerCore.Abstractions;
using Unisys.DotNet.PmsApp.ModelsCore;

namespace Unisys.DotNet.PmsApp.BusinessLayer.Implementations
{
    public class ProductBo : IBoContract<Product, int>
    {
        private readonly IDaoContract<Product, int> dao;

        public ProductBo(IDaoContract<Product, int> dao) => this.dao = dao;

        public bool Add(Product item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException("item is not null");

                return dao.Insert(item);
            }
            catch (Exception)
            {
                throw;
            }
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

        public IEnumerable<Product>? FetchAll(SortChoice sortChoice = SortChoice.SortById)
        {
            try
            {
                var records = dao.GetAll();
                if (!records.Any())
                    throw new Exception("no record found...");

                IOrderedEnumerable<Product>? result = null;
                switch (sortChoice)
                {
                    case SortChoice.SortById:
                        result = records.OrderBy(p => p.Id);
                        break;
                    case SortChoice.SortByName:
                        result = records.OrderBy(p => p.Name);
                        break;
                    case SortChoice.SortByPrice:
                        result = records.OrderBy(p => p.Price);
                        break;
                    case SortChoice.SortByMake:
                        result = records.OrderBy(p => p.Make);
                        break;
                    case SortChoice.SortByYear:
                        result = records.OrderBy(p => p.Year);
                        break;
                    default:
                        result = records.OrderBy(p => p.Id);
                        break;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(int key, Product item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException("item is null");
                if (key == 0)
                    throw new ArgumentException("key can't be zero");
                return dao.Update(key, item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(int key)
        {
            try
            {
                if (key == 0)
                    throw new ArgumentException("key can't be zero");
                return dao.Delete(key);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
