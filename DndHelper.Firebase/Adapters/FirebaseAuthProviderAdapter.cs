using Firebase.Auth;
using DndHelper.App.Authentication;
using DndHelper.App;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

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
    public async Task<User<string>> RegisterUserWithEmailAndPassword(string email, string password)
    {
        link = await provider.CreateUserWithEmailAndPasswordAsync(email, password);
        User = CreateUserWithEmailAndPassword(link);
        return User;
    }

    public async Task<User<string>> SignInWithEmailAndPassword(string email, string password)
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