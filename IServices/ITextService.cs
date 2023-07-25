using AdminPanel.Dto.Text;

namespace AdminPanel.IServices
{
    public interface ITextService
    {
        Task<TextDto> GetLandingText();
        Task<TextDto> GetCUFtext();
        Task<TextDto> GetCUStext();
        Task UpdateLandingTextAsync(TextDto updateDto);
        Task UpdateCUFTextAsync(TextDto updateDto);
        Task UpdateCUSTextAsync(TextDto updateDto);
    }
}
