namespace DndHelper.Infrastructure.Authentication;

public interface IAuthenticationProvider<TId>
{
    Task<Result<User<string>, AuthenticationStatus>> RegisterUserWithEmailAndPassword(string email, string password);
    Task<Result<User<string>, AuthenticationStatus>> SignInWithEmailAndPassword(string email, string password);
    AuthenticationToken AuthenticationToken { get; }
    bool IsAuthenticated { get; }
}