using AdminPanel.Dto.SlideShow;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class SliderModel : PageModel
    {
        private readonly ISliderService _sliderService;

        public SliderModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
            SliderImages = new List<GetImagesDto>();
        }

        public IEnumerable<GetImagesDto> SliderImages { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _sliderService.GetSilderAsync();
            if (result != null)
            {
                SliderImages = result;
            }
        }
    }
}
