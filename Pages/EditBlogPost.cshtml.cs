using AdminPanel.Dto;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class EditBlogPostModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IFileUploadService _fileUploadService;

        public EditBlogPostModel(IBlogPostService blogPostService, IFileUploadService fileUploadService)
        {
            _blogPostService = blogPostService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public BlogPostDto BlogPost { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            BlogPost = await _blogPostService.GetBlogPostAsync(id);

            if (BlogPost == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                BlogPost.ImageLink = await _fileUploadService.UploadFileAsync(Image);
            }

            await _blogPostService.UpdateBlogPostAsync(id, BlogPost);

            return RedirectToPage("./BlogPosts");
        }
    }
}
