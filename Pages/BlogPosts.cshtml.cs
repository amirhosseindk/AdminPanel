using AdminPanel.Dto.BlogPost;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    [Authorize]
    public class BlogPostsModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostsModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
            BlogPosts = new List<GetBlogPostDto>();
        }

        public IEnumerable<GetBlogPostDto> BlogPosts { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _blogPostService.GetBlogPostsAsync();
            if (result != null)
            {
                BlogPosts = result;
            }
        }
    }
}
