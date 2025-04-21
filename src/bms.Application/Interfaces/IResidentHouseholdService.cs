using bms.Application.DTOs.Household;
using bms.Application.DTOs.ResidentHousehold;

namespace bms.Application.Interfaces;

public interface IResidentHouseholdService
{
    Task AddHouseholdFromResidentAsync(Guid residentId, CreateHouseholdFromResidentDto createHouseholdFromResidentDto);
}