using AzureAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AzureAPI.Entities;
using Microsoft.EntityFrameworkCore;
using AzureAPI.Dao;
using AzureAPI.Dao.IRepository;
using AzureAPI.DTO;

namespace AzureAPI
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            IEnumerable<Product> products = await _unitOfWork.ProductRepository.GetEntities(
                filter: null,
                orderBy: null,
                includeProperties: "ProductType,ProductBrand");
    
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductDTO>>> GetSingleProduct(int id)
        {
            var query = await _unitOfWork.ProductRepository.GetEntities(
                filter: i => i.Id == id,
                orderBy: null,
                includeProperties: "ProductType,ProductBrand");

            Product product = query.FirstOrDefault();


            return Ok(new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            });
        }



    }
}
