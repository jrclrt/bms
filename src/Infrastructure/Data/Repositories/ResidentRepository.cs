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

    public async Task<Resident?> CreateAsync(Resident entity)
    {
        _context.Residents?.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async void DeleteAsync(int id)
    {
        var resident = await _context.Residents.FindAsync(id);
        
        resident.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Resident?>> GetAsync()
    {
        return await _context.Residents.Where(x => x.IsDeleted == false).ToListAsync();
    }

    public async Task<Resident?> GetByIdAsync(int id)
    {
        return await _context.Residents.FindAsync(id);
    }

    public async void UpdateAsync(Resident entity)
    {
        _context.Residents?.Update(entity);
        await _context.SaveChangesAsync();
    }
}