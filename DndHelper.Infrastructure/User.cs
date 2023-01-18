using DndHelper.Infrastructure.Authentication;
using System.Net.Mail;

namespace DndHelper.Infrastructure
{
    public class User<TId> : Entity<TId>
    {
        public User(TId id, MailAddress email, AuthenticationToken authenticationToken) : base(id)
        {
            Email = email;
            AuthenticationToken = authenticationToken;
        }
        public MailAddress Email { get; }
        public AuthenticationToken AuthenticationToken { get; }
    }
}
