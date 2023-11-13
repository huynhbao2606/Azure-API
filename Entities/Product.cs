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


        public int BrandId { get; set; }
        public ProductBrand Brand { get; set; }

        public int TypeId { get; set; }
        public ProductType Type { get; set; }
    }
}
