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

    public async Task<Resident> CreateAsync(Resident entity)
    {
        await _context.Residents.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> DeleteAsync(Resident entity)
    {
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<Resident>> GetAsync()
    {
        return await _context.Residents.Where(x => x.IsDeleted == false).ToListAsync();
    }

    public async Task<Resident> GetByIdAsync(int id)
    {
        return await _context.Residents.SingleOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
    }

    public async Task<bool> UpdateAsync(Resident entity)
    {
        await _context.SaveChangesAsync();
        
        return true;
    }
}