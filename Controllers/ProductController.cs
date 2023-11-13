using AzureAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AzureAPI.Entities;
using Microsoft.EntityFrameworkCore;
using AzureAPI.Dao;

namespace AzureAPI
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;

        public ProductController(IProductRepository product)
        {
            _product = product;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> products = await _product.GetProduct();
    
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetSingleProduct(int id)
        {
            Product products = await _product.GetProductById(id);

            return Ok(products);
        }

    }
}
