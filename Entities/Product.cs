using Microsoft.EntityFrameworkCore;

namespace AzureAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description {get; set;}

        [Precision(38,2)]
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }


        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
