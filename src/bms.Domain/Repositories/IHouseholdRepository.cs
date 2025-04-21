using bms.Domain.Entities;

namespace bms.Domain.Repositories;

public interface IHouseholdRepository
{
    Task<Household?> GetByIdAsync(Guid id);
    Task AddAsync(Household household);
}