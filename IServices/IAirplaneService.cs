using AdminPanel.Dto.Airplane;

namespace AdminPanel.IServices
{
    public interface IAirplaneService
    {
        Task<IEnumerable<GetAirplaneDto>> GetAirplanesAsync();
        Task<GetAirplaneDto> GetAirplaneAsync(int id);
        Task CreateAirplaneAsync(CreateAirplaneDto Airplane);
        Task UpdateAirplaneAsync(int id, UpdateAirplaneDto Airplane);
        Task DeleteAirplaneAsync(int id);
    }
}
