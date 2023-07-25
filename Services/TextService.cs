using AdminPanel.Dto.Text;
using AdminPanel.IServices;

namespace AdminPanel.Services
{
    public class TextService : ITextService
    {
        private readonly IHttpClientFactory _clientFactory;

        public TextService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TextDto> GetLandingText()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.samairline.ir/v1/LandingText");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TextDto>();
            }

            return null;
        }

        public async Task<TextDto> GetCUFtext()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.samairline.ir/v1/CUFtext");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TextDto>();
            }

            return null;
        }

        public async Task<TextDto> GetCUStext()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.samairline.ir/v1/CUStext");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TextDto>();
            }

            return null;
        }

        public async Task UpdateLandingTextAsync(TextDto updateDto)
        {
            var client = _clientFactory.CreateClient();
            await client.PutAsJsonAsync("https://api.samairline.ir/v1/LandingText", updateDto);
        }

        public async Task UpdateCUFTextAsync(TextDto updateDto)
        {
            var client = _clientFactory.CreateClient();
            await client.PutAsJsonAsync("https://api.samairline.ir/v1/CUFtext", updateDto);
        }

        public async Task UpdateCUSTextAsync(TextDto updateDto)
        {
            var client = _clientFactory.CreateClient();
            await client.PutAsJsonAsync("https://api.samairline.ir/v1/CUStext", updateDto);
        }
    }
}
