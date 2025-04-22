using bms.Domain.Aggregates.Residenthouseholds;

namespace bms.Domain.Repositories;

public interface IResidentHouseholdRepository
{
    Task AddRangeAsync(List<ResidentHousehold> residentHouseholdList);
}