using System.Threading.Tasks;
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

        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _blogPostService.DeleteBlogPostAsync(Id);
            return RedirectToPage("./BlogPosts");
        }
    }
}
