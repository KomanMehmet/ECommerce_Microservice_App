﻿using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";

            var parameters = new DynamicParameters();

            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "delete from Coupons where CouponID = @couponId";

            var parameters = new DynamicParameters();

            parameters.Add("@couponId", couponId);

            using (var connection = _dapperContext.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);
            }   
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "select * from Coupons";

            using (var connection = _dapperContext.CreateConnection()) 
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }   
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
        {
            string query = "select * from Coupons where CouponID = @couponId";

            var parameters = new DynamicParameters();

            parameters.Add("@couponId", couponId);

            using (var connection = _dapperContext.CreateConnection()) 
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
                return value;
            }
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string couponCode)
        {
            string query = "select * from Coupons where Code = @couponCode";

            var parameters = new DynamicParameters();

            parameters.Add("@couponCode", couponCode);

            using (var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetDiscountCodeDetailByCode>(query, parameters);

                return value;
            }
        }

        public async Task<int> GetDiscountCouponCountAsync()
        {
            string query = "select count(*) from Coupons";

            using (var connection = _dapperContext.CreateConnection())
            {
                int couponCount = await connection.ExecuteScalarAsync<int>(query);

                return couponCount;
            }
        }

        public int GetDiscountRateByCode(string couponCode)
        {
            string query = "select Rate from Coupons where Code = @couponCode";

            var parameters = new DynamicParameters();

            parameters.Add("@couponCode", couponCode);

            using (var connection = _dapperContext.CreateConnection())
            {
                var rate = connection.QueryFirstOrDefault<int>(query, parameters);
                
                return rate;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "update Coupons set Code=@code,Rate=@rate,IsActive= @isActive,ValidDate=@validDate where CouponID = @couponId";

            var parameters = new DynamicParameters();

            parameters.Add("@couponId", updateCouponDto.CouponID);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
