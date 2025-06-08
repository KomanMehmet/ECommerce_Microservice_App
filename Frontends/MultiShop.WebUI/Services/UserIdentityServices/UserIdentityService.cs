using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShop.WebUI.Services.UserIdentityServices
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly HttpClient _httpClient;

        public UserIdentityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDto>> GetUserListAsync()
        {
            var response= await _httpClient.GetAsync("http://localhost:5001/api/users/GetUserList");

            var values = await response.Content.ReadFromJsonAsync<List<ResultUserDto>>();

            return values;
        }
    }
}
