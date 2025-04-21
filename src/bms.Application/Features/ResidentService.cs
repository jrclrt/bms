using bms.Application.DTOs.Resident;
using bms.Application.Interfaces;
using bms.Domain.Entities;
using bms.Domain.Repositories;

namespace bms.Application.Features;

public class ResidentService : IResidentService
{
    private readonly IResidentRepository _residentRepository;
    
    public ResidentService(IResidentRepository residentRepository)
    {
        _residentRepository = residentRepository;
    }
    
    public async Task AddAsync(CreateResidentDto createResidentDto)
    {
        var resident = Resident.Create(Guid.NewGuid(), 
            createResidentDto.FirstName, 
            createResidentDto.MiddleName, 
            createResidentDto.LastName,
            createResidentDto.Suffix,
            createResidentDto.BirthDate,
            createResidentDto.Gender,
            createResidentDto.Nationality);
        
        await _residentRepository.AddAsync(resident);
    }
}