using DndHelper.App;
using DndHelper.App.Authentication;
using DndHelper.Infrastructure;
using Firebase.Auth;
using System.Net.Mail;

namespace DndHelper.Firebase.Adapters;

public class FirebaseAuthProviderAdapter : IAuthenticationProvider<string>
{
    private readonly FirebaseAuthProvider provider;
    private FirebaseAuthLink link;
    public AuthenticationToken AuthenticationToken => new(link.FirebaseToken);
    public User<string> User { get; private set; }
    public FirebaseAuthProviderAdapter(FirebaseConfig config)
    {
        provider = new FirebaseAuthProvider(config);
    }

    public async Task<Result<User<string>, AuthenticationStatus>> RegisterUserWithEmailAndPassword(string email, string password)
    {
        try
        {
            return await RegisterUserWithEmailAndPasswordThrowsException(email, password);
        }
        catch (FirebaseAuthException e)
        {
            return Result.CreateFailure<User<string>, AuthenticationStatus>((AuthenticationStatus)e.Reason);
        }
    }
    private async Task<User<string>> RegisterUserWithEmailAndPasswordThrowsException(string email, string password)
    {
        link = await provider.CreateUserWithEmailAndPasswordAsync(email, password);
        User = CreateUserWithEmailAndPassword(link);
        return User;
    }

    public async Task<Result<User<string>, AuthenticationStatus>> SignInWithEmailAndPassword(string email, string password)
    {
        try
        {
            return await SignInWithEmailAndPasswordThrowsException(email, password);
        }
        catch (FirebaseAuthException e)
        {
            return Result.CreateFailure<User<string>, AuthenticationStatus>((AuthenticationStatus)e.Reason);
        }
    }

    private async Task<User<string>> SignInWithEmailAndPasswordThrowsException(string email, string password)
    {
        link = await provider.SignInWithEmailAndPasswordAsync(email, password);
        User = CreateUserWithEmailAndPassword(link);
        return User;
    }

    private static User<string> CreateUserWithEmailAndPassword(FirebaseAuthLink link)
    {
        var id = link.User.LocalId;
        var email = new MailAddress(link.User.Email);
        var token = new AuthenticationToken(link.FirebaseToken);

        return new User<string>(id, email, token);
    }
}