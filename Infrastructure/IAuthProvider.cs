namespace Infrastructure;

public interface IAuthProvider
{
    public Task CreateUserWithEmailAndPassword(string email, string password);
    public Task SignInWithEmailAndPassword(string email, string password);
}