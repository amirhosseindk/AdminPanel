using AdminPanel.Dto.BOD;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class BODsModel : PageModel
    {
        private readonly IBODService _bodService;

        public BODsModel(IBODService bodService)
        {
            _bodService = bodService;
            BODs = new List<GetBODDto>(); // Initialize BODs to an empty list
        }

        public IEnumerable<GetBODDto> BODs { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _bodService.GetBODsAsync();
            if (result != null)
            {
                BODs = result;
            }
        }
    }
}
