using AdminPanel.Dto;
using AdminPanel.IServices;

namespace AdminPanel.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IHttpClientFactory _clientFactory;

        public BlogPostService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<BlogPostDto>> GetBlogPostsAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.samairline.ir/v1/post");

            if (response.IsSuccessStatusCode)
            {
                var blogPosts = await response.Content.ReadAsAsync<IEnumerable<BlogPostDto>>();
                return blogPosts;
            }

            return null;
        }

        public async Task<BlogPostDto> GetBlogPostAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://api.samairline.ir/v1/post/{id}");

            if (response.IsSuccessStatusCode)
            {
                var blogPost = await response.Content.ReadAsAsync<BlogPostDto>();
                return blogPost;
            }

            return null;
        }

        public async Task CreateBlogPostAsync(BlogPostDto blogPost)
        {
            var client = _clientFactory.CreateClient();
            await client.PostAsJsonAsync("https://api.samairline.ir/v1/post", blogPost);
        }

        public async Task UpdateBlogPostAsync(int id, BlogPostDto blogPost)
        {
            var client = _clientFactory.CreateClient();
            await client.PutAsJsonAsync($"https://api.samairline.ir/v1/post/{id}", blogPost);
        }

        public async Task DeleteBlogPostAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            await client.DeleteAsync($"https://api.samairline.ir/v1/post/{id}");
        }
    }
}
