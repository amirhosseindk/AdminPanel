using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class DeleteSliderImageModel : PageModel
    {
        private readonly ISliderService _sliderImageService;

        public DeleteSliderImageModel(ISliderService silderService)
        {
            _sliderImageService = silderService;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _sliderImageService.DeleteSilderAsync(id);
            return RedirectToPage("./SliderImages");
        }
    }
}
