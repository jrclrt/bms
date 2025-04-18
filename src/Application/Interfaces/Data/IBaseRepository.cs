namespace Application.Interfaces.Data;

public interface IBaseRepository<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAsync();
}
