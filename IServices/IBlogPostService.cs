using AdminPanel.Dto.BlogPost;

namespace AdminPanel.IServices
{
    public interface IBlogPostService
    {
        Task<IEnumerable<GetBlogPostDto>> GetBlogPostsAsync();
        Task<GetBlogPostDto> GetBlogPostAsync(int id);
        Task CreateBlogPostAsync(CreateBlogPostDto blogPost);
        Task UpdateBlogPostAsync(int id, UpdateBlogPostDto blogPost);
        Task DeleteBlogPostAsync(int id);
    }
}
