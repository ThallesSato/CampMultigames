namespace CampMultigames.Application.Interfaces;

public interface IBaseService <TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> PostAsync(TEntity entity);
}