using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class DeleteBODModel : PageModel
    {
        private readonly IBODService _bodService;

        public DeleteBODModel(IBODService bodService)
        {
            _bodService = bodService;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _bodService.DeleteBODAsync(id);
            return RedirectToPage("./BODs");
        }
    }
}
