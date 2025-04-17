namespace Application.Interfaces.Data;

public interface IBaseRepository<T> where T : class
{
    Task<T?> CreateAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(int id);
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T?>> GetAsync();
}
