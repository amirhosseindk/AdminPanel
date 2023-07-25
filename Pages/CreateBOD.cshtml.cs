using AdminPanel.Dto.BOD;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class CreateBODModel : PageModel
    {
        private readonly IBODService _bodService;
        private readonly IFileUploadService _fileUploadService;

        public CreateBODModel(IBODService bodService, IFileUploadService fileUploadService)
        {
            _bodService = bodService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public CreateBODDto BOD { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Image == null && string.IsNullOrEmpty(BOD.imageLink))
            {
                ModelState.AddModelError("Image", "Please upload an image or enter an image link.");
                ModelState.AddModelError("BOD.imageLink", "Please upload an image or enter an image link.");
            }

            if (Image != null)
            {
                BOD.imageLink = await _fileUploadService.UploadFileAsync(Image);
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

            await _bodService.CreateBODAsync(BOD);

            return RedirectToPage("./BODs");
        }
    }
}
