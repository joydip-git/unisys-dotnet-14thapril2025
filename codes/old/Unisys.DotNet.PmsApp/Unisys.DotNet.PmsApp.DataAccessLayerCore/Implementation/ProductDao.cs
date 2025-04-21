using Unisys.DotNet.PmsApp.DataAccessLayerCore.Abstractions;
using Unisys.DotNet.PmsApp.ModelsCore;
using Unisys.DotNet.PmsApp.RepositoryCore;

namespace Unisys.DotNet.PmsApp.DataAccessLayerCore.Implementation
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
            try
            {
                var products =_productRepository.Products;
                var exists = products.Any(p => p.Id == uniqueId);
                if (exists)
                {
                    var found = products.Where(p => p.Id == uniqueId).First();
                    products.Remove(found);
                    return true;
                }
                else
                    throw new Exception($"no product with id {uniqueId} found to delete");
            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                var products = _productRepository.Products;
                bool exists = products.Any(p => p.Id == entity.Id);
                if (exists)
                    throw new Exception($"product with same id: {entity.Id} exists");
                else
                {
                    products.Add(entity);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(int uniqueId, Product updatedEntity)
        {
            try
            {
                var products = _productRepository.Products;
                bool exists = products.Any(p => p.Id == uniqueId);
                if (!exists)
                    throw new Exception($"product with id: {uniqueId} does not exists to update");
                else
                {
                    var found = products.Where(p => p.Id == uniqueId).First();
                    found.Year = updatedEntity.Year;
                    found.Name = updatedEntity.Name;
                    found.Description = updatedEntity.Description;
                    found.Price = updatedEntity.Price;
                    found.Make = updatedEntity.Make;                    
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
