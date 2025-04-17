using Application.DTOs.Resident;
using Application.Interfaces.Data;
using Application.Interfaces.Services;

namespace Application.Services;

public class ResidentService : IResidentService
{
    private readonly IResidentRepository _resident;

    public ResidentService(IResidentRepository resident)
    {
        _resident = resident;
    }

    public async Task<IEnumerable<ReadResidentDTO>> GetAsync()
    {
        var residents = await _resident.GetAsync();
        
        List<ReadResidentDTO> residentDTOs = new List<ReadResidentDTO>();

        foreach (var resident in residents)
        {
            ReadResidentDTO residentDto = new ReadResidentDTO();
            
            residentDto.Id = resident.Id;
            residentDto.FirstName = resident.FirstName;
            residentDto.MiddleName = resident.MiddleName;
            residentDto.LastName = resident.LastName;
            residentDto.Suffix = resident.Suffix;
            residentDto.BirthDate = resident.BirthDate;
            residentDto.Gender = resident.Gender;
            residentDto.Nationality = resident.Nationality; 
            
            residentDTOs.Add(residentDto);
        }
        
        return residentDTOs;
    }

    public async Task<ReadResidentDTO> GetByIdAsync(int id)
    {
        var resident = await _resident.GetByIdAsync(id);

        ReadResidentDTO residentDto = new ReadResidentDTO();

        if (resident is not null)
        {
            residentDto.Id = resident.Id;
            residentDto.FirstName = resident.FirstName;
            residentDto.MiddleName = resident.MiddleName;
            residentDto.LastName = resident.LastName;
            residentDto.Suffix = resident.Suffix;
            residentDto.BirthDate = resident.BirthDate;
            residentDto.Gender = resident.Gender;
            residentDto.Nationality = resident.Nationality;

            return residentDto;
        }
        
        return null;
    }
}
