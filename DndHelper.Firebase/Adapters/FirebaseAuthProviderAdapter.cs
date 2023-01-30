using DndHelper.Infrastructure;
using DndHelper.Infrastructure.Authentication;
using Firebase.Auth;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Net.Mail;

namespace DndHelper.Firebase.Adapters;

public class FirebaseAuthProviderAdapter : IAuthenticationProvider<string>, IUserProvider<string>
{
    private readonly FirebaseAuthProvider provider;
    private FirebaseAuthLink link;
    public AuthenticationToken AuthenticationToken => new(link.FirebaseToken);

    private User<string> user;
    public User<string> User
    {
        get => user;
        private set
        {
            user = value;
            Preferences.Set(nameof(AuthenticationToken), user.AuthenticationToken.Token);
        }
    }

    public bool IsAuthenticated => User != null;
    public FirebaseAuthProviderAdapter(FirebaseConfig config)
    {
        provider = new FirebaseAuthProvider(config);
        SetUserIfAuthenticationTokenStillWorks();
    }

    private async void SetUserIfAuthenticationTokenStillWorks()
    {
        var token = Preferences.Get(nameof(AuthenticationToken), null);
        if (token == null) 
            return;

        var result = await HandleError(async () =>  await provider.GetUserAsync(token));

        if (result.TryGetValue(out var firebaseUser)) 
            User = CreateUserWithEmailAndPassword(firebaseUser, token);
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
        return CreateUserWithEmailAndPassword(link.User, link.FirebaseToken);
    }

    private static User<string> CreateUserWithEmailAndPassword(User firebaseUser, string firebaseToken)
    {
        var id = firebaseUser.LocalId;
        var email = new MailAddress(firebaseUser.Email);
        var token = new AuthenticationToken(firebaseToken);

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