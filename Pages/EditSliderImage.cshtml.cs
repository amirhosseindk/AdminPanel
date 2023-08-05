using AdminPanel.Dto.SlideShow;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    [Authorize]
    public class EditSliderImageModel : PageModel
    {
        private readonly ISliderService _sliderImageService;
        private readonly IFileUploadService _fileUploadService;

        public EditSliderImageModel(ISliderService silderService, IFileUploadService fileUploadService)
        {
            _sliderImageService = silderService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public UpdateImagesDto sliderimage { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var get = await _sliderImageService.GetSilderAsync(id);
            sliderimage = new UpdateImagesDto
            {
                id = get.id,
                imageLink = get.imageLink
            };

            if (sliderimage == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (Image == null || string.IsNullOrEmpty(sliderimage.imageLink))
            {
                ModelState.AddModelError("", "Please upload an image or enter an image link.");
                return Page();
            }

            if (Image != null)
            {
                sliderimage.imageLink = await _fileUploadService.UploadFileAsync(Image);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _sliderImageService.UpdateSilderAsync(id, sliderimage);

            return RedirectToPage("./SliderImages");
        }


    }
}
