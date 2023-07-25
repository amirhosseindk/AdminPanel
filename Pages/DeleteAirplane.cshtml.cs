using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class DeleteAirplaneModel : PageModel
    {
        private readonly IAirplaneService _airplaneService;

        public DeleteAirplaneModel(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _airplaneService.DeleteAirplaneAsync(id);
            return RedirectToPage("./Airplanes");
        }
    }
}