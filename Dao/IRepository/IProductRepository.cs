using AzureAPI.Entities;

namespace AzureAPI.Dao
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProduct();

        Task<Product> GetProductById(int id);
    }
}