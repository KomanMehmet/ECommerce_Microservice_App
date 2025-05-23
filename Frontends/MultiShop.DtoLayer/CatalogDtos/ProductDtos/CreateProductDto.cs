﻿namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImageURL { get; set; }

        public string ProductDescription { get; set; }

        public string CategoryID { get; set; }
    }
}
