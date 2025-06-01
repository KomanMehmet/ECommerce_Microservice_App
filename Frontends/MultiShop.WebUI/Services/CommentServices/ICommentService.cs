using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentAsync();

        Task CreateCommentAsync(CreateCommentDto createCommentDto);

        Task UpdateCommentyAsync(UpdateCommentDto updateCommentDto);

        Task DeleteCommentAsync(string id);

        Task<GetByIdCommentDto> GetByIdCommentAsync(string id);

        Task<List<GetCommentListByProductIdDto>> CommentListByProductId(string productId);
    }
}
