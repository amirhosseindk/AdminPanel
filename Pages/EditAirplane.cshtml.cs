using AdminPanel.Dto.Airplane;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    [Authorize]
    public class EditAirplaneModel : PageModel
    {
        private readonly IAirplaneService _airplaneService;
        private readonly IFileUploadService _fileUploadService;

        public EditAirplaneModel(IAirplaneService airplaneService, IFileUploadService fileUploadService)
        {
            _airplaneService = airplaneService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public UpdateAirplaneDto Airplane { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var get = await _airplaneService.GetAirplaneAsync(id);
            Airplane = new UpdateAirplaneDto
            {
                id = get.id,
                model = get.model,
                register = get.register,
                imageLink = get.imageLink
            };

            if (Airplane == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (Image == null || string.IsNullOrEmpty(Airplane.imageLink))
            {
                ModelState.AddModelError("", "Please upload an image or enter an image link.");
                return Page();
            }

            if (Image != null)
            {
                Airplane.imageLink = await _fileUploadService.UploadFileAsync(Image);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _airplaneService.UpdateAirplaneAsync(id, Airplane);

            return RedirectToPage("./Airplanes");
        }
    }
}
