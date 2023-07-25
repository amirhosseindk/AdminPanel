using AdminPanel.Dto;

namespace AdminPanel.IServices
{
    public interface IBlogPostService
    {
        Task<IEnumerable<CreateBlogPostDto>> GetBlogPostsAsync();
        Task<CreateBlogPostDto> GetBlogPostAsync(int id);
        Task CreateBlogPostAsync(CreateBlogPostDto blogPost);
        Task UpdateBlogPostAsync(int id, CreateBlogPostDto blogPost);
        Task DeleteBlogPostAsync(int id);
    }
}
