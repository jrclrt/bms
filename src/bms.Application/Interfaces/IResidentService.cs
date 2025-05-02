using bms.Application.DTOs.Resident;

namespace bms.Application.Interfaces;

public interface IResidentService
{
    //Task GetResidentById(Guid residentId);
    Task AddAsync(CreateResidentDto createResidentDto);
}