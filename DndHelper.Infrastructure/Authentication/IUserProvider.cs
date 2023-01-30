namespace DndHelper.Infrastructure.Authentication;

public interface IUserProvider<TId>
{
    User<TId> User { get; }
}