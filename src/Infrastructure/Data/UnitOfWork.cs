using Application.Interfaces.Data;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _transaction;
    private readonly IResidentRepository _residentRepository;
    
    public UnitOfWork(ApplicationDbContext context, IResidentRepository residentRepository)
    {
        _context = context;
        _residentRepository = residentRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await _transaction.RollbackAsync();
            throw;
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public IResidentRepository Residents => _residentRepository;
}