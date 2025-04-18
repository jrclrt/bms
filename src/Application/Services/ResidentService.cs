using Application.DTOs.Resident;
using Application.Interfaces.Data;
using Application.Interfaces.Services;
using Domain.Entities;

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

    public async Task<ReadResidentDTO> CreateAsync(CreateResidentDTO createResidentDto)
    {
        Resident resident = new Resident();
        resident.FirstName = createResidentDto.FirstName;
        resident.MiddleName = createResidentDto.MiddleName;
        resident.LastName = createResidentDto.LastName;
        resident.Suffix = createResidentDto.Suffix;
        resident.BirthDate = createResidentDto.BirthDate;
        resident.Gender = createResidentDto.Gender;
        resident.Nationality = createResidentDto.Nationality;
        resident.CreatedBy = "admin";
        resident.CreatedDate = DateTime.UtcNow;

        var residentResult = await _resident.CreateAsync(resident);
        
        ReadResidentDTO readResidentDto = new ReadResidentDTO();

        if (residentResult is not null)
        {
            readResidentDto.Id = residentResult.Id;
            readResidentDto.FirstName = residentResult.FirstName;
            readResidentDto.MiddleName = residentResult.MiddleName;
            readResidentDto.LastName = residentResult.LastName;
            readResidentDto.Suffix = residentResult.Suffix;
            readResidentDto.BirthDate = residentResult.BirthDate;
            readResidentDto.Gender = residentResult.Gender;
            readResidentDto.Nationality = residentResult.Nationality;
            
            return readResidentDto;
        }
        
        return null;
    }

    public async Task<bool> UpdateAsync(int residentId, UpdateResidentDTO updateResidentDto)
    {
        var resident = await _resident.GetByIdAsync(residentId);
        
        if (resident is not null)
        {
            resident.FirstName = updateResidentDto.FirstName;
            resident.MiddleName = updateResidentDto.MiddleName;
            resident.LastName = updateResidentDto.LastName;
            resident.Suffix = updateResidentDto.Suffix;
            resident.BirthDate = updateResidentDto.BirthDate;
            resident.Gender = updateResidentDto.Gender;
            resident.Nationality = updateResidentDto.Nationality;
            resident.UpdatedBy = "admin";
            resident.UpdatedDate = DateTime.UtcNow;

            return await _resident.UpdateAsync(resident);
        }
        
        return false;
    }

    public async Task<bool> DeleteAsync(int residentId)
    {
        var resident = await _resident.GetByIdAsync(residentId);
        
        if (resident is not null)
        {
            resident.IsDeleted = true;
            resident.UpdatedDate = DateTime.UtcNow;

            return await _resident.DeleteAsync(resident);
        }
        
        return false;
    }
}
