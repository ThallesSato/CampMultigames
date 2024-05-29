namespace CampMultigames.Domain.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}