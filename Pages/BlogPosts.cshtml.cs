using AdminPanel.Dto;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class BlogPostsModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostsModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        public IEnumerable<BlogPostDto> BlogPosts { get; set; }

        public async Task OnGetAsync()
        {
            BlogPosts = await _blogPostService.GetBlogPostsAsync();
        }
    }
}
