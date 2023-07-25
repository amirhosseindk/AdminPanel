using AdminPanel.Dto;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class CreateBlogPostModel : PageModel
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IFileUploadService _fileUploadService;

        public CreateBlogPostModel(IBlogPostService blogPostService, IFileUploadService fileUploadService)
        {
            _blogPostService = blogPostService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public BlogPostDto BlogPost { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                BlogPost.ImageLink = await _fileUploadService.UploadFileAsync(Image);
            }

            BlogPost.CreatedAt = DateTime.Now;

            await _blogPostService.CreateBlogPostAsync(BlogPost);

            return RedirectToPage("./BlogPosts");
        }

    }
}
