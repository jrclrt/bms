using bms.Domain.Entities;

namespace bms.Domain.Repositories;

public interface IResidentRepository
{
    Task<Resident?> GetByIdAsync(Guid id);
    Task AddAsync(Resident resident);
}