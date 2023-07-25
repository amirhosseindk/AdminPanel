using AdminPanel.Dto;

namespace AdminPanel.IServices
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostDto>> GetBlogPostsAsync();
        Task<BlogPostDto> GetBlogPostAsync(int id);
        Task CreateBlogPostAsync(BlogPostDto blogPost);
        Task UpdateBlogPostAsync(int id, BlogPostDto blogPost);
        Task DeleteBlogPostAsync(int id);
    }
}
