using AdminPanel.Dto.SlideShow;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class CreateSliderImageModel : PageModel
    {
        private readonly ISliderService _sliderImageService;
        private readonly IFileUploadService _fileUploadService;
        
        public CreateSliderImageModel(ISliderService sliderImageService, IFileUploadService fileUploadService)
        {
            _sliderImageService = sliderImageService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public CreateImagesDto sliderimage { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Image == null && string.IsNullOrEmpty(sliderimage.imageLink))
            {
                ModelState.AddModelError("Image", "Please upload an image or enter an image link.");
                ModelState.AddModelError("sliderimage.imageLink", "Please upload an image or enter an image link.");
            }

            if (Image != null)
            {
                sliderimage.imageLink = await _fileUploadService.UploadFileAsync(Image);
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

            await _sliderImageService.CreateSilderAsync(sliderimage);

            return RedirectToPage("./SliderImages");
        }

    }
}
