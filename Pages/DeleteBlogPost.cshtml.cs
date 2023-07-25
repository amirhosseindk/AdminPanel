using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class DeleteBlogPostModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;

        public DeleteBlogPostModel(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _blogPostService.DeleteBlogPostAsync(id);
            return RedirectToPage("./BlogPosts");
        }
    }
}
