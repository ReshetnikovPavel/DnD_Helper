using Firebase.Database;
using DndHelper.App.Database;
using DndHelper.App;
using DndHelper.App.Authentication;
using Firebase.Auth;

namespace DndHelper.Firebase.Adapters
{
    public class FirebaseClientAdapter : IDatabaseClient
    {
        private FirebaseClient firebaseClient;
        private readonly FirebaseDatabaseUrl url;
        public FirebaseClientAdapter(FirebaseDatabaseUrl url)
        {
            this.url = url;
            firebaseClient = new FirebaseClient(url.Url);
        }

        public IDatabaseQuery Child(string name)
        {
            return new ChildQueryAdapter(firebaseClient.Child(name));
        }

        public void SignIn<T>(User<T> user)
        {
            firebaseClient = new FirebaseClient(
                url.Url,
                new FirebaseOptions()
                {
                    AuthTokenAsyncFactory = () => GetToken(user)
                }) ;
        }

        private static Task<string> GetToken<T>(User<T> user)
        {
            return Task.FromResult(user.AuthenticationToken.Token);
        }
    }
}
