using Microsoft.Extensions.Logging;
using Unisys.DotNet.PmsApp.DataAccessLayer.Abstractions;
using Unisys.DotNet.PmsApp.Models;
using Unisys.DotNet.PmsApp.Repository;

namespace Unisys.DotNet.PmsApp.DataAccessLayer.Implementations
{
    public sealed class ProductDao : IDaoContract<Product, int>
    {
        private readonly ProductRepository _productRepository;
        private readonly ILogger<ProductDao> _logger;

        public ProductDao(ProductRepository productRepository, ILogger<ProductDao> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
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
                _logger.LogInformation("fetching products");
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
