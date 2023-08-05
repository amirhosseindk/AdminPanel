using AdminPanel.Dto.BlogPost;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AdminPanel.Pages
{
    [Authorize]
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
        public CreateBlogPostDto BlogPost { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Image == null || string.IsNullOrEmpty(BlogPost.imageLink))
            {
                ModelState.AddModelError("Image", "Please upload an image or enter an image link.");
                ModelState.AddModelError("BlogPost.imageLink", "Please upload an image or enter an image link.");
            }

            if (Image != null)
            {
                BlogPost.imageLink = await _fileUploadService.UploadFileAsync(Image);
            }

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return Page();
            }

            await _blogPostService.CreateBlogPostAsync(BlogPost);

            return RedirectToPage("./BlogPosts");
        }
    }
}
