using AdminPanel.Dto.BlogPost;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    [Authorize]
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
        public UpdateBlogPostDto BlogPost { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var get = await _blogPostService.GetBlogPostAsync(id);
            BlogPost = new UpdateBlogPostDto
            {
                id = get.id,
                title = get.title,
                author = get.author,
                text = get.text,
                imageLink = get.imageLink,
                editedAt = DateTime.UtcNow
            };

            if (BlogPost == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (Image == null || string.IsNullOrEmpty(BlogPost.imageLink))
            {
                ModelState.AddModelError("", "Please upload an image or enter an image link.");
                return Page();
            }

            if (Image != null)
            {
                BlogPost.imageLink = await _fileUploadService.UploadFileAsync(Image);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _blogPostService.UpdateBlogPostAsync(id, BlogPost);

            return RedirectToPage("./BlogPosts");
        }
    }
}
