using AdminPanel.Dto.Text;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    [Authorize]
    public class EditTextsModel : PageModel
    {
        private readonly ITextService _textService;

        public EditTextsModel(ITextService textService)
        {
            _textService = textService;
        }

        [BindProperty]
        public string LandingText { get; set; }

        [BindProperty]
        public string CUFText { get; set; }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var landingTextDto = new TextDto { Text = LandingText };
            var cufTextDto = new TextDto { Text = CUFText };
            var cusTextDto = new TextDto { Text = CUSText };

            await _textService.UpdateLandingTextAsync(landingTextDto);
            await _textService.UpdateCUFTextAsync(cufTextDto);
            await _textService.UpdateCUSTextAsync(cusTextDto);

            return RedirectToPage("/Texts");
        }
    }
}
