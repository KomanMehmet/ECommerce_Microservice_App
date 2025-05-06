using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductsWithCategoryDto
    {
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImageURL { get; set; }

        public string ProductDescription { get; set; }

        public ResultCategoryDto Category { get; set; }
    }
}
