using AdminPanel.Dto.BOD;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    [Authorize]
    public class EditBODModel : PageModel
    {
        private readonly IBODService _bodService;
        private readonly IFileUploadService _fileUploadService;


        public EditBODModel(IBODService bodService, IFileUploadService fileUploadService)
        {
            _bodService = bodService;
            _fileUploadService = fileUploadService;
        }

        [BindProperty]
        public UpdateBODDto BOD { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var get = await _bodService.GetBODAsync(id);
            BOD = new UpdateBODDto
            {
                id = get.id,
                name = get.name,
                position = get.position,
                imageLink = get.imageLink
            };

            if (BOD == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (Image == null || string.IsNullOrEmpty(BOD.imageLink))
            {
                ModelState.AddModelError("", "Please upload an image or enter an image link.");
                return Page();
            }

            if (Image != null)
            {
                BOD.imageLink = await _fileUploadService.UploadFileAsync(Image);
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _bodService.UpdateBODAsync(id, BOD);

            return RedirectToPage("./BODs");
        }
    }
}
