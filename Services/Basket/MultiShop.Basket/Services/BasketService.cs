using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);//kullanıcı ID'sine göre sepeti sil
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);//kullanıcı ID'sine göre sepeti getir

            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserID, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
