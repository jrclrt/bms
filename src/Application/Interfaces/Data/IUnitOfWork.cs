using System;

namespace Application.Interfaces.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    
    IResidentRepository Residents {  get; }
}
