using AdminPanel.Dto.SlideShow;

namespace AdminPanel.IServices
{
    public interface ISliderService
    {
        Task<IEnumerable<GetImagesDto>> GetSilderAsync();
        Task<GetImagesDto> GetSilderAsync(int id);
        Task CreateSilderAsync(CreateImagesDto Silder);
        Task UpdateSilderAsync(int id, UpdateImagesDto Silder);
        Task DeleteSilderAsync(int id);
    }
}
