using DndHelper.Infrastructure;
using DndHelper.Infrastructure.Authentication;
using Firebase.Auth;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Net.Mail;

namespace DndHelper.Firebase.Adapters;

public class FirebaseAuthProviderAdapter : IAuthenticationProvider<string>
{
    private readonly FirebaseAuthProvider provider;
    private FirebaseAuthLink link;
    public AuthenticationToken AuthenticationToken => new(link.FirebaseToken);
    public User<string> User { get; private set; }
    public bool IsAuthenticated => User != null;
    public FirebaseAuthProviderAdapter(FirebaseConfig config)
    {
        provider = new FirebaseAuthProvider(config);
    }

    public Task<Result<User<string>, AuthenticationStatus>> RegisterUserWithEmailAndPassword(string email, string password)
    { 
        return HandleError( async () => await RegisterUserWithEmailAndPasswordThrowsException(email, password));
    }
    private async Task<User<string>> RegisterUserWithEmailAndPasswordThrowsException(string email, string password)
    {
        link = await provider.CreateUserWithEmailAndPasswordAsync(email, password);
        User = CreateUserWithEmailAndPassword(link);
        return User;
    }

    public Task<Result<User<string>, AuthenticationStatus>> SignInWithEmailAndPassword(string email, string password)
    {
        return HandleError(async () => await SignInWithEmailAndPasswordThrowsException(email, password));
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
    private static async Task<Result<T, AuthenticationStatus>> HandleError<T>(Func<Task<T>> interactWithFirebase)
    {
        try
        {
            return await interactWithFirebase();
        }
        catch (FirebaseAuthException e)
        {
            return Result.CreateFailure<T, AuthenticationStatus>((AuthenticationStatus)e.Reason, e);
        }
    }
}