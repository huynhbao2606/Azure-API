using AzureAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AzureAPI.Entities;
using Microsoft.EntityFrameworkCore;
using AzureAPI.Dao;
using AzureAPI.Dao.IRepository;
using AzureAPI.DTO;
using AutoMapper;

namespace AzureAPI
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            IEnumerable<Product> products = await _unitOfWork.ProductRepository.GetEntities(
                filter: null,
                orderBy: null,
                includeProperties: "ProductType,ProductBrand");

            var productDto = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductDTO>>> GetSingleProduct(int id)
        {
            var query = await _unitOfWork.ProductRepository.GetEntities(
                filter: i => i.Id == id,
                orderBy: null,
                includeProperties: "ProductType,ProductBrand");

            Product product = query.FirstOrDefault();

            ProductDTO productdto = _mapper.Map<ProductDTO>(product);


            return Ok(productdto);
        }



    }
}
