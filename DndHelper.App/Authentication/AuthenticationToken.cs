namespace DndHelper.App.Authentication
{
    public class AuthenticationToken
    {
        public string Token { get; }
        public AuthenticationToken(string token)
        {
            Token = token;
        }
    }
}
