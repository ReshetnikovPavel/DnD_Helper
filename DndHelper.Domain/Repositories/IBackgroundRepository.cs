using DndHelper.Domain.Dnd;


namespace DndHelper.Domain.Repositories;

public interface IBackgroundRepository : IRepository
{
    Background GetBackground(string name);
}