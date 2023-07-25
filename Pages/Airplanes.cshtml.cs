using AdminPanel.Dto.Airplane;
using AdminPanel.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminPanel.Pages
{
    public class AirplanesModel : PageModel
    {
        private readonly IAirplaneService _airplaneService;

        public AirplanesModel(IAirplaneService airplaneService)
        {
            _airplaneService = airplaneService;
            Airplanes = new List<GetAirplaneDto>(); // Initialize Airplanes to an empty list
        }

        public IEnumerable<GetAirplaneDto> Airplanes { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _airplaneService.GetAirplanesAsync();
            if (result != null)
            {
                Airplanes = result;
            }
        }
    }
}
