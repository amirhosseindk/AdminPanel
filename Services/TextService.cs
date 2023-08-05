using AdminPanel.Dto.Text;
using AdminPanel.IServices;

namespace AdminPanel.Services
{
    public class TextService : ITextService
    {
        private readonly HttpClient _client;

        public TextService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("MyHttpClientWithHeaders");
        }

        public async Task<TextDto> GetLandingText()
        {
            var response = await _client.GetAsync("https://api.samairline.ir/v1/LandingText");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TextDto>();
            }

            return null;
        }

        public async Task<TextDto> GetCUFtext()
        {
            var response = await _client.GetAsync("https://api.samairline.ir/v1/CUFtext");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TextDto>();
            }

            return null;
        }

        public async Task<TextDto> GetCUStext()
        {
            var response = await _client.GetAsync("https://api.samairline.ir/v1/CUStext");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TextDto>();
            }

            return null;
        }

        public async Task UpdateLandingTextAsync(TextDto updateDto)
        {
            await _client.PutAsJsonAsync("https://api.samairline.ir/v1/LandingText", updateDto);
        }

        public async Task UpdateCUFTextAsync(TextDto updateDto)
        {
            await _client.PutAsJsonAsync("https://api.samairline.ir/v1/CUFtext", updateDto);
        }

        public async Task UpdateCUSTextAsync(TextDto updateDto)
        {
            await _client.PutAsJsonAsync("https://api.samairline.ir/v1/CUStext", updateDto);
        }
    }
}
