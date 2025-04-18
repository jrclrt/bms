using Application.DTOs.Resident;

namespace Application.Interfaces.Services;

public interface IResidentService
{
    Task<IEnumerable<ReadResidentDTO>> GetAsync();
    Task<ReadResidentDTO> GetByIdAsync(int id);
    Task<ReadResidentDTO> CreateAsync(CreateResidentDTO createResidentDto);
    Task<bool> UpdateAsync(int residentId, UpdateResidentDTO updateResidentDto);
    Task<bool> DeleteAsync(int residentId);
}
