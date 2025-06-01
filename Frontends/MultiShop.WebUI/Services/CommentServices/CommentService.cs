using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetCommentListByProductIdDto>> CommentListByProductId(string productId)
        {
            var response = await _httpClient.GetAsync("comments/CommentListByProductId/" + productId);

            var values = await response.Content.ReadFromJsonAsync<List<GetCommentListByProductIdDto>>();

            return values;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync("Comments?id=" + id);
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var response = await _httpClient.GetAsync("comments");

            var values = await response.Content.ReadFromJsonAsync<List<ResultCommentDto>>();

            return values;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var response = await _httpClient.GetAsync("comments/" + id);

            var value = await response.Content.ReadFromJsonAsync<UpdateCommentDto>();

            return value;
        }

        public async Task UpdateCommentyAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
        }

        Task<GetByIdCommentDto> ICommentService.GetByIdCommentAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
