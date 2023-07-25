using AdminPanel.Dto.BlogPost;
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

        public async Task<IEnumerable<GetBlogPostDto>> GetBlogPostsAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.samairline.ir/v1/post");

            if (response.IsSuccessStatusCode)
            {
                var blogPosts = await response.Content.ReadAsAsync<IEnumerable<GetBlogPostDto>>();
                return blogPosts;
            }

            return null;
        }

        public async Task<GetBlogPostDto> GetBlogPostAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://api.samairline.ir/v1/post/{id}");

            if (response.IsSuccessStatusCode)
            {
                var blogPost = await response.Content.ReadAsAsync<GetBlogPostDto>();
                return blogPost;
            }

            return null;
        }

        public async Task CreateBlogPostAsync(CreateBlogPostDto blogPost)
        {
            var client = _clientFactory.CreateClient();
            await client.PostAsJsonAsync("https://api.samairline.ir/v1/post", blogPost);
        }

        public async Task UpdateBlogPostAsync(int id, UpdateBlogPostDto blogPost)
        {
            var client = _clientFactory.CreateClient();
            await client.PutAsJsonAsync($"https://api.samairline.ir/v1/post/{id}", blogPost);
        }

        public async Task DeleteBlogPostAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://api.samairline.ir/v1/post/{id}");

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
