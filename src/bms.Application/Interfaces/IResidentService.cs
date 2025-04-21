using bms.Application.DTOs.Resident;

namespace bms.Application.Interfaces;

public interface IResidentService
{
    Task AddAsync(CreateResidentDto createResidentDto);
}