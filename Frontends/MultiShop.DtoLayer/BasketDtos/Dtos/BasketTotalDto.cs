﻿namespace MultiShop.DtoLayer.BasketDtos.Dtos
{
    public class BasketTotalDto
    {
        public string UserID { get; set; }

        public string DiscountCode { get; set; }

        public int DiscountRate { get; set; }

        public List<BasketItemDto> BasketItems { get; set; }

        public decimal TotalPrice { get => BasketItems.Sum(X => X.Price * X.Quantity); }
    }
}
