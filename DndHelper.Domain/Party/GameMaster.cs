using DndHelper.Infrastructure;

namespace DndHelper.Domain.Party;

public class GameMaster : Entity<string>
{
    private readonly User<string> user;
    public GameMaster(User<string> user) : base(user.Id)
    {
        this.user = user;
    }
}