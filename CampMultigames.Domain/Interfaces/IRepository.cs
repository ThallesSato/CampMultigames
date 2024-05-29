namespace CampMultigames.Domain.Interfaces;

public interface IRepository <TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdOrDefaultAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    void Update(TEntity entity);
    Task<TEntity> CreateAsync(TEntity entity);
    bool Delete(TEntity entity);
}