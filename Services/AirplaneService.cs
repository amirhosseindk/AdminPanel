using AdminPanel.Dto.Airplane;
using AdminPanel.IServices;

namespace AdminPanel.Services
{
    public class AirplaneService : IAirplaneService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AirplaneService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task CreateAirplaneAsync(CreateAirplaneDto Airplane)
        {
            var client = _clientFactory.CreateClient();
            await client.PostAsJsonAsync("https://api.samairline.ir/v1/Airplanes", Airplane);
        }

        public async Task DeleteAirplaneAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://api.samairline.ir/v1/Airplanes/{id}");

            // Log the status code and response content for debugging
            Console.WriteLine($"Response status: {response.StatusCode}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response content: {content}");
            }
        }

        public async Task<GetAirplaneDto> GetAirplaneAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://api.samairline.ir/v1/Airplanes/{id}");

            if (response.IsSuccessStatusCode)
            {
                var airplane = await response.Content.ReadAsAsync<GetAirplaneDto>();
                return airplane;
            }

            return null;
        }

        public async Task<IEnumerable<GetAirplaneDto>> GetAirplanesAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.samairline.ir/v1/Airplanes");

            if (response.IsSuccessStatusCode)
            {
                var airplanes = await response.Content.ReadAsAsync<IEnumerable<GetAirplaneDto>>();
                return airplanes;
            }

            return null;
        }

        public async Task UpdateAirplaneAsync(int id, UpdateAirplaneDto Airplane)
        {
            var client = _clientFactory.CreateClient();
            await client.PutAsJsonAsync($"https://api.samairline.ir/v1/Airplanes/{id}", Airplane);
        }
    }
}
