using Application.DTOs.Resident;

namespace Application.Interfaces.Services;

public interface IResidentService
{
    Task<IEnumerable<ReadResidentDTO>> GetAsync();
    Task<ReadResidentDTO> GetByIdAsync(int id);
}
