using Firebase.Auth;
using DndHelper.App.Authentication;
using DndHelper.App;
using System.Net.Mail;

namespace DndHelper.Firebase.Adapters;

public class FirebaseAuthProviderAdapter : IAuthenticationProvider<string>
{
    private FirebaseAuthProvider provider;
    public FirebaseAuthProviderAdapter(FirebaseConfig config)
    {
        provider = new FirebaseAuthProvider(config);
    }
    public async Task<User<string>> RegisterUserWithEmailAndPassword(string email, string password)
    {
        var link = await provider.CreateUserWithEmailAndPasswordAsync(email, password);
        return CreateUserWithEmailAndPassword(link);
    }

    public async Task<User<string>> SignInWithEmailAndPassword(string email, string password)
    {
        var link = await provider.SignInWithEmailAndPasswordAsync(email, password);
        return CreateUserWithEmailAndPassword(link);
    }

    private static User<string> CreateUserWithEmailAndPassword(FirebaseAuthLink link)
    {
        var id = link.User.LocalId;
        var email = new MailAddress(link.User.Email);
        var token = new AuthenticationToken(link.FirebaseToken);

        return new User<string>(id, email, token);
    }
}