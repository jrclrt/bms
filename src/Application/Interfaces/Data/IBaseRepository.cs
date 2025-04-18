namespace Application.Interfaces.Data;

public interface IBaseRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAsync();
}
