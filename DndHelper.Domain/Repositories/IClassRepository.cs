using DndHelper.Domain.Dnd;

namespace DndHelper.Domain.Repositories;

public interface IClassRepository : IRepository
{
    Class GetClass(string name);
}