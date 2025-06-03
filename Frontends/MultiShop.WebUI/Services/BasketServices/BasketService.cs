using MultiShop.DtoLayer.BasketDtos.Dtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket() ?? new BasketTotalDto();

            var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductID == basketItemDto.ProductID);

            if(existingItem == null)
            {
                values.BasketItems.Add(basketItemDto);
            }
            else
            {
                existingItem.Quantity += basketItemDto.Quantity;
            }

            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
        {
            return null;
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var response = await _httpClient.GetAsync("baskets");

            if(!response.IsSuccessStatusCode)
            {
                return new BasketTotalDto
                {
                    BasketItems = new List<BasketItemDto>()
                };
            }

            var values = await response.Content.ReadFromJsonAsync<BasketTotalDto>();

            return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();

            var itemToRemove = values.BasketItems.FirstOrDefault(x => x.ProductID == productId);

            if (itemToRemove == null)
                return false;

            var result = values.BasketItems.Remove(itemToRemove);
            
            await SaveBasket(values);

            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync("baskets", basketTotalDto);
        }
    }
}
