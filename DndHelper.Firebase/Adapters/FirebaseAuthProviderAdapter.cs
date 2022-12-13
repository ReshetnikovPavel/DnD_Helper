using Firebase.Auth;
using DndHelper.App;


namespace DndHelper.Firebase.Adapters;

public class FirebaseAuthProviderAdapter : IAuthProvider
{
    private FirebaseAuthProvider provider;
    private FirebaseAuthLink link;
    public FirebaseAuthProviderAdapter(FirebaseAuthProvider provider)
    {
        this.provider = provider;
    }
    public async Task CreateUserWithEmailAndPassword(string email, string password)
    {
        link = await provider.CreateUserWithEmailAndPasswordAsync(email, password);
    }

    public async Task SignInWithEmailAndPassword(string email, string password)
    {
        link = await provider.SignInWithEmailAndPasswordAsync(email, password);
    }
}