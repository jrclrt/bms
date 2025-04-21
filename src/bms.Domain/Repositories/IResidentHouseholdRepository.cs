using bms.Domain.Entities;

namespace bms.Domain.Repositories;

public interface IResidentHouseholdRepository
{
    Task AddRangeAsync(List<ResidentHousehold> residentHouseholdList);
}