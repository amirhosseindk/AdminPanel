using AdminPanel.Dto.SlideShow;
using AdminPanel.IServices;

namespace AdminPanel.Services
{
    public class SliderService : ISliderService
    {
        private readonly IHttpClientFactory _clientFactory;

        public SliderService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task CreateSilderAsync(CreateImagesDto Silder)
        {
            var client = _clientFactory.CreateClient();
            await client.PostAsJsonAsync("https://api.samairline.ir/v1/SlidebarImages", Silder);
        }

        public async Task DeleteSilderAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://api.samairline.ir/v1/SlidebarImages/{id}");

            Console.WriteLine($"Response status: {response.StatusCode}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response content: {content}");
            }
        }

        public async Task<IEnumerable<GetImagesDto>> GetSilderAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.samairline.ir/v1/SlidebarImages");

            if (response.IsSuccessStatusCode)
            {
                var sliders = await response.Content.ReadAsAsync<IEnumerable<GetImagesDto>>();
                return sliders;
            }

            return null;
        }

        public async Task<GetImagesDto> GetSilderAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://api.samairline.ir/v1/SlidebarImages/{id}");

            if (response.IsSuccessStatusCode)
            {
                var images = await response.Content.ReadAsAsync<GetImagesDto>();
                return images;
            }

            return null;
        }

        public async Task UpdateSilderAsync(int id, UpdateImagesDto Silder)
        {
            var client = _clientFactory.CreateClient();
            await client.PutAsJsonAsync($"https://api.samairline.ir/v1/SlidebarImages/{id}", Silder);
        }
    }
}
