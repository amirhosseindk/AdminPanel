using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using AdminPanel.Dto.Airplane;
using Microsoft.AspNetCore.Authorization;

namespace AdminPanel.Pages
{
    [Authorize]
    public class CreateAirplaneModel : PageModel
    {
        private readonly IAirplaneService _airplaneService;
        private readonly IFileUploadService _fileUploadService;

        public CreateAirplaneModel(IAirplaneService airplaneService, IFileUploadService fileUploadService)
        {
            _airplaneService = airplaneService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public CreateAirplaneDto Airplane { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Image == null || string.IsNullOrEmpty(Airplane.imageLink))
            {
                ModelState.AddModelError("Image", "Please upload an image or enter an image link.");
                ModelState.AddModelError("Airplane.imageLink", "Please upload an image or enter an image link.");
            }

            if (Image != null)
            {
                Airplane.imageLink = await _fileUploadService.UploadFileAsync(Image);
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

            await _airplaneService.CreateAirplaneAsync(Airplane);

            return RedirectToPage("./Airplanes");
        }
    }
}
