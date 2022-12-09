using Infrastructure;

namespace DnD_Helper.ApplicationClasses;

public class User : Entity<Guid>
{
    public User(Guid id) : base(id)
    {
    }

    public string Name { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }
}