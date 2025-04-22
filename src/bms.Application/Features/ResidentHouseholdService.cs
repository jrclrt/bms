using bms.Application.DTOs.ResidentHousehold;
using bms.Application.Interfaces;
using bms.Domain.Aggregates.Residenthouseholds;
using bms.Domain.Repositories;

namespace bms.Application.Features;

public class ResidentHouseholdService : IResidentHouseholdService
{
    IResidentRepository _residentRepository;
    IHouseholdRepository _householdRepository;
    IResidentHouseholdRepository _residentHouseholdRepository;
    
    public ResidentHouseholdService(IResidentRepository residentRepository,
        IHouseholdRepository householdRepository,
        IResidentHouseholdRepository residentHouseholdRepository)
    {
        _residentRepository = residentRepository;
        _householdRepository = householdRepository;
        _residentHouseholdRepository = residentHouseholdRepository;
    }
    
    public async Task AddHouseholdFromResidentAsync(Guid residentId, CreateHouseholdFromResidentDto createHouseholdFromResidentDto)
    {
        List<ResidentHousehold> residentHouseholdList = new List<ResidentHousehold>();
        var resident = await _residentRepository.GetByIdAsync(residentId);

        if (resident is not null)
        {
            if (createHouseholdFromResidentDto.HouseholdIds.Count > 0)
            {
                foreach (var householdId in createHouseholdFromResidentDto.HouseholdIds)
                {
                    var household = await _householdRepository.GetByIdAsync(householdId);
                    if (household is not null)
                    {   
                        var residentHousehold = resident.CreateHousehold(household);
                        residentHouseholdList.Add(residentHousehold);
                    }
                }
            }
        }

        if (residentHouseholdList.Count > 0)
        {
            await _residentHouseholdRepository.AddRangeAsync(residentHouseholdList);
        }
    }
}