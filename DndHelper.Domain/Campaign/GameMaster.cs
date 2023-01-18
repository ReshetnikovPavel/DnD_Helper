using DndHelper.Infrastructure;

namespace DndHelper.Domain.Campaign;

public class GameMaster : Entity<string>
{
    public GameMaster(string id) : base(id)
    {
    }

}