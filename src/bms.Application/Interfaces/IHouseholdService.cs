using bms.Application.DTOs.Household;

namespace bms.Application.Interfaces;

public interface IHouseholdService
{
    Task AddAsync(CreateHouseholdDto createHouseholdDto);
}