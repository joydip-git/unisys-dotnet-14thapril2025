using Unisys.DotNet.PmsApp.DataAccessLayer.Abstractions;
using Unisys.DotNet.PmsApp.Models;

namespace Unisys.DotNet.PmsApp.DataAccessLayer.Implementations
{
    public class ProductDao : IDaoContract<Product, int>
    {
        public bool Delete(int uniqueId)
        {
            return false;
        }

        public Product? Get(int uniqueId)
        {
            return null;
        }

        public IEnumerable<Product> GetAll()
        {
            return [];
        }

        public bool Insert(Product entity)
        {
            return false;
        }

        public bool Update(int uniqueId, Product updatedEntity)
        {
            return false;
        }
    }
}
