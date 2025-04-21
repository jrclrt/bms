using bms.Application.DTOs.Household;
using bms.Application.Interfaces;
using bms.Domain.Entities;
using bms.Domain.Repositories;

namespace bms.Application.Features;

public class HouseholdService : IHouseholdService
{
    private readonly IHouseholdRepository _householdRepository;
    
    public HouseholdService(IHouseholdRepository householdRepository)
    {
        _householdRepository = householdRepository;
    }
    
    public async Task AddAsync(CreateHouseholdDto createHouseholdDto)
    {
        var household = Household.Create(Guid.NewGuid(),
            createHouseholdDto.HouseholdName,
            createHouseholdDto.Street,
            createHouseholdDto.Barangay,
            createHouseholdDto.District,
            createHouseholdDto.City,
            createHouseholdDto.Region,
            createHouseholdDto.Country,
            createHouseholdDto.Zipcode);
        
        await _householdRepository.AddAsync(household);
    }
}