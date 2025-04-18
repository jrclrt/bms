using Application.Interfaces.Data;
using Domain.Entities;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class ResidentRepository : IResidentRepository
{
    private readonly ApplicationDbContext _context;

    public ResidentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Resident entity)
    {
        await _context.Set<Resident>().AddAsync(entity);
    }

    public async Task DeleteAsync(Resident entity)
    {
        _context.Set<Resident>().Update(entity);
    }

    public async Task<IEnumerable<Resident>> GetAsync()
    {
        return await _context.Residents.Where(x => x.IsDeleted == false).ToListAsync();
    }

    public async Task<Resident> GetByIdAsync(int id)
    {
        return await _context.Residents.SingleOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
    }

    public async Task UpdateAsync(Resident entity)
    {
        _context.Set<Resident>().Update(entity);
    }
}