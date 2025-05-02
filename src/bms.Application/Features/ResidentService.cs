using bms.Application.DTOs.Resident;
using bms.Application.Interfaces;
using bms.Domain.Entities;
using bms.Domain.Repositories;
using bms.Domain.Results;

namespace bms.Application.Features;

public class ResidentService : IResidentService
{
    private readonly IResidentRepository _residentRepository;
    
    public ResidentService(IResidentRepository residentRepository)
    {
        _residentRepository = residentRepository;
    }

    public async Task<Result<IEnumerable<ReadResidentDto>>> GetAllResidents()
    {
        var residentsDto = await _residentRepository.GetAllAsync();
        
        List<ReadResidentDto> readResidentsDtoList = new List<ReadResidentDto>();
        foreach (var item in residentsDto)
        {
            ReadResidentDto readResidentsDto = new ReadResidentDto();
            readResidentsDto.Id = item.Id;
            readResidentsDto.FirstName = item.FirstName;
            readResidentsDto.LastName = item.LastName;
            readResidentsDto.MiddleName = item.MiddleName;
            
            readResidentsDtoList.Add(readResidentsDto);
        }

        return Result<IEnumerable<ReadResidentDto>>.Success(readResidentsDtoList);
    }
    
    public async Task<Result<ReadResidentDto>> GetResidentById(Guid residentId)
    {
        var residentDto = await _residentRepository.GetByIdAsync(residentId);

        if (residentDto == null)
        {
            var message = "Resident not found";

            return Result<ReadResidentDto>.Failure(Error.RecordNotFound(message));
        }

        ReadResidentDto readResidentDto = new ReadResidentDto();
        readResidentDto.Id = residentDto.Id;
        readResidentDto.FirstName = residentDto.FirstName;
        readResidentDto.LastName = residentDto.LastName;
        readResidentDto.MiddleName = residentDto.MiddleName;

        return Result<ReadResidentDto>.Success(readResidentDto);
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