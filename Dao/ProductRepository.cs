using AzureAPI.Data;
using AzureAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureAPI.Dao
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product.FindAsync(id);
        }
    }
}
