using AdminPanel.Dto.BlogPost;
using AdminPanel.IServices;

namespace AdminPanel.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly HttpClient _client;

        public BlogPostService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("MyHttpClientWithHeaders");
        }

        public async Task<IEnumerable<GetBlogPostDto>> GetBlogPostsAsync()
        {
            var response = await _client.GetAsync("https://api.samairline.ir/v1/post");

            if (response.IsSuccessStatusCode)
            {
                var blogPosts = await response.Content.ReadAsAsync<IEnumerable<GetBlogPostDto>>();
                return blogPosts;
            }

            return null;
        }

        public async Task<GetBlogPostDto> GetBlogPostAsync(int id)
        {
            var response = await _client.GetAsync($"https://api.samairline.ir/v1/post/{id}");

            if (response.IsSuccessStatusCode)
            {
                var blogPost = await response.Content.ReadAsAsync<GetBlogPostDto>();
                return blogPost;
            }

            return null;
        }

        public async Task CreateBlogPostAsync(CreateBlogPostDto blogPost)
        {
            await _client.PostAsJsonAsync("https://api.samairline.ir/v1/post", blogPost);
        }

        public async Task UpdateBlogPostAsync(int id, UpdateBlogPostDto blogPost)
        {
            await _client.PutAsJsonAsync($"https://api.samairline.ir/v1/post/{id}", blogPost);
        }

        public async Task DeleteBlogPostAsync(int id)
        {
            var response = await _client.DeleteAsync($"https://api.samairline.ir/v1/post/{id}");

            // Log the status code and response content for debugging
            Console.WriteLine($"Response status: {response.StatusCode}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response content: {content}");
            }
        }


    }
}
