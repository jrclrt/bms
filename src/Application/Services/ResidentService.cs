using Application.DTOs.Resident;
using Application.Interfaces.Data;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services;

public class ResidentService : IResidentService
{
    private readonly IUnitOfWork _unitOfWork;

    public ResidentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ReadResidentDTO>> GetAsync()
    {
        var residents = await _unitOfWork.Residents.GetAsync();
        
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

    public async Task<ReadResidentDTO> GetByIdAsync(int residentId)
    {
        var resident = await _unitOfWork.Residents.GetByIdAsync(residentId);

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
        try
        {
            using var transaction = _unitOfWork.BeginTransactionAsync();
            
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
            
            await _unitOfWork.Residents.CreateAsync(resident);
            await _unitOfWork.SaveChangesAsync();
            
            ReadResidentDTO readResidentDto = new ReadResidentDTO();
            readResidentDto.Id = resident.Id;
            readResidentDto.FirstName = resident.FirstName;
            readResidentDto.MiddleName = resident.MiddleName;
            readResidentDto.LastName = resident.LastName;
            readResidentDto.Suffix = resident.Suffix;
            readResidentDto.BirthDate = resident.BirthDate;
            readResidentDto.Gender = resident.Gender;
            readResidentDto.Nationality = resident.Nationality;

            await _unitOfWork.CommitTransactionAsync();
            
            return readResidentDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
        
        return null;
    }

    public async Task<bool> UpdateAsync(int residentId, UpdateResidentDTO updateResidentDto)
    {
        try
        {
            using var transaction = _unitOfWork.BeginTransactionAsync();
            
            var resident = await _unitOfWork.Residents.GetByIdAsync(residentId);
            
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

                await _unitOfWork.Residents.UpdateAsync(resident);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }

        return false;
    }

    public async Task<bool> DeleteAsync(int residentId)
    {
        try
        {
            using var transaction = _unitOfWork.BeginTransactionAsync();
            
            var resident = await _unitOfWork.Residents.GetByIdAsync(residentId);
            
            if (resident is not null)
            {
                resident.IsDeleted = true;
                resident.UpdatedDate = DateTime.UtcNow;

                await _unitOfWork.Residents.DeleteAsync(resident);
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();
                
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
        
        return false;
    }
}
