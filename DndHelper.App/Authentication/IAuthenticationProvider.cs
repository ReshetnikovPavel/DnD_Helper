namespace DndHelper.App.Authentication;

public interface IAuthenticationProvider<TId>
{
    Task<User<TId>> RegisterUserWithEmailAndPassword(string email, string password);
    Task<User<TId>> SignInWithEmailAndPassword(string email, string password);
}