namespace Infrastructure;

public class User : Entity<Guid>
{
    public User(Guid id) : base(id)
    {
    }
}