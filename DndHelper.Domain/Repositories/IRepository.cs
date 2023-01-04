namespace DndHelper.Domain.Repositories;

public interface IRepository
{
    public IEnumerable<string> GetNames();
}