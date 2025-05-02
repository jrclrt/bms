using bms.Domain.Entities;

namespace bms.Domain.Repositories;

public interface IResidentRepository
{
    Task<IEnumerable<Resident?>> GetAllAsync();
    Task<Resident?> GetByIdAsync(Guid id);
    Task AddAsync(Resident resident);
}