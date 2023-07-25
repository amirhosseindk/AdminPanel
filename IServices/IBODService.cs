using AdminPanel.Dto.BOD;

namespace AdminPanel.IServices
{
    public interface IBODService
    {
        Task<IEnumerable<GetBODDto>> GetBODsAsync();
        Task<GetBODDto> GetBODAsync(int id);
        Task CreateBODAsync(CreateBODDto bod);
        Task UpdateBODAsync(int id, UpdateBODDto bod);
        Task DeleteBODAsync(int id);
    }
}
