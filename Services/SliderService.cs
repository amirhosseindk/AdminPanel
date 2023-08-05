using AdminPanel.Dto.SlideShow;
using AdminPanel.IServices;

namespace AdminPanel.Services
{
    public class SliderService : ISliderService
    {
        private readonly HttpClient _client;

        public SliderService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("MyHttpClientWithHeaders");
        }

        public async Task CreateSilderAsync(CreateImagesDto Silder)
        {
            await _client.PostAsJsonAsync("https://localhost:44373/v1/SlidebarImages", Silder);
        }

        public async Task DeleteSilderAsync(int id)
        {
            var response = await _client.DeleteAsync($"https://localhost:44373/v1/SlidebarImages/{id}");

            Console.WriteLine($"Response status: {response.StatusCode}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response content: {content}");
            }
        }

        public async Task<IEnumerable<GetImagesDto>> GetSilderAsync()
        {
            var response = await _client.GetAsync("https://localhost:44373/v1/SlidebarImages");

            if (response.IsSuccessStatusCode)
            {
                var sliders = await response.Content.ReadAsAsync<IEnumerable<GetImagesDto>>();
                return sliders;
            }

            return null;
        }

        public async Task<GetImagesDto> GetSilderAsync(int id)
        {
            var response = await _client.GetAsync($"https://localhost:44373/v1/SlidebarImages/{id}");

            if (response.IsSuccessStatusCode)
            {
                var images = await response.Content.ReadAsAsync<GetImagesDto>();
                return images;
            }

            return null;
        }

        public async Task UpdateSilderAsync(int id, UpdateImagesDto Silder)
        {
            await _client.PutAsJsonAsync($"https://localhost:44373/v1/SlidebarImages/{id}", Silder);
        }
    }
}
