using AdminPanel.Dto.BOD;
using AdminPanel.IServices;

namespace AdminPanel.Services
{
    public class BODService : IBODService
    {
        private readonly IHttpClientFactory _clientFactory;

        public BODService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task CreateBODAsync(CreateBODDto bod)
        {
            var client = _clientFactory.CreateClient();
            await client.PostAsJsonAsync("https://api.samairline.ir/v1/BODs", bod);
        }

        public async Task DeleteBODAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://api.samairline.ir/v1/BODs/{id}");

            // Log the status code and response content for debugging
            Console.WriteLine($"Response status: {response.StatusCode}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response content: {content}");
            }
        }

        public async Task<GetBODDto> GetBODAsync(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://api.samairline.ir/v1/BODs/{id}");

            if (response.IsSuccessStatusCode)
            {
                var bod = await response.Content.ReadAsAsync<GetBODDto>();
                return bod;
            }

            return null;
        }

        public async Task<IEnumerable<GetBODDto>> GetBODsAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://api.samairline.ir/v1/BODs");

            if (response.IsSuccessStatusCode)
            {
                var bODs = await response.Content.ReadAsAsync<IEnumerable<GetBODDto>>();
                return bODs;
            }

            return null;
        }

        public async Task UpdateBODAsync(int id, UpdateBODDto bod)
        {
            var client = _clientFactory.CreateClient();
            await client.PutAsJsonAsync($"https://api.samairline.ir/v1/BODs/{id}", bod);
        }
    }
}
