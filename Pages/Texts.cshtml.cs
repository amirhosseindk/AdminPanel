using System.Threading.Tasks;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    [Authorize]
    public class TextsModel : PageModel
    {
        private readonly ITextService _textService;

        public TextsModel(ITextService textService)
        {
            _textService = textService;
        }

        public string LandingText { get; set; }
        public string CUFText { get; set; }
        public string CUSText { get; set; }

        public async Task OnGetAsync()
        {
            var landingText = await _textService.GetLandingText();
            var cufText = await _textService.GetCUFtext();
            var cusText = await _textService.GetCUStext();

            LandingText = landingText.Text;
            CUFText = cufText.Text;
            CUSText = cusText.Text;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/EditTexts");
        }
    }
}
