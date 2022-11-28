namespace Domain.Repositories;

public interface IBackgroundRepository : IRepository
{
    Background GetBackground(string name);
}