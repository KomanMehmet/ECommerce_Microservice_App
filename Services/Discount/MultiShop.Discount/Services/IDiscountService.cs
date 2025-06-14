﻿using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();

        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);

        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);

        Task DeleteDiscountCouponAsync(int couponId);

        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId);

        Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string couponCode);

        int GetDiscountRateByCode(string couponCode);

        Task<int> GetDiscountCouponCountAsync();
    }
}
