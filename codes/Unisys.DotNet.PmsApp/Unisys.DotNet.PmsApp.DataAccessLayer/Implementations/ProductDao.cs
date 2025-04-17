using Unisys.DotNet.PmsApp.DataAccessLayer.Abstractions;
using Unisys.DotNet.PmsApp.Models;
using Unisys.DotNet.PmsApp.Repository;

namespace Unisys.DotNet.PmsApp.DataAccessLayer.Implementations
{
    public sealed class ProductDao : IDaoContract<Product, int>
    {
        private readonly ProductRepository _productRepository;

        public ProductDao(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool Delete(int uniqueId)
        {
            return false;
        }

        public Product? Get(int uniqueId)
        {
            try
            {
                var products = _productRepository.Products;
                //Func<Product, bool> checkDel = p => p.Id == uniqueId;
                bool exists = products.Any(p => p.Id == uniqueId);
                if (exists)
                    return products.Where(p => p.Id == uniqueId).First();
                else
                    return null;
            }
            catch (Exception) 
            { 
                throw;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            try
            {
                return _productRepository.Products;
            }
            catch (Exception)
            {
                throw;
            }
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
